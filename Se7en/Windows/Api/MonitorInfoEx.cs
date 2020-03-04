#if Windows
using Se7en.Mathematic;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api
{
    /// <summary>
    /// The MONITORINFOEX structure contains information about a display monitor.
    /// The GetMonitorInfo function stores information into a MONITORINFOEX structure or a MONITORINFO structure.
    /// The MONITORINFOEX structure is a superset of the MONITORINFO structure. The MONITORINFOEX structure adds a string member to contain a name
    /// for the display monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MonitorInfoEx
    {
        /// <summary>
        /// size of a device name string
        /// </summary>
        public const int CCHDEVICENAME = 32;
        /// <summary>
        /// The MONITORINFO structure contains information about a display monitor.
        /// </summary>
        public MonitorInfo MonitorInfo;
        /// <summary>
        /// A string that specifies the device name of the monitor being used. Most applications have no use for a display monitor name,
        /// and so can save some bytes by using a MONITORINFO structure.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        public string DeviceName;

        public Rect WorkingArea => MonitorInfo.WorkArea;
        public Rect Bounds => MonitorInfo.Monitor;
        public bool IsPrimary => MonitorInfo.IsPrimary;

        public void Init()
        {
            MonitorInfo.Size = 40 + 2 * CCHDEVICENAME;
            DeviceName = string.Empty;
        }
    }
}
#endif