using Se7en.Mathematic;
using System;

namespace Se7en.WinApi {
    public delegate bool EnumDisplayMonitorsCallback(IntPtr hMonitor, IntPtr hdc, ref Rect lpRect, IntPtr lpParam);
}
