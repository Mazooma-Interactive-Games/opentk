#region --- License ---

/* Licensed under the MIT/X11 license.
 * Copyright (c) 2006-2008 the OpenTK Team.
 * This notice may not be removed from any source distribution.
 * See license.txt for licensing detailed licensing details.
 */

#endregion --- License ---

using System;
using System.Diagnostics;

namespace OpenTK.Graphics
{
    /// <summary> Defines the format for graphics operations. </summary>
    public class GraphicsMode : IEquatable<GraphicsMode>
    {
        private ColorFormat color_format, accumulator_format;
        private int depth, stencil, buffers, samples;
        private bool stereo;
        private IntPtr? index = null;  // The id of the pixel format or visual.

        private static GraphicsMode defaultMode;
        private static readonly object SyncRoot = new object();

        #region Constructors

        // Disable BeforeFieldInit 
        static GraphicsMode()
        {
        }

        #region internal GraphicsMode(GraphicsMode mode)

        internal GraphicsMode(GraphicsMode mode)
            : this(mode.ColorFormat, mode.Depth, mode.Stencil, mode.Samples, mode.AccumulatorFormat, mode.Buffers, mode.Stereo) { }

        #endregion internal GraphicsMode(GraphicsMode mode)

        #region internal GraphicsMode(IntPtr? index, ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)

        internal GraphicsMode(IntPtr? index, ColorFormat color, int depth, int stencil, int samples, ColorFormat accum,
                              int buffers, bool stereo)
        {
            if (depth < 0) throw new ArgumentOutOfRangeException("depth", "Must be greater than, or equal to zero.");
            if (stencil < 0) throw new ArgumentOutOfRangeException("stencil", "Must be greater than, or equal to zero.");
            if (buffers < 0) throw new ArgumentOutOfRangeException("buffers", "Must be greater than, or equal to zero.");
            if (samples < 0) throw new ArgumentOutOfRangeException("samples", "Must be greater than, or equal to zero.");

            this.Index = index;
            this.ColorFormat = color;
            this.Depth = depth;
            this.Stencil = stencil;
            this.Samples = samples;
            this.AccumulatorFormat = accum;
            this.Buffers = buffers;
            this.Stereo = stereo;
        }

        #endregion internal GraphicsMode(IntPtr? index, ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)

        #region public GraphicsMode()

        /// <summary> Constructs a new GraphicsMode with sensible default parameters. </summary>
        public GraphicsMode()
            : this(Default)
        { }

        #endregion public GraphicsMode()

        #region public GraphicsMode(ColorFormat color)

        /// <summary> Constructs a new GraphicsMode with the specified parameters. </summary>
        /// <param name="color"> The ColorFormat of the color buffer. </param>
        public GraphicsMode(ColorFormat color)
            : this(color, Default.Depth, Default.Stencil, Default.Samples, Default.AccumulatorFormat, Default.Buffers, Default.Stereo)
        { }

        #endregion public GraphicsMode(ColorFormat color)

        #region public GraphicsMode(ColorFormat color, int depth)

        /// <summary> Constructs a new GraphicsMode with the specified parameters. </summary>
        /// <param name="color"> The ColorFormat of the color buffer. </param>
        /// <param name="depth"> The number of bits in the depth buffer. </param>
        public GraphicsMode(ColorFormat color, int depth)
            : this(color, depth, Default.Stencil, Default.Samples, Default.AccumulatorFormat, Default.Buffers, Default.Stereo)
        { }

        #endregion public GraphicsMode(ColorFormat color, int depth)

        #region public GraphicsMode(ColorFormat color, int depth, int stencil)

        /// <summary> Constructs a new GraphicsMode with the specified parameters. </summary>
        /// <param name="color">   The ColorFormat of the color buffer. </param>
        /// <param name="depth">   The number of bits in the depth buffer. </param>
        /// <param name="stencil"> The number of bits in the stencil buffer. </param>
        public GraphicsMode(ColorFormat color, int depth, int stencil)
            : this(color, depth, stencil, Default.Samples, Default.AccumulatorFormat, Default.Buffers, Default.Stereo)
        { }

        #endregion public GraphicsMode(ColorFormat color, int depth, int stencil)

        #region public GraphicsMode(ColorFormat color, int depth, int stencil, int samples)

        /// <summary> Constructs a new GraphicsMode with the specified parameters. </summary>
        /// <param name="color">   The ColorFormat of the color buffer. </param>
        /// <param name="depth">   The number of bits in the depth buffer. </param>
        /// <param name="stencil"> The number of bits in the stencil buffer. </param>
        /// <param name="samples"> The number of samples for FSAA. </param>
        public GraphicsMode(ColorFormat color, int depth, int stencil, int samples)
            : this(color, depth, stencil, samples, Default.AccumulatorFormat, Default.Buffers, Default.Stereo)
        { }

        #endregion public GraphicsMode(ColorFormat color, int depth, int stencil, int samples)

        #region public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum)

        /// <summary> Constructs a new GraphicsMode with the specified parameters. </summary>
        /// <param name="color">   The ColorFormat of the color buffer. </param>
        /// <param name="depth">   The number of bits in the depth buffer. </param>
        /// <param name="stencil"> The number of bits in the stencil buffer. </param>
        /// <param name="samples"> The number of samples for FSAA. </param>
        /// <param name="accum">   The ColorFormat of the accumilliary buffer. </param>
        public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum)
            : this(color, depth, stencil, samples, accum, Default.Buffers, Default.Stereo)
        { }

        #endregion public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum)

        #region public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers)

