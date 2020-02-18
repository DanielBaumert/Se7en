using System;
using Se7en.Windows.Api.Enum;
using Se7en.Windows.Api.Native;

namespace Se7en.Windows
{
    //public static class Screenshot
    //{

        

    //    public void Screen(int screenIndex)
    //    {
    //        Scre
    //    }


    //    private Image TakeScreenshot(IntPtr hwnd, int x1, int y1, int x2, int y2)
    //    {
    //        int width = x2 - x1;
    //        int height = y2 - y1;

    //        IntPtr hdcSrc = hwnd == IntPtr.Zero ? Gdi32.CreateDC("DISPLAY", null, null, IntPtr.Zero) : User32.GetWindowDC(hwnd);
    //        IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
    //        IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);

    //        IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);
    //        Gdi32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, x1, y1, TernaryRasterOperations.SRCCOPY | TernaryRasterOperations.CAPTUREBLT);
    //        Gdi32.SelectObject(hdcDest, hOld);



    //        Image img = Image.FromHbitmap(hBitmap);

    //        Gdi32.DeleteDC(hdcDest);
    //        User32.ReleaseDC(hwnd, hdcSrc);
    //        Gdi32.DeleteObject(hBitmap);

    //        return img;
    //    }
    //}
}
