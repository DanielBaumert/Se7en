#if Windows
using Se7en.Mathematic;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    [StructLayout(LayoutKind.Sequential, Size = 59)]
    public struct PaintStruct 
    {
        /// <summary>
        /// A handle to the display DC to be used for painting.
        /// </summary>
        public HDc Hdc;
        /// <summary>
        /// Indicates whether the background must be erased.<br/>
        /// This value is nonzero if the application should erase the background.<br/>
        /// The application is responsible for erasing the background if a window class is created without a background brush.<br/>
        /// For more information, see the description of the hbrBackground member of the WNDCLASS structure.
        /// </summary>
        public bool Erase;
        /// <summary>
        /// A Rect structure that specifies the upper left and lower right corners of the rectangle in which the painting is requested,<br/>
        /// in device units relative to the upper-left corner of the client area.
        /// </summary>
        public Rect Paint;
        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        public bool Restore;
        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        public bool IncUpdate;
        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] rgbReserved;
    }
}
#endif