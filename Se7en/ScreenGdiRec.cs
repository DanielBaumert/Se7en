#if Windows
using Se7en.Mathematic;
using Se7en.Windows.Api;
using Se7en.Windows.Api.Enum;
using Se7en.Windows.Api.Native;
using System;
using System.Drawing;

namespace Se7en
{

    public static class ScreenGdiRec
    {

        private static bool recording = false;

        public static event Action<Bitmap> RecordCallBack;
        public static int FPS { get; private set; }

        public static void Record()
        {

            recording = true;

            HWnd hDesk = User32.GetDesktopWindow();
            HDc hdcSrc = User32.GetWindowDC(hDesk);
            User32.GetWindowRect(hDesk, out Rect rect);

            int w = rect.Width;
            int h = rect.Height;


            HDc hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
            HBitmap hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, w, h);
            IntPtr hold = Gdi32.SelectObject(hdcDest, hBitmap);
            Gdi32.DeleteDC(hold);

            var m = typeof(Bitmap).GetMethod("FromGDIplus", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            Func<IntPtr, Bitmap> f = (Func<IntPtr, Bitmap>)m.CreateDelegate(typeof(Func<IntPtr, Bitmap>));

            var st = DateTime.Now;
            int fps = 0;
            while (recording)
            {
                Gdi32.BitBlt(hdcDest, 0, 0, w, h, hdcSrc, 0, 0, TernaryRasterOperations.SRCCOPY);

                GdiPlus.GdipCreateBitmapFromHBITMAP(hBitmap, IntPtr.Zero, out IntPtr bmpPtr);
                RecordCallBack?.Invoke(f(bmpPtr));


                fps++;
                var et = DateTime.Now;
                if ((et - st).TotalMilliseconds >= 1000)
                {
                    FPS = 1000 / fps;
                    fps = 0;
                    st = et;
                }
            }


            User32.ReleaseDC(hDesk, hdcSrc);
            Gdi32.DeleteObject(hBitmap);
        }

        public static void Stop() => recording = false;
    }
}
#endif