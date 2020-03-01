using System;
using System.Collections.Generic;
using System.Text;

namespace Se7en.Windows.Api.Enum
{
    [Flags]
    public enum KeyFlags : int
    {
        /// <summary>
        /// Manipulates the extended key flag.
        /// </summary>
        KF_EXTENDED = 0x0100,
        /// <summary>
        /// Manipulates the dialog mode flag, which indicates whether a dialog box is active.
        /// </summary>
        KF_DLGMODE = 0x0800,
        /// <summary>
        /// Manipulates the menu mode flag, which indicates whether a menu is active.
        /// </summary>
        KF_MENUMODE = 0x1000,
        /// <summary>
        /// Manipulates the ALT key flag, which indicated if the ALT key is pressed.
        /// </summary>
        KF_ALTDOWN = 0x2000,
        /// <summary>
        /// Manipulates the repeat count.
        /// </summary>
        KF_REPEAT = 0x4000,
        /// <summary>
        /// Manipulates the transition state flag.
        /// </summary>
        KF_UP = 0x8000
    }

}
