using Se7en.WinApi;
using System;
using System.Text;

namespace Se7en.Windows {

    public class NativWindow {

        public static bool FindFirstWindowByTitle(IntPtr hwnd, string windowTitle, ref IntPtr hcwnd) {
            while (GetNextChild(ref hwnd, ref hcwnd)) {
                if (GetWindowTitle(hcwnd) == windowTitle) {
                    return true;
                } else {
                    IntPtr thcwnd = hcwnd;
                    hcwnd = IntPtr.Zero; // reset 4 first at all
                    if (FindFirstWindowByTitle(thcwnd, windowTitle, ref hcwnd)) {
                        return true;
                    }
                    hcwnd = thcwnd;
                }
            }
            return false;
        }

        public static IntPtr GetCurrentDisplayedWindow() => User32.GetActiveWindow();

        public static string GetWindowTitle(IntPtr hwnd) {
            int tLen = User32.GetWindowTextLength(hwnd);
            User32.GetWindowText(hwnd, out StringBuilder title, 255);
            return title.ToString().Substring(0, tLen);
        }

        public static bool GetNextChild(ref IntPtr hwndParent, ref IntPtr hwndChild, string lpszClass = "", string lpszWindow = "")
            => NextChild(ref hwndParent, ref hwndChild, lpszClass, lpszWindow);

        private static bool NextChild(ref IntPtr hwndParent, ref IntPtr hwndChild, string lpszClass, string lpszWindow) {
            IntPtr hcwnd = User32.FindWindowEx(hwndParent, hwndChild, lpszClass, lpszWindow);
            if (hcwnd != IntPtr.Zero) {
                hwndChild = hcwnd;
                return true;
            } else {
                return false;
            }
        }
    }
}