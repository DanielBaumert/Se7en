#if Windows

using Se7en.Mathematic;
using Se7en.Windows.Api;
using Se7en.Windows.Api.Native;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Se7en.Windows
{
    public static class Monitor
    {
        public static Vector2i PrimaryMonitorSize => SystemInformation.PrimaryMonitorSize;
        public static int MonitorCount => SystemInformation.MonitorCount;
        public static bool MultiMonitorSupport => MonitorCount != 0;
        public static Rect VirtualScreen => SystemInformation.VirtualScreen;

        public static MonitorInfo[] AllMonitors {
            get {

                List<MonitorInfo> monitors = new List<MonitorInfo>();
                User32.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorExEnumProc, IntPtr.Zero);
                return monitors.ToArray();

                unsafe bool MonitorExEnumProc(IntPtr hMonitor, IntPtr hdc, ref Rect lpRect, IntPtr lpParam)
                {

                    MonitorInfo monitorInfo = new MonitorInfo();
                    monitorInfo.Init();

                    User32.WinGetMonitorInfo(hMonitor, ref monitorInfo);

                    monitors.Add(monitorInfo);
                    return true;
                }
            }
        }
    }
}
#endif