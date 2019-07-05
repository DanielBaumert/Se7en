using System;

namespace Se7en.WinApi {
    public delegate IntPtr LowLevelHookCallback(int nCode, IntPtr wParam, IntPtr lParam);
}