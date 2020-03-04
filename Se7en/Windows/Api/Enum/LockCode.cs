#if Windows
namespace Se7en.Windows.Api.Enum
{
    public enum LockCode : uint
    {
        /// <summary>
        /// Disables calls to SetForegroundWindow.
        /// </summary>
        LOCK    = 1,
        /// <summary>
        /// Enables calls to SetForegroundWindow.
        /// </summary>
        UNLOCK  = 2
    }


}
#endif