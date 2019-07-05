using Se7en.Mathematic;
using Se7en.WinApi;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Se7en.Windows {
    /// <summary>
    /// Provides functions to capture the entire screen, or a particular window, and save it to a file.
    /// </summary>
    public static class ScreenCapture {
        /// <summary>
        /// Creates an Image object containing a screen shot of the entire desktop
        /// </summary>
        /// <returns></returns>
        public static Image CaptureScreen()
            => CaptureWindow(User32.GetDesktopWindow());
        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns></returns>
        public static Image CaptureWindow(IntPtr handle) {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            Rect windowRect = new Rect();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.Right - windowRect.Left;
            int height = windowRect.Bottom - windowRect.Top;
            // create a device context we can copy to
            IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            Gdi32.BitBlt(hdcDest, 0, 0, width + 16, height - 16, hdcSrc, 0, 0, TernaryRasterOperations.SRCCOPY);
            // restore selection
            Gdi32.SelectObject(hdcDest, hOld);
            // clean up 
            Gdi32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            // get a .NET image object for it
            Image img = Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            Gdi32.DeleteObject(hBitmap);
            return img;
        }
        /// <summary>
        /// Captures a screen shot of a specific window, and saves it to a file
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public static void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format) {
            Image img = CaptureWindow(handle);
            img.Save(filename, format);
        }
        /// <summary>
        /// Captures a screen shot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public static void CaptureScreenToFile(string filename, ImageFormat format) {
            Image img = CaptureScreen();
            img.Save(filename, format);
        }

    }
}
