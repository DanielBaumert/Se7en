#if Windows
using System;
using System.Collections.Generic;
using System.Text;

namespace Se7en.Windows.Api.Enum
{
    /// <summary>
    /// The identifier of the keyboard message
    /// </summary>
    public enum KeyboardButtonsState
    {
        /// <summary>
        /// Posted to the window with the keyboard focus when a nonsystem key is pressed.<br/>
        /// A nonsystem key is a key that is pressed when the ALT key is not pressed.
        /// </summary>
        WM_KEYDOWN = 0x100,
        /// <summary>
        /// Posted to the window with the keyboard focus when a nonsystem key is released.<br/>
        ///  A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus.
        /// </summary>
        WM_KEYUP = 0x101,
        /// <summary>
        /// Posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key.<br/>
        ///  It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window.<br/>
        ///  The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
        /// </summary>
        WM_SYSKEYDOWN = 0x104,
        /// <summary>
        /// Posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down.<br/>
        ///  It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window.<br/>
        ///  The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
        /// </summary>
        WM_SYSKEYUP = 0x105
    }
}
#endif