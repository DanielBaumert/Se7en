using Se7en.WinApi;

namespace Se7en {
    public struct MonitorEx {
        public readonly MonitorInfoEx MonitorInfo;
        public int X => MonitorInfo.Monitor.Left;
        public int Y => MonitorInfo.Monitor.Top;
        public int Width => MonitorInfo.Monitor.Right - MonitorInfo.Monitor.Left;
        public int Height => MonitorInfo.Monitor.Bottom - MonitorInfo.Monitor.Top;

        public bool IsPrimary => MonitorInfo.Flags.ToBool();
        public MonitorEx(MonitorInfoEx monitorInfo) {
            MonitorInfo = monitorInfo;
        }
    }
}
