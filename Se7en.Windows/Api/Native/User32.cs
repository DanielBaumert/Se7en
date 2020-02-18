using Se7en.Mathematic;
using Se7en.Windows.Api.Enum;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Se7en.Windows.Api.Native
{
    public static class User32
    {
        [DllImport(ExternDll.User32)]
        private static extern bool GetClientRect(IntPtr hwnd, out Rect windowRect);

        [DllImport(ExternDll.User32)]
        public static extern IntPtr WindowFromPoint(Vector2i point);
        [DllImport(ExternDll.User32)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport(ExternDll.User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        #region Window Updater

        [DllImport(ExternDll.User32)]
        public static extern bool UpdateWindow(IntPtr hwnd);
        [DllImport(ExternDll.User32)]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        [DllImport(ExternDll.User32)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        #endregion

        #region Hook


        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int hookType, Func<int, IntPtr, IntPtr, IntPtr> lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
       
        #endregion

        [DllImport(ExternDll.User32, EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(HandleRef hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex, int dwNewLong);

        [DllImport(ExternDll.User32, EntryPoint = "SetWindowLongPtr")]
        private static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex, IntPtr dwNewLong);
        public static IntPtr SetWindowLongPtr(HandleRef hWnd, WindowLongParam nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }




        [DllImport(ExternDll.User32, EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex);

        [DllImport(ExternDll.User32, EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, [In] [MarshalAs(UnmanagedType.I4)] WindowLongParam nIndex);
        public static IntPtr GetWindowLongPtr(IntPtr hWnd, WindowLongParam nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return GetWindowLongPtr32(hWnd, nIndex);
        }


        #region Message

        #region Send
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, ref IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, int lParam);

        #endregion
        #region Post

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, ref IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, IntPtr lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, int lParam);
        #endregion

        #endregion

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern IntPtr FindWindow(string className, string windowName);


        #region Monotors
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumDisplayMonitorsCallback lpfnEnum, IntPtr dwData);
        [DllImport(ExternDll.User32, EntryPoint = "GetMonitorInfoA", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool WinGetMonitorInfo(IntPtr hMonitor, ref MonitorInfo monitorInfo);
        [DllImport(ExternDll.User32, EntryPoint = "GetMonitorInfoA", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool WinGetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx monitorInfo);

        [DllImport(ExternDll.User32, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetSystemMetrics(int nIndex);
        #endregion

        #region SytemParametersInfo
       
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetSystemMetrics([In] [MarshalAs(UnmanagedType.I4)] SystemMetric nIndex);


        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref Rect rc, int nUpdate);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref int value, int ignore);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref bool value, int ignore);

        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SystemParametersInfo(SPI nAction, int nParam, ref Rect rc, int nUpdate);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SystemParametersInfo(SPI nAction, int nParam, ref int value, int ignore);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SystemParametersInfo(SPI nAction, int nParam, ref bool value, int ignore);

        //[DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        //[ResourceExposure(ResourceScope.None)]
        //public static extern bool SystemParametersInfo(int nAction, int nParam, ref NativeMethods.HIGHCONTRAST_I rc, int nUpdate);
        //[DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        //[ResourceExposure(ResourceScope.None)]
        //public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] NativeMethods.NONCLIENTMETRICS metrics, int nUpdate);

        #endregion
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetDoubleClickTime();
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetCursorPos([In, Out] Vector2i pt);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern short VkKeyScan(char key);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern short GetKeyState(int keyCode);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetCapture();
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr SetCapture(HandleRef hwnd);
        [DllImport(ExternDll.User32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetFocus();
    }
}
