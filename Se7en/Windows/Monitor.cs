using Se7en.Mathematic;
using Se7en.Windows.Api;
using Se7en.Windows.Api.Native;
using System;
using System.Collections;

namespace Se7en.Windows
{
    public static class Monitor
    {
        public static Vector2i PrimaryMonitorSize => SystemInformation.PrimaryMonitorSize;
        public static int MonitorCount => SystemInformation.MonitorCount;
        public static bool MultiMonitorSupport => MonitorCount != 0;
        public static Rect VirtualScreen => SystemInformation.VirtualScreen;

        public static MonitorInfoEx[] AllMonitors {
            get {

                ArrayList monitorArry = new ArrayList(MonitorCount);
                User32.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorExEnumProc, IntPtr.Zero);
                return (MonitorInfoEx[])monitorArry.ToArray(typeof(MonitorInfoEx));

                unsafe bool MonitorExEnumProc(IntPtr hMonitor, IntPtr hdc, ref Rect lpRect, IntPtr lpParam)
                {

                    MonitorInfoEx monitorInfo = new MonitorInfoEx();
                    monitorInfo.Init();

                    User32.WinGetMonitorInfo(hMonitor, ref monitorInfo);

                    monitorArry.Add(monitorInfo);
                    return true;
                }
            }
        }
    }
}
