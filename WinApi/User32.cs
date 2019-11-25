using Se7en.Mathematic;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Se7en.WinApi {

    public class User32 {
        public const string ImportKey = "user32.dll";

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hwnd, ShowWindowCommands command);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr FindWindow(string className, string lpWindowName);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rect lpRect);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool ReleaseCapture();

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <remarks>The EnumChildWindows function is more reliable than calling GetWindow in a loop. An application that
        /// calls GetWindow to perform this task risks being caught in an infinite loop or referencing a handle to a window
        /// that has been destroyed.</remarks>
        /// <param name="hWnd">A handle to a window. The window handle retrieved is relative to this window, based on the
        /// value of the uCmd parameter.</param>
        /// <param name="uCmd">The relationship between the specified window and the window whose handle is to be
        /// retrieved.</param>
        /// <returns>
        /// If the function succeeds, the return value is a window handle. If no window exists with the specified relationship
        /// to the specified window, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowType wCmd);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr GetTopWindow(IntPtr hWnd);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, out StringBuilder lpString, int nMaxCount);

        [DllImport(ImportKey, EntryPoint = "GetWindowTextLengthA")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool UpdateWindow(IntPtr hwnd);

        [DllImport(ImportKey, EntryPoint = "FindWindowExA")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport(ImportKey, EntryPoint = "GetWindowTextA")]
        public static extern int GetWindowText(IntPtr hwnd, string lpString, int cch);

        // https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-windowfromdc
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr WindowFromDC(IntPtr hdc);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr GetActiveWindow();

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr CreateWindowExA(ExtendedWindowStyle dwExStyle, string lpClassName, string lpWindowName, WindowStyle dwStyle, int x, int y, int nHeight, int nWidth, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, ref IntPtr lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, IntPtr lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, int lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, StringBuilder lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, ref IntPtr lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, IntPtr lParam);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool PostMessage(IntPtr hWnd, WindowsMessage Msg, int wParam, int lParam);

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] InputType[] pInputs, int cbSize);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern uint MapVirtualKeyEx(uint uCode, MapVirtualKeyMapTypes uMapType, IntPtr dwhkl);

        /// <summary>
        /// The MapVirtualKey function translates (maps) a virtual-key code into a scan
        /// code or character value, or translates a scan code into a virtual-key code
        /// </summary>
        /// <param name="uCode">[in] Specifies the virtual-key code or scan code for a key.
        /// How this value is interpreted depends on the value of the uMapType parameter
        /// </param>
        /// <param name="uMapType">[in] Specifies the translation to perform. The value of this
        /// parameter depends on the value of the uCode parameter.
        /// </param>
        /// <returns>Either a scan code, a virtual-key code, or a character value, depending on
        /// the value of uCode and uMapType. If there is no translation, the return value is zero
        /// </returns>
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern int MapVirtualKey(MapVirtualKeyMapTypes uCode, uint uMapType);

        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr WindowFromPoint(Vector2i point);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, LowLevelHookCallback lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool GetClientRect(IntPtr hwnd, out Rect windowRect);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr GetDesktopWindow();

        #region SystemParametersInfo
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, IntPtr pvParam, SPIF fWinIni);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, SPIF fWinIni);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, StringBuilder pvParam, SPIF fWinIni);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref AnimationInfo pvParam, SPIF fWinIni);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(SPI uAction, int uParam, string lpvParam, SPIF fuWinIni);
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern int SystemParametersInfo(SPI uAction, int uParam, StringBuilder lpvParam, SPIF fuWinIni);
        #endregion

        #region Monotors
        [DllImport(ImportKey, CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern IntPtr EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumDisplayMonitorsCallback lpfnEnum, IntPtr dwData);
        [DllImport(ImportKey, EntryPoint = "GetMonitorInfoA", CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool WinGetMonitorInfo(IntPtr hMonitor, ref MonitorInfo monitorInfo);
        [DllImport(ImportKey, EntryPoint = "GetMonitorInfoA", CharSet = CharSet.Auto, SetLastError = true), MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static extern bool WinGetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx monitorInfo);
        #endregion
    }
}