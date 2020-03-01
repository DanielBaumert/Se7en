
namespace Se7en.Windows.Api.Enum
{
    /// <summary>
    /// The identifier of the mouse message on Hook
    /// </summary>
    public enum MouseButtonsState
    {
        /// <summary>
        /// Posted when the user presses the left mouse button while the cursor is in the client area of a window.<br/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<br/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_LBUTTONDOWN =  0x0201,
        /// <summary>
        /// Posted when the user releases the left mouse button while the cursor is in the client area of a window.<br/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<br/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_LBUTTONUP =  0x0202,
        /// <summary>
        /// Posted to a window when the cursor moves.<br/>
        /// If the mouse is not captured, the message is posted to the window that contains the cursor.<br/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_MOUSEMOVE = 0x0200,
        /// <summary>
        /// Sent to the focus window when the mouse wheel is rotated.<br/>
        /// The DefWindowProc function propagates the message to the window's parent.<br/>
        /// There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        WM_MOUSEWHEEL = 0x020A,
        /// <summary>
        /// Sent to the active window when the mouse's horizontal scroll wheel is tilted or rotated.<br/>
        /// The DefWindowProc function propagates the message to the window's parent.<br/>
        /// There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        WM_MOUSEHWHEEL = 0x020E,
        /// <summary>
        /// Posted when the user presses the right mouse button while the cursor is in the client area of a window.<br/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<br/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_RBUTTONDOWN =  0x0206,
        /// <summary>
        /// Posted when the user releases the right mouse button while the cursor is in the client area of a window.<br/>
        /// If the mouse is not captured, the message is posted to the window beneath the cursor.<br/>
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        WM_RBUTTONUP =  0x0207,

    }
}
