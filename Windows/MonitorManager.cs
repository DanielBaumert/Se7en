using Se7en.Collections;
using Se7en.Mathematic;
using Se7en.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.Windows {
    public static class MonitorManager {
        private static MonitorCollection _monitors;
        private static MonitorExCollection _monitorsEx;
        public static ref MonitorCollection GetAllMonitors() {
            _monitors = new MonitorCollection();
            User32.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnumProc, IntPtr.Zero);
            return ref _monitors;
        }

        private static unsafe bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdc, ref Rect lpRect, IntPtr lpParam) {

            MonitorInfo monitorInfo = new MonitorInfo {
                Size = sizeof(MonitorInfo)
            };

            User32.WinGetMonitorInfo(hMonitor, ref monitorInfo);

            _monitors.Add(new Monitor(monitorInfo));
            return true;
        }

        public static ref MonitorExCollection GetAllMonitorsEx() {
            _monitorsEx = new MonitorExCollection();
            User32.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorExEnumProc, IntPtr.Zero);
            return ref _monitorsEx;
        }

        private static unsafe bool MonitorExEnumProc(IntPtr hMonitor, IntPtr hdc, ref Rect lpRect, IntPtr lpParam) {

            MonitorInfoEx monitorInfo = new MonitorInfoEx();
            monitorInfo.Init();

            User32.WinGetMonitorInfo(hMonitor, ref monitorInfo);

            _monitorsEx.Add(new MonitorEx(monitorInfo));
            return true;
        }
    }
}
