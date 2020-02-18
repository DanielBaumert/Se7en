
using Se7en.Windows.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api.Native
{
    public static class Gdi32
    {

        [DllImport(ExternDll.Gdi32, SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int height);
        [DllImport(ExternDll.Gdi32, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
        [DllImport(ExternDll.Gdi32, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport(ExternDll.Gdi32, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdcDest, IntPtr hBitmap);
        [DllImport(ExternDll.Gdi32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);
        [DllImport(ExternDll.Gdi32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport(ExternDll.Gdi32, SetLastError = true)]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
    }
}
