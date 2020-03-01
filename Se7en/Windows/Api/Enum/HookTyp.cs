﻿namespace Se7en.Windows.Api.Enum
{
    public enum HookTyp
    {
        /// <summary>
        /// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar.
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// Installs a hook procedure that records input messages posted to the system message queue. This hook is useful for recording macros.
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// Installs a hook procedure that posts messages previously recorded by a WH_JOURNALRECORD hook procedure.
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// nstalls a hook procedure that monitors keystroke messages.
        /// </summary>
        WH_KEYBOARD = 2,
        /// <summary>
        /// Installs a hook procedure that monitors messages posted to a message queue.
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// Installs a hook procedure that monitors messages before the system sends them to the destination window procedure.
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// Installs a hook procedure that receives notifications useful to a CBT application.
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar.<br/>
        /// The hook procedure monitors these messages for all applications in the same desktop as the calling thread. 
        /// </summary>
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// Installs a hook procedure that monitors mouse messages. 
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        /// A nonstandard hardware message hook called whenever the application calls the GetMessage() or PeekMessage() function and there is a hardware event (other than a mouse or keyboard event) to process.
        /// </summary>
        WH_HARDWARE = 8,
        /// <summary>
        /// Installs a hook procedure useful for debugging other hook procedures.
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// Installs a hook procedure that receives notifications useful to shell applications. 
        /// </summary>
        WH_SHELL = 10,
        /// <summary>
        /// Installs a hook procedure that will be called when the application's foreground thread is about to become idle.<br/>
        /// This hook is useful for performing low priority tasks during idle time.
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// Installs a hook procedure that monitors messages after they have been processed by the destination window procedure.
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
        WH_CALLWNDPROCRET = 12,
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
        /// <summary>
        /// Installs a hook procedure that monitors low-level keyboard input events.
        /// </summary>
        WH_KEYBOARD_LL = 13,
        /// <summary>
        /// Installs a hook procedure that monitors low-level mouse input events. 
        /// </summary>
        WH_MOUSE_LL = 14
    }
}
