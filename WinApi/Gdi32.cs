using System;
using System.Runtime.InteropServices;

namespace Se7en.WinApi
{
    public class Gdi32
    {

        private const string IMPORTKEY = "gdi32.dll";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc">A handle to the destination device context.</param>
        /// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="nDestWidth">The width, in logical units, of the destination rectangle.</param>
        /// <param name="nDestHeight">The height, in logical units, of the destination rectangle.</param>
        /// <param name="xSrc">The x-coordinate, in pixels, of the source rectangle in the image.</param>
        /// <param name="ySrc">The y-coordinate, in pixels, of the source rectangle in the image.</param>
        /// <param name="nSrcWidth">The width, in pixels, of the source rectangle in the image.</param>
        /// <param name="nSrcHeight">The height, in pixels, of the source rectangle in the image.</param>
        /// <param name="lpBits">A pointer to the image bits, which are stored as an array of bytes. For more information, see the Remarks section.</param>
        /// <param name="lpBitsInfo">A pointer to a BITMAPINFO structure that contains information about the DIB.</param>
        /// <param name="iUsage">Specifies whether the bmiColors member of the BITMAPINFO structure was provided and, if so, whether bmiColors contains explicit red, green, blue (RGB) values or indexes. The iUsage parameter must be one of the following values.</param>
        /// <param name="dwRop">A raster-operation code that specifies how the source pixels, the destination device context's current brush, and the destination pixels are to be combined to form the new image. For a list of some common raster operation codes, see BitBlt.</param>
        /// <returns>If the function fails, or no scan lines are copied, the return value is 0</returns>
        [DllImport(IMPORTKEY, SetLastError = true)]
        public static extern int StretchDIBits(IntPtr hdc, int xDest, int yDest, int nDestWidth, int nDestHeight, int xSrc, int ySrc, int nSrcWidth, int nSrcHeight, ref byte[] lpBits, ref BitmapInfo lpBitsInfo, DibColorMode iUsage, TernaryRasterOperations dwRop);

        /// <summary>
        /// The CreateCompatibleBitmap function creates a bitmap compatible with the device that is associated with the specified device context
        /// </summary>
        /// <param name="hdc">A handle to a device context.</param>
        /// <param name="width">The bitmap width, in pixels.</param>
        /// <param name="height">The bitmap height, in pixels.</param>
        /// <returns>If the function succeeds, the return value is a handle to the compatible bitmap (DDB).</returns>
        [DllImport(IMPORTKEY, SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int height);

        /// <summary>
        /// The CreateCompatibleDC function creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hdc">A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen</param>
        /// <returns>If the function succeeds, the return value is the handle to a memory DC.</returns>
        [DllImport(IMPORTKEY, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// The GetDIBits function retrieves the bits of the specified compatible bitmap and copies them into a buffer as a DIB using the specified format.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="hbm">A handle to the bitmap. This must be a compatible bitmap (DDB).</param>
        /// <param name="start">The first scan line to retrieve.</param>
        /// <param name="cLines">The number of scan lines to retrieve.</param>
        /// <param name="lpvBits">A pointer to a buffer to receive the bitmap data. If this parameter is NULL, the function passes the dimensions and format of the bitmap to the BITMAPINFO structure pointed to by the lpbi parameter.</param>
        /// <param name="lpbmi">A pointer to a BITMAPINFO structure that specifies the desired format for the DIB data.</param>
        /// <param name="usage">The format of the bmiColors member of the BITMAPINFO structure. It must be one of the following values.</param>
        /// <returns>
        /// If the lpvBits parameter is non-NULL and the function succeeds, the return value is the number of scan lines copied from the bitmap.<para/>
        /// If the lpvBits parameter is NULL and GetDIBits successfully fills the BITMAPINFO structure, the return value is nonzero.<para/>
        /// </returns>
        [DllImport(IMPORTKEY, SetLastError = true)]
        public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, IntPtr lpvBits, IntPtr lpbmi, DibColorMode usage);

        /// <summary>
        /// The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hdcDest">A handle to the DC.</param>
        /// <param name="hBitmap">A handle to the object to be selected. The specified object must have been created by using one of the following functions.</param>
        /// <returns></returns>
        [DllImport(IMPORTKEY, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdcDest, IntPtr hBitmap);

        /// <summary>
        /// he CreateBitmap function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
        /// </summary>
        /// <param name="nWidth">The bitmap width, in pixels.</param>
        /// <param name="nHeight">The bitmap height, in pixels.</param>
        /// <param name="nPlanes">The number of color planes used by the device.</param>
        /// <param name="nBitCount">The number of bits required to identify the color of a single pixel.</param>
        /// <param name="lpBits">A pointer to an array of color data used to set the colors in a rectangle of pixels. 
        /// Each scan line in the rectangle must be word aligned (scan lines that are not word aligned must be padded with zeros). 
        /// If this parameter is NULL, the contents of the new bitmap is undefined.</param>
        /// <returns>If the function succeeds, the return value is a handle to a bitmap.</returns>
        [DllImport(IMPORTKEY, SetLastError = true)]
        public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint nPlanes, uint nBitCount, IntPtr lpBits);

        [DllImport(IMPORTKEY, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);


    }
}
