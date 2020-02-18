using Se7en.Mathematic;
using Se7en.Windows.Api;
using Se7en.Windows.Api.Enum;
using Se7en.Windows.Api.Native;

using System;
using System.ComponentModel;

namespace Se7en.Windows
{
    public static class SystemInformation
    {
        private static bool checkMultiMonitorSupport = false;
        private static bool multiMonitorSupport = false;
        private static bool checkNativeMouseWheelSupport = false;
        private static bool nativeMouseWheelSupport = true;
        /// <summary>
        /// Gets a value indicating whether the user has enabled full window drag.
        /// </summary>
        public static bool DragFullWindows {
            get {
                int data = 0;
                User32.SystemParametersInfo(SPI.SPI_GETDRAGFULLWINDOWS, 0, ref data, 0);
                return data != 0;
            }
        }
        
        /// <summary>
        /// Gets the dimensions of the primary display monitor in pixels.
        /// </summary>
        public static Vector2i PrimaryMonitorSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXSCREEN), User32.GetSystemMetrics(SystemMetric.SM_CYSCREEN));
        
        /// <summary>
        /// Gets the width of the vertical scroll bar in pixels.
        /// </summary>
        public static int VerticalScrollBarWidth => User32.GetSystemMetrics(SystemMetric.SM_CXVSCROLL);
        
        /// <summary>
        /// Gets the height of the horizontal scroll bar in pixels.
        /// </summary>
        public static int HorizontalScrollBarHeight => User32.GetSystemMetrics(SystemMetric.SM_CYHSCROLL);
        
        /// <summary>
        /// Gets the height of the normal caption area of a window in pixels.
        /// </summary>
        public static int CaptionHeight => User32.GetSystemMetrics(SystemMetric.SM_CYCAPTION);
        
        /// <summary>
        /// Gets the width and height of a window border in pixels.
        /// </summary>
        public static Vector2i BorderSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXBORDER), User32.GetSystemMetrics(SystemMetric.SM_CYBORDER));
        
        /// <summary>
        /// Gets the thickness in pixels, of the border for a window that has a caption
        /// and is not resizable.
        /// </summary>
        public static Vector2i FixedFrameBorderSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXFIXEDFRAME), User32.GetSystemMetrics(SystemMetric.SM_CYFIXEDFRAME));
        
        /// <summary>
        /// Gets the height of the scroll box in a vertical scroll bar in pixels.
        /// </summary>
        public static int VerticalScrollBarThumbHeight => User32.GetSystemMetrics(SystemMetric.SM_CYVTHUMB);
        
        /// <summary>
        /// Gets the width of the scroll box in a horizontal scroll bar in pixels.
        /// </summary>
        public static int HorizontalScrollBarThumbWidth => User32.GetSystemMetrics(SystemMetric.SM_CXHTHUMB);

        /// <summary>
        /// Gets the default dimensions of an icon in pixels.
        /// </summary>
        public static Vector2i IconSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXICON), User32.GetSystemMetrics(SystemMetric.SM_CYICON));

        /// <summary>
        /// Gets the dimensions of a cursor in pixels.
        /// </summary>
        public static Vector2i CursorSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXCURSOR), User32.GetSystemMetrics(SystemMetric.SM_CYCURSOR));

        /// <summary>
        /// Gets the height of a one line of a menu in pixels.
        /// </summary>
        public static int MenuHeight => User32.GetSystemMetrics(SystemMetric.SM_CYMENU);

        /// <summary>
        /// Gets the Vector2i of the working area in pixels.
        /// </summary>
        public static Rect WorkingArea {
            get {
                Rect rc = new Rect();
                User32.SystemParametersInfo(SPI.SPI_GETWORKAREA, 0, ref rc, 0);
                return rc;
            }
        }
        
        /// <summary>
        /// Gets the height, in pixels, of the Kanji window at the bottom
        /// of the screen for double-byte (DBCS) character set versions of Windows.
        /// </summary>
        public static int KanjiWindowHeight => User32.GetSystemMetrics(SystemMetric.SM_CYKANJIWINDOW);
        
        /// <summary>
        /// Gets a value indicating whether the system has a mouse installed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool MousePresent => User32.GetSystemMetrics(SystemMetric.SM_MOUSEPRESENT) != 0;
        
        /// <summary>
        /// Gets the height in pixels, of the arrow bitmap on the vertical scroll bar.
        /// </summary>
        public static int VerticalScrollBarArrowHeight => User32.GetSystemMetrics(SystemMetric.SM_CYVSCROLL);

        /// <summary>
        /// Gets the width, in pixels, of the arrow bitmap on the horizontal scrollbar.
        /// </summary>
        public static int HorizontalScrollBarArrowWidth => User32.GetSystemMetrics(SystemMetric.SM_CXHSCROLL);

        /// <summary>
        /// Gets a value indicating whether the functions of the left and right mouse buttons have been swapped.
        /// </summary>
        public static bool MouseButtonsSwapped => User32.GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) != 0;
        
        /// <summary>
        /// Gets the minimum allowable dimensions of a window in pixels.
        /// </summary>
        public static Vector2i MinimumWindowSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMIN), User32.GetSystemMetrics(SystemMetric.SM_CYMIN));

        /// <summary>
        /// Gets the dimensions in pixels, of a caption bar or title bar button.
        /// </summary>
        public static Vector2i CaptionButtonSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXSIZE), User32.GetSystemMetrics(SystemMetric.SM_CYSIZE));
        
        /// <summary>
        /// Gets the thickness in pixels, of the border for a window that can be resized.
        /// </summary>
        public static Vector2i FrameBorderSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXFRAME), User32.GetSystemMetrics(SystemMetric.SM_CYFRAME));

        /// <summary>
        /// Gets the system's default minimum tracking dimensions of a window in pixels.
        /// </summary>
        public static Vector2i MinWindowTrackSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMINTRACK), User32.GetSystemMetrics(SystemMetric.SM_CYMINTRACK));
        
        /// <summary>
        /// Gets the dimensions in pixels, of the area that the user must click within
        /// for the system to consider the two clicks a double-click. The rectangle is
        /// centered around the first click.
        /// </summary>
        public static Vector2i DoubleClickSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXDOUBLECLK), User32.GetSystemMetrics(SystemMetric.SM_CYDOUBLECLK));
        
        /// <summary>
        /// Gets the maximum number of milliseconds allowed between mouse clicks for a double-click.
        /// </summary>
        public static int DoubleClickTime => User32.GetDoubleClickTime();

        /// <summary>
        /// Gets the dimensions in pixels, of the grid used to arrange icons in a large icon view.
        /// </summary>
        public static Vector2i IconSpacingSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXICONSPACING), User32.GetSystemMetrics(SystemMetric.SM_CYICONSPACING));

        /// <summary>
        /// Gets a value indicating whether drop down menus should be right-aligned with the corresponding menu bar item.
        /// </summary>
        public static bool RightAlignedMenus => User32.GetSystemMetrics(SystemMetric.SM_MENUDROPALIGNMENT) != 0;

        /// <summary>
        /// Gets a value indicating whether the Microsoft Windows for Pen computing extensions are installed.
        /// </summary>
        public static bool PenWindows => User32.GetSystemMetrics(SystemMetric.SM_PENWINDOWS) != 0;

        /// <summary>
        /// Gets a value indicating whether the operating system is capable of handling double-byte (DBCS) characters.
        /// </summary>
        public static bool DbcsEnabled => User32.GetSystemMetrics(SystemMetric.SM_DBCSENABLED) != 0;

        /// <summary>
        /// Gets the number of buttons on mouse.
        /// </summary>
        public static int MouseButtons => User32.GetSystemMetrics(SystemMetric.SM_CMOUSEBUTTONS);
        /// <summary>
        /// Gets a value indicating whether security is present on this operating system.
        /// </summary>
        public static bool Secure => User32.GetSystemMetrics(SystemMetric.SM_SECURE) != 0;

        /// <summary>
        /// Gets the dimensions in pixels, of a 3-D  border.
        /// </summary>
        public static Vector2i Border3DSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXEDGE), User32.GetSystemMetrics(SystemMetric.SM_CYEDGE));

        /// <summary>
        /// in pixels, of the grid into which minimized windows will be placed.
        /// </summary>
        public static Vector2i MinimizedWindowSpacingSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMINSPACING), User32.GetSystemMetrics(SystemMetric.SM_CYMINSPACING));

        /// <summary>
        /// Gets the recommended dimensions of a small icon in pixels.
        /// </summary>
        public static Vector2i SmallIconSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXSMICON), User32.GetSystemMetrics(SystemMetric.SM_CYSMICON));

        /// <summary>
        /// Gets the height of a small caption in pixels.
        /// </summary>
        public static int ToolWindowCaptionHeight => User32.GetSystemMetrics(SystemMetric.SM_CYSMCAPTION);

        /// <summary>
        /// Gets the dimensions of small caption buttons in pixels.
        /// </summary>
        public static Vector2i ToolWindowCaptionButtonSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXSMSIZE), User32.GetSystemMetrics(SystemMetric.SM_CYSMSIZE));

        /// <summary>
        /// Gets the dimensions in pixels, of menu bar buttons.
        /// </summary>
        public static Vector2i MenuButtonSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMENUSIZE), User32.GetSystemMetrics(SystemMetric.SM_CYMENUSIZE));
        
        /// <summary>
        /// Gets flags specifying how the system arranges minimized windows.
        /// </summary>
        public static ArrangeDirection ArrangeDirection => (ArrangeDirection.Down | ArrangeDirection.Left | ArrangeDirection.Right | ArrangeDirection.Up) & (ArrangeDirection)User32.GetSystemMetrics(SystemMetric.SM_ARRANGE);
        
        /// <summary>
        /// Gets the dimensions in pixels, of a normal minimized window.
        /// </summary>
        public static Vector2i MinimizedWindowSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMINIMIZED), User32.GetSystemMetrics(SystemMetric.SM_CYMINIMIZED));

        /// <summary>
        /// Gets the default maximum dimensions in pixels, of a
        /// window that has a caption and sizing borders.
        /// </summary>
        public static Vector2i MaxWindowTrackSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMAXTRACK), User32.GetSystemMetrics(SystemMetric.SM_CYMAXTRACK));

        /// <summary>
        /// Gets the default dimensions, in pixels, of a maximized top-left window on the primary monitor.
        /// </summary>
        public static Vector2i PrimaryMonitorMaximizedWindowSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMAXIMIZED), User32.GetSystemMetrics(SystemMetric.SM_CYMAXIMIZED));

        /// <summary>
        /// Gets a value indicating whether this computer is connected to a network.
        /// </summary>
        public static bool Network => (User32.GetSystemMetrics(SystemMetric.SM_NETWORK) & 0x00000001) != 0;

        /// <summary>
        /// To be supplied.
        /// </summary>
        public static bool TerminalServerSession => (User32.GetSystemMetrics(SystemMetric.SM_REMOTESESSION) & 0x00000001) != 0;

        /// <summary>
        /// Gets a value that specifies how the system was started.
        /// </summary>
        public static BootMode BootMode => (BootMode)User32.GetSystemMetrics(SystemMetric.SM_CLEANBOOT);

        /// <summary>
        /// Gets the dimensions in pixels, of the rectangle that a drag operation
        /// must extend to be considered a drag. The rectangle is centered on a drag point.
        /// </summary>
        public static Vector2i DragSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXDRAG),
                                User32.GetSystemMetrics(SystemMetric.SM_CYDRAG));

        /// <summary>
        /// Gets a value indicating whether the user requires an application to present
        /// information visually in situations where it would otherwise present the
        /// information in audible form.
        /// </summary>
        public static bool ShowSounds => User32.GetSystemMetrics(SystemMetric.SM_SHOWSOUNDS) != 0;

        /// <summary>
        /// Gets the dimensions of the default Vector2i of a menu checkmark in pixels.
        /// </summary>
        public static Vector2i MenuCheckSize => new Vector2i(User32.GetSystemMetrics(SystemMetric.SM_CXMENUCHECK), User32.GetSystemMetrics(SystemMetric.SM_CYMENUCHECK));

        /// <summary>
        /// Gets a value indicating whether the system is enabled for Hebrew and Arabic languages.
        /// </summary>
        public static bool MidEastEnabled => User32.GetSystemMetrics(SystemMetric.SM_MIDEASTENABLED) != 0;
        private static bool MultiMonitorSupport {
            get {
                if (!checkMultiMonitorSupport)
                {
                    multiMonitorSupport = User32.GetSystemMetrics(SystemMetric.SM_CMONITORS) != 0;
                    checkMultiMonitorSupport = true;
                }
                return multiMonitorSupport;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the system natively supports the mouse wheel in newer mice.
        /// </summary>
        public static bool NativeMouseWheelSupport {
            get {
                if (!checkNativeMouseWheelSupport)
                {
                    nativeMouseWheelSupport = User32.GetSystemMetrics(SystemMetric.SM_MOUSEWHEELPRESENT) != 0;
                    checkNativeMouseWheelSupport = true; 
                }
                return nativeMouseWheelSupport;
            }
        }


        /// <summary>
        /// Gets a value indicating whether there is a mouse with a mouse wheel installed on this machine.
        /// </summary>
        public static bool MouseWheelPresent {
            get {

                bool mouseWheelPresent = false;

                if (!NativeMouseWheelSupport)
                {
                    if (User32.FindWindow(NativeKeys.MOUSEZ_CLASSNAME, NativeKeys.MOUSEZ_TITLE) != IntPtr.Zero)
                    {
                        mouseWheelPresent = true;
                    }
                }
                else
                {
                    mouseWheelPresent = User32.GetSystemMetrics(SystemMetric.SM_MOUSEWHEELPRESENT) != 0;
                }
                return mouseWheelPresent;
            }
        }

        /// <summary>
        /// Gets the bounds of the virtual screen.
        /// </summary>
        public static Rect VirtualScreen 
            => MultiMonitorSupport
                    ? new Rect(
                            User32.GetSystemMetrics(SystemMetric.SM_XVIRTUALSCREEN),
                            User32.GetSystemMetrics(SystemMetric.SM_YVIRTUALSCREEN),
                            User32.GetSystemMetrics(SystemMetric.SM_CXVIRTUALSCREEN),
                            User32.GetSystemMetrics(SystemMetric.SM_CYVIRTUALSCREEN)
                        )
                    : new Rect(PrimaryMonitorSize);

        /// <summary>
        /// Gets the number of display monitors on the desktop.
        /// </summary>
        public static int MonitorCount => MultiMonitorSupport ? User32.GetSystemMetrics(SystemMetric.SM_CMONITORS) : 1;

        /// <summary>
        /// Gets a value indicating whether all the display monitors have the same color format.
        /// </summary>
        public static bool MonitorsSameDisplayFormat => MultiMonitorSupport ? User32.GetSystemMetrics(SystemMetric.SM_SAMEDISPLAYFORMAT) != 0 : true;


    }
}
