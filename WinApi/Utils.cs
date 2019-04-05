using System;
using System.Collections.Generic;
using System.Text;

namespace Se7en.WinApi {
    public static class Utils {
        public static IEnumerable<string> GetAllWindows() {
            IntPtr top = User32.GetTopWindow(IntPtr.Zero);
            yield return GetWindowTitle(ref top);
            while ((top = User32.GetWindow(top, GetWindowType.GW_HWNDNEXT)) != IntPtr.Zero) {
                yield return GetWindowTitle(ref top);
            }
        }

        public static string GetWindowTitle(ref IntPtr hWnd) {
            int length = User32.GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            User32.GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

    }
}
