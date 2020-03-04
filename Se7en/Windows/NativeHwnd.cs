#if Windows
using Se7en.Windows.Api;
using Se7en.Windows.Api.Enum;
using Se7en.Windows.Api.Native;

namespace Se7en.Windows
{
    public struct NativeHwnd
    {
        public readonly HWnd Hwnd;

        public bool Show(ShowWindowCommands cmdShow) => User32.ShowWindow(Hwnd, cmdShow);
        public bool Show(OldShowWindowCommands cmdShow) => User32.ShowWindow(Hwnd, cmdShow);
    }
}
#endif