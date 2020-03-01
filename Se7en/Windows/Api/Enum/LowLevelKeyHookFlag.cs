
namespace Se7en.Windows.Api.Enum
{
    public enum LowLevelKeyHookFlag
    {
        /// <summary>
        /// Test the extended-key flag.
        /// </summary>
        LLKHF_EXTENDED = (KeyFlags.KF_EXTENDED >> 8),
        /// <summary>
        /// Test the event-injected (from a process running at lower integrity level) flag.
        /// </summary>
        LLKHF_LOWER_IL_INJECTED = 0x00000002,
        /// <summary>
        /// Test the event-injected (from any process) flag.
        /// </summary>
        LLKHF_INJECTED = 0x00000010,
        /// <summary>
        /// Test the context code.
        /// </summary>
        LLKHF_ALTDOWN = (KeyFlags.KF_ALTDOWN >> 8),
        /// <summary>
        /// Test the transition-state flag.
        /// </summary>
        LLKHF_UP = (KeyFlags.KF_UP >> 8)
    }
}
