#region --- License ---
/* Copyright (c) 2006, 2007 Stefanos Apostolopoulos
 * See license.txt for license info
 */
#endregion

using System;
using System.Collections.Generic;

namespace OpenTK.Input
{
    /// <summary>
    /// Defines the interface for MouseDevice drivers.
    /// </summary>
    [Obsolete]
    public interface IMouseDriver
    {
        /// <summary>
        /// Gets the list of available MouseDevices.
        /// </summary>
        IList<MouseDevice> Mouse { get; }
    }
}
