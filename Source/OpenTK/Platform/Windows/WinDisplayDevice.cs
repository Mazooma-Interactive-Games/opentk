#region License

// The Open Toolkit Library License
// 
// Copyright (c) 2006 - 2010 the Open Toolkit library.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion License

using System;
using System.Collections.Generic;
using System.Diagnostics;

#if !MINIMAL

using Microsoft.Win32;
using System.Runtime.InteropServices;

#endif

namespace OpenTK.Platform.Windows
{
    internal sealed class WinDisplayDeviceDriver : DisplayDeviceBase
    {
        private readonly object display_lock = new object();

        #region Constructors

        public WinDisplayDeviceDriver()
        {
            RefreshDisplayDevices();
            SystemEvents.DisplaySettingsChanged +=
                HandleDisplaySettingsChanged;
        }

        #endregion Constructors

        #region IDisplayDeviceDriver Members

        #region TryChangeResolution

        public sealed override bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution)
        {
            DeviceMode mode = null;

            if (resolution != null)
            {
                mode = new DeviceMode();
                mode.PelsWidth = resolution.Width;
                mode.PelsHeight = resolution.Height;
                mode.BitsPerPel = resolution.BitsPerPixel;
                mode.DisplayFrequency = (int)resolution.RefreshRate;
                mode.Fields = Constants.DM_BITSPERPEL
                    | Constants.DM_PELSWIDTH
                    | Constants.DM_PELSHEIGHT
                    | Constants.DM_DISPLAYFREQUENCY;
            }

            return Constants.DISP_CHANGE_SUCCESSFUL ==
                Functions.ChangeDisplaySettingsEx((string)device.Id, mode, IntPtr.Zero,
                    ChangeDisplaySettingsEnum.Fullscreen, IntPtr.Zero);
        }

        #endregion TryChangeResolution

        #region TryRestoreResolution

        public sealed override bool TryRestoreResolution(DisplayDevice device)
        {
            return TryChangeResolution(device, null);
        }

        #endregion TryRestoreResolution

        #endregion IDisplayDeviceDriver Members

        #region Private Members

        #region RefreshDisplayDevices

        public void RefreshDisplayDevices()
        {
            lock (display_lock)
            {
                // Store an array of the current available DisplayDevice objects. This is needed to
                // preserve the original resolution.
                DisplayDevice[] previousDevices = AvailableDevices.ToArray();
                AvailableDevices.Clear();
                // We save all necessary parameters in temporary variables and construct the device
                // when every needed detail is available. The main DisplayDevice constructor adds
                // the newly constructed device to the list of available devices.
                DisplayDevice opentk_dev;
                DisplayResolution opentk_dev_current_res = null;
                List<DisplayResolution> opentk_dev_available_res = new List<DisplayResolution>();
                bool opentk_dev_primary = false;
                int device_count = 0, mode_count = 0;
                // Get available video adapters and enumerate all monitors 
                WindowsDisplayDevice dev1 = new WindowsDisplayDevice(), dev2 = new WindowsDisplayDevice();
                GCHandle Pinneddev1 = GCHandle.Alloc(dev1);
                while (Functions.EnumDisplayDevices(null, device_count++, dev1, 0))
                {
                    if ((dev1.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop) == DisplayDeviceStateFlags.None)
                        continue;

                    DeviceMode monitor_mode = new DeviceMode();
                    GCHandle Pinnedmonitor_mode = GCHandle.Alloc(monitor_mode);
                    GCHandle Pinnedmonitor_mode2 = GCHandle.Alloc(monitor_mode.FormName);
                    // The second function should only be executed when the first one fails (e.g.
                    // when the monitor is disabled)
                    if (Functions.EnumDisplaySettingsEx(dev1.DeviceName.ToString(), -1, monitor_mode, 0) ||
                        Functions.EnumDisplaySettingsEx(dev1.DeviceName.ToString(), -2, monitor_mode, 0))
                    {
                        VerifyMode(dev1, monitor_mode);

                        float scale = 1;

                        int x = (int)(monitor_mode.Position.X / scale);
                        int y = (int)(monitor_mode.Position.Y / scale);
                        int width = (int)(monitor_mode.PelsWidth / scale);
                        int height = (int)(monitor_mode.PelsHeight / scale);
                        int bpp = monitor_mode.BitsPerPel;
                        int refresh = monitor_mode.DisplayFrequency;
              
                        opentk_dev_current_res = new DisplayResolution(
                            (int)(monitor_mode.Position.X / scale), (int)(monitor_mode.Position.Y / scale),
                            (int)(monitor_mode.PelsWidth / scale), (int)(monitor_mode.PelsHeight / scale),
                            monitor_mode.BitsPerPel, monitor_mode.DisplayFrequency);

                        opentk_dev_primary =
                            (dev1.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) != DisplayDeviceStateFlags.None;
                    }
                    opentk_dev_available_res.Clear();
                  
                    Pinnedmonitor_mode2.Free();
                    Pinnedmonitor_mode.Free();
                    // Construct the OpenTK DisplayDevice through the accumulated parameters. The
                    // constructor will automatically add the DisplayDevice to the list of available devices.
                    opentk_dev = new DisplayDevice(
                        opentk_dev_current_res,
                        opentk_dev_primary,
                        opentk_dev_available_res,
                        opentk_dev_current_res.Bounds,
                        dev1.DeviceName);

                    foreach (DisplayDevice existingDevice in previousDevices)
                        if ((string)existingDevice.Id == (string)opentk_dev.Id)
                            opentk_dev.OriginalResolution = existingDevice.OriginalResolution;

                    AvailableDevices.Add(opentk_dev);

                    if (opentk_dev_primary)
                        Primary = opentk_dev;
                    Debug.Print("DisplayDevice {0} ({1}) supports {2} resolutions.",
                        device_count, opentk_dev.IsPrimary ? "primary" : "secondary", opentk_dev.AvailableResolutions.Count);
                }
                Pinneddev1.Free();
            }
        }

        private float GetScale(ref DeviceMode monitor_mode)
        {
            float scale = 1.0f;
            if ((monitor_mode.Fields & Constants.DM_LOGPIXELS) != 0)
            {
                scale = monitor_mode.LogPixels / 96.0f;
            }
            return scale;
        }

        private static void VerifyMode(WindowsDisplayDevice device, DeviceMode mode)
        {
            if (mode.BitsPerPel == 0)
            {
                Debug.Print(
                    "[Warning] DisplayDevice '{0}' reported a mode with 0 bpp. Please create a bug report at http://www.opentk.com",
                    device.DeviceName.ToString());
                mode.BitsPerPel = 32;
            }
        }

        #endregion RefreshDisplayDevices

        #region HandleDisplaySettingsChanged

        private void HandleDisplaySettingsChanged(object sender, EventArgs e)
        {
            RefreshDisplayDevices();
        }

        #endregion HandleDisplaySettingsChanged

        ~WinDisplayDeviceDriver()
        {
            SystemEvents.DisplaySettingsChanged -=
                HandleDisplaySettingsChanged;
        }

        #endregion Private Members
    }
}