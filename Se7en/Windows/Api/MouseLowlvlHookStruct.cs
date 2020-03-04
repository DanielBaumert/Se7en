#if Windows
using Se7en.Mathematic;
using Se7en.Windows.Api.Enum;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    /// <summary>
    /// Contains information about a low-level mouse input event.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct MouseLowlevelHookStruct
    {

        /// <summary>
        /// The x- and y-coordinates of the cursor, in per-monitor-aware screen coordinates.
        /// </summary>
        [FieldOffset(0)]
        public Vector2i Point;
        /// <summary>
        /// The x-coordinates of the cursor, in per-monitor-aware screen coordinates.
        /// </summary>
        [FieldOffset(0)]
        public int X;
        /// <summary>
        /// The y-coordinates of the cursor, in per-monitor-aware screen coordinates.
        /// </summary>
        [FieldOffset(4)]
        public int Y;
        /// <summary>
        /// If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta.<br/>
        /// The low-order word is reserved.<br/>
        /// A positive value indicates that the wheel was rotated forward, away from the user;<br/>
        /// a negative value indicates that the wheel was rotated backward, toward the user.<br/>
        /// One wheel click is defined as WHEEL_DELTA, which is 120.<para/>
        /// If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK,<br/>
        /// the high-order word specifies which X button was pressed or released, and the low-order word is reserved. <br/>
        /// This value can be one or more of the following values.Otherwise, mouseData is not used.
        /// </summary>
        [FieldOffset(8)]
        public int MouseData;
        /// <summary>
        /// If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta.<br/>
        /// The low-order word is reserved.<br/>
        /// A positive value indicates that the wheel was rotated forward, away from the user;<br/>
        /// a negative value indicates that the wheel was rotated backward, toward the user.<br/>
        /// One wheel click is defined as WHEEL_DELTA, which is 120.<para/>
        /// If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK,<br/>
        /// the high-order word specifies which X button was pressed or released, and the low-order word is reserved. <br/>
        /// This value can be one or more of the following values.Otherwise, mouseData is not used.
        /// </summary>
        [FieldOffset(8)]
        public MouseDataValue MouseData1;
        /// <summary>
        /// The event-injected flags. An application can use the following values to test the flags.<br/>
        /// Testing LLMHF_INJECTED (bit 0) will tell you whether the event was injected.<br/>
        /// If it was, then testing LLMHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not the event was injected from a process running at lower integrity level.
        /// </summary>
        [FieldOffset(12)]
        [MarshalAs(UnmanagedType.I4)]
        public LowLevelMouseHookFlag Flag;
        /// <summary>
        /// The time stamp for this message, equivalent to what GetMessageTime would return for this message.
        /// </summary>
        [FieldOffset(16)]
        public int Time;
        /// <summary>
        /// Additional information associated with the message.
        /// </summary>
        [FieldOffset(20)]
        public ulong DwExtraInfo;
    }
}
#endif