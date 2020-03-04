#if Windows
using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api.Native
{
    public static class GdiPlus
    {
        #region GdipCreateBitmapFromHBITMAP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hbitmap">Handle to bitmap</param>
        /// <param name="hpalette">Color palette must be 0</param>
        /// <param name="bitmap">returnt ptr to managed Bitmap</param>
        /// <returns></returns>

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipCreateBitmapFromHBITMAP(HBitmap hbitmap, IntPtr hpalette, out IntPtr bitmap);

        #endregion
    }
}
#endif