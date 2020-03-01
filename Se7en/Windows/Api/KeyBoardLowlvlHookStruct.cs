using Se7en.Windows.Api.Enum;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    /// <summary>
    /// Contains information about a low-level keyboard input event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KeyBoardLowlevelHookStruct
    {
        /// <summary>
        /// A virtual-key code. The code must be a value in the range 1 to 254.
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public VirtualKey VkCode;
        /// <summary>
        /// A hardware scan code for the key.
        /// </summary>
        public int ScanCode;
        /// <summary>
        /// The extended-key flag, event-injected flags, context code, and transition-state flag. This member is specified as follows.<br/>
        /// An application can use the following values to test the keystroke flags.<br/>
        /// Testing LLKHF_INJECTED (bit 4) will tell you whether the event was injected.<br/>
        /// If it was, then testing LLKHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not the event was injected from a process running at lower integrity level.
        /// </summary>
        /// <remarks>
        /// | Bit 0 - Specifies whether the key is an extended key, such as a function key or a key on the numeric keypad.<br/> 
        ///           The value is 1 if the key is an extended key; otherwise, it is 0.<br/>
        /// | Bit 1 - Specifies whether the event was injected from a process running at lower integrity level. <br/>
        ///           The value is 1 if that is the case; otherwise, it is 0. Note that bit 4 is also set whenever bit 1 is set.<br/>
        /// | Bit 2-3 - Reserved.<br/>
        /// | Bit 4 - Specifies whether the event was injected. <br/>
        ///           The value is 1 if that is the case; otherwise, it is 0. <br/>
        ///           Note that bit 1 is not necessarily set when bit 4 is set.<br/>
        /// | Bit 5 - The context code. <br/>
        ///           The value is 1 if the ALT key is pressed; otherwise, it is 0.<br/>
        /// | Bit 6 - Reserved.<br/>
        /// | Bit 7 - The transition state. <br/>
        ///           The value is 0 if the key is pressed and 1 if it is being released.<br/>
        ///</remarks>
        [MarshalAs(UnmanagedType.I4)]
        public LowLevelKeyHookFlag Flags;
        /// <summary>
        /// The time stamp for this message, equivalent to what GetMessageTime would return for this message.
        /// </summary>
        public int Time;
        /// <summary>
        /// Additional information associated with the message.
        /// </summary>
        public ulong DwExtraInfo;
    }
}