        /// <summary> Constructs a new GraphicsMode with the specified parameters. </summary>
        /// <param name="color">   The ColorFormat of the color buffer. </param>
        /// <param name="depth">   The number of bits in the depth buffer. </param>
        /// <param name="stencil"> The number of bits in the stencil buffer. </param>
        /// <param name="samples"> The number of samples for FSAA. </param>
        /// <param name="accum">   The ColorFormat of the accumilliary buffer. </param>
        /// <param name="buffers">
        /// The number of render buffers. Typical values include one (single-), two (double-) or
        /// three (triple-buffering).
        /// </param>
        public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers)
            : this(color, depth, stencil, samples, accum, buffers, Default.Stereo)
        { }

        #endregion public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers)

        #region public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)

        /// <summary> Constructs a new GraphicsMode with the specified parameters. </summary>
        /// <param name="color">   The ColorFormat of the color buffer. </param>
        /// <param name="depth">   The number of bits in the depth buffer. </param>
        /// <param name="stencil"> The number of bits in the stencil buffer. </param>
        /// <param name="samples"> The number of samples for FSAA. </param>
        /// <param name="accum">   The ColorFormat of the accumilliary buffer. </param>
        /// <param name="stereo">  Set to true for a GraphicsMode with stereographic capabilities. </param>
        /// <param name="buffers">
        /// The number of render buffers. Typical values include one (single-), two (double-) or
        /// three (triple-buffering).
        /// </param>
        public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)
            : this(null, color, depth, stencil, samples, accum, buffers, stereo) { }

        #endregion public GraphicsMode(ColorFormat color, int depth, int stencil, int samples, ColorFormat accum, int buffers, bool stereo)

        #endregion Constructors

        #region --- Public Methods ---

        #region public IntPtr Index

        /// <summary>
        /// Gets a nullable <see cref="System.IntPtr" /> value, indicating the platform-specific
        /// index for this GraphicsMode.
        /// </summary>
        public IntPtr? Index
        {
            get
            {
                return index;
            }
            set { index = value; }
        }

        #endregion public IntPtr Index

        #region public int ColorFormat

        /// <summary>
        /// Gets an OpenTK.Graphics.ColorFormat that describes the color format for this GraphicsFormat.
        /// </summary>
        public ColorFormat ColorFormat
        {
            get
            {
                return color_format;
            }
            internal set { color_format = value; }
        }

        #endregion public int ColorFormat

        #region public int AccumulatorFormat

        /// <summary>
        /// Gets an OpenTK.Graphics.ColorFormat that describes the accumulator format for this GraphicsFormat.
        /// </summary>
        public ColorFormat AccumulatorFormat
        {
            get
            {
                return accumulator_format;
            }
            internal set { accumulator_format = value; }
        }

        #endregion public int AccumulatorFormat

        #region public int Depth

        /// <summary>
        /// Gets a System.Int32 that contains the bits per pixel for the depth buffer for this GraphicsFormat.
        /// </summary>
        public int Depth
        {
            get
            {
                return depth;
            }
            internal set { depth = value; }
        }

        #endregion public int Depth

        #region public int Stencil

        /// <summary>
        /// Gets a System.Int32 that contains the bits per pixel for the stencil buffer of this GraphicsFormat.
        /// </summary>
        public int Stencil
        {
            get
            {
                return stencil;
            }
            internal set { stencil = value; }
        }

        #endregion public int Stencil

        #region public int Samples

        /// <summary>
        /// Gets a System.Int32 that contains the number of FSAA samples per pixel for this GraphicsFormat.
        /// </summary>
        public int Samples
        {
            get
            {
                return samples;
            }
            internal set
            {
                // Clamp antialiasing samples to max 64x This protects against a potential DOS
                // during mode selection, when the user requests an abnormally high AA level.
                samples = MathHelper.Clamp(value, 0, 64);
            }
        }

        #endregion public int Samples

        #region public bool Stereo

        /// <summary> Gets a System.Boolean indicating whether this DisplayMode is stereoscopic. </summary>
        public bool Stereo
        {
            get
            {
                return stereo;
            }
            internal set { stereo = value; }
        }

        #endregion public bool Stereo

        #region public int Buffers

        /// <summary>
        /// Gets a System.Int32 containing the number of buffers associated with this DisplayMode.
        /// </summary>
        public int Buffers
        {
            get
            {
                return buffers;
            }
            internal set { buffers = value; }
        }

        #endregion public int Buffers

        #region public static GraphicsFormat Default

        /// <summary> Returns an OpenTK.GraphicsFormat compatible with the underlying platform. </summary>
        public static GraphicsMode Default
        {
            get
            {
                lock (SyncRoot)
                {
                    if (defaultMode == null)
                    {
                        defaultMode = new GraphicsMode(null, 32, 16, 0, 0, 0, 2, false);
                        Debug.Print("GraphicsMode.Default = {0}", defaultMode.ToString());
                    }
                    return defaultMode;
                }
            }
        }

        #endregion public static GraphicsFormat Default

        #endregion --- Public Methods ---

        #region --- Overrides ---

        /// <summary> Returns a System.String describing the current GraphicsFormat. </summary>
        /// <returns> ! System.String describing the current GraphicsFormat. </returns>
        public override string ToString()
        {
            return String.Format("Index: {0}, Color: {1}, Depth: {2}, Stencil: {3}, Samples: {4}, Accum: {5}, Buffers: {6}, Stereo: {7}",
                Index, ColorFormat, Depth, Stencil, Samples, AccumulatorFormat, Buffers, Stereo);
        }

        /// <summary> Returns the hashcode for this instance. </summary>
        /// <returns> A <see cref="System.Int32" /> hashcode for this instance. </returns>
        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        /// <summary> Indicates whether obj is equal to this instance. </summary>
        /// <param name="obj"> An object instance to compare for equality. </param>
        /// <returns> True, if obj equals this instance; false otherwise. </returns>
        public override bool Equals(object obj)
        {
            if (obj is GraphicsMode)
            {
                return Equals((GraphicsMode)obj);
            }
            return false;
        }

        #endregion --- Overrides ---

        #region IEquatable<GraphicsMode> Members

        /// <summary> Indicates whether other represents the same mode as this instance. </summary>
        /// <param name="other"> The GraphicsMode to compare to. </param>
        /// <returns> True, if other is equal to this instance; false otherwise. </returns>
        public bool Equals(GraphicsMode other)
        {
            return Index.HasValue && Index == other.Index;
        }

        #endregion IEquatable<GraphicsMode> Members
    }
}