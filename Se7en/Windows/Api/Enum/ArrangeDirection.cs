#if Windows
using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api.Enum
{
    [ComVisible(true)]
    [Flags]
    public enum ArrangeDirection
    {

        /// <summary>
        /// Arranges vertically, from top to bottom.
        /// </summary>
        Down = 0x0004,

        /// <summary>
        /// Arranges horizontally, from left to right.
        /// </summary>
        Left = 0x0000,

        /// <summary>
        /// Arranges horizontally, from right to left.
        /// </summary>
        Right = 0x0000,

        /// <summary>
        /// Arranges vertically, from bottom to top.
        /// </summary>
        Up = 0x0004,
    }
}
#endif