
using Se7en.Windows.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api.Native
{
    public static class Gdi32
    {

        #region CreateCompatibleDC
        /// <summary>
        /// The CreateCompatibleDC function creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hdc">
        /// A handle to an existing DC.<br/>
        /// If this handle is NULL, the function creates a memory DC compatible with the application's current screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a memory DC.<br/>
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateCompatibleDC")]
        public static extern HDc CreateCompatibleDC(HDc hdc);
        #endregion

        #region Bitmap
        #region AlphaBlend

        [DllImport(ExternDll.Gdi32, EntryPoint = "AlphaBlend")]
        public static extern void AlphaBlend(HDc hDc, int xoriginDest, int yoriginDest, int wDest, int hDest, HDc hdcSrc, int xoriginSrc, int yoriginSrc, int wSrc, int hSrc, BlendFunction ftn);

        #endregion
        #region BitBlt
        /// <summary>
        /// The BitBlt function performs a bit-block transfer of the color data corresponding to a rectangle of pixels from the specified source device context into a destination device context.
        /// </summary>
        /// <param name="hdc">
        /// A handle to the destination device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.
        /// </param>
        /// <param name="cx">
        /// The width, in logical units, of the source and destination rectangles.
        /// </param>
        /// <param name="cy">
        /// The height, in logical units, of the source and the destination rectangles.
        /// </param>
        /// <param name="hdcSrc">
        /// A handle to the source device context.
        /// </param>
        /// <param name="x1">
        /// The x-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="y2">
        /// The y-coordinate, in logical units, of the upper-left corner of the source rectangle.
        /// </param>
        /// <param name="dwRop">
        /// A raster-operation code.<br/>
        /// These codes define how the color data for the source rectangle is to be combined with the color data for the destination rectangle to achieve the final color.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Gdi32, EntryPoint = "BitBlt")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(HDc hdc, int x, int y, int cx, int cy, HDc hdcSrc, int x1, int y2, TernaryRasterOperations dwRop);
        #endregion
        #region CreateBitmap
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateBitmap")]
        public static extern void CreateBitmap();

        #endregion
        #region CreateBitmapIndirect
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateBitmapIndirect")]
        public static extern void CreateBitmapIndirect();

        #endregion
        #region CreateCompatibleBitmap
        /// <summary>
        /// The CreateCompatibleBitmap function creates a bitmap compatible with the device that is associated with the specified device context.
        /// </summary>
        /// <param name="hdc">
        /// A handle to a device context.
        /// </param>
        /// <param name="cx">
        /// The bitmap width, in pixels.
        /// </param>
        /// <param name="cy">
        /// The bitmap height, in pixels.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).<br/>
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateCompatibleBitmap")]
        public static extern HBitmap CreateCompatibleBitmap(HDc hdc, int cx, int cy);
        #endregion

#if GDIUnlock
        #region CreateDIBitmap
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateDIBitmap")]
        public static extern void CreateDIBitmap();

        #endregion
        #region CreateDIBSection
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateDIBSection")]
        public static extern void CreateDIBSection();

        #endregion
        #region ExtFloodFill
        [DllImport(ExternDll.Gdi32, EntryPoint = "ExtFloodFill")]
        public static extern void ExtFloodFill();

        #endregion
        #region GetBitmapDimensionEx
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetBitmapDimensionEx")]
        public static extern void GetBitmapDimensionEx();

        #endregion
        #region GetDIBColorTable
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetDIBColorTable")]
        public static extern void GetDIBColorTable();

        #endregion
        #region GetDIBits
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetDIBits")]
        public static extern void GetDIBits();

        #endregion
        #region GetPixel
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetPixel")]
        public static extern void GetPixel();

        #endregion
        #region GetStretchBltMode
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetStretchBltMode")]
        public static extern void GetStretchBltMode();

        #endregion
        #region GradientFill
        [DllImport(ExternDll.Gdi32, EntryPoint = "GradientFill")]
        public static extern void GradientFill();

        #endregion
        #region LoadBitmap
        [DllImport(ExternDll.Gdi32, EntryPoint = "LoadBitmap")]
        public static extern void LoadBitmap();

        #endregion
        #region MaskBlt
        [DllImport(ExternDll.Gdi32, EntryPoint = "MaskBlt")]
        public static extern void MaskBlt();

        #endregion
        #region PlgBlt
        [DllImport(ExternDll.Gdi32, EntryPoint = "PlgBlt")]
        public static extern void PlgBlt();

        #endregion
        #region SetBitmapDimensionEx
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetBitmapDimensionEx")]
        public static extern void SetBitmapDimensionEx();

        #endregion
        #region SetDIBColorTable
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetDIBColorTable")]
        public static extern void SetDIBColorTable();

        #endregion
        #region SetDIBits
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetDIBits")]
        public static extern void SetDIBits();

        #endregion
        #region SetDIBitsToDevice
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetDIBitsToDevice")]
        public static extern void SetDIBitsToDevice();

        #endregion
        #region SetPixel
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetPixel")]
        public static extern void SetPixel();

        #endregion
        #region SetPixelV
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetPixelV")]
        public static extern void SetPixelV();

        #endregion
        #region SetStretchBltMode
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetStretchBltMode")]
        public static extern void SetStretchBltMode();

        #endregion
        #region StretchBlt
        [DllImport(ExternDll.Gdi32, EntryPoint = "StretchBlt")]
        public static extern void StretchBlt();

        #endregion
        #region StretchDIBits
        [DllImport(ExternDll.Gdi32, EntryPoint = "StretchDIBits")]
        public static extern void StretchDIBits();

        #endregion
        #region TransparentBlt
        [DllImport(ExternDll.Gdi32, EntryPoint = "TransparentBlt")]
        public static extern void TransparentBlt();

        #endregion
#endif
        #endregion

        #region AddFontMemResourceEx
        /// <summary>
        /// The AddFontMemResourceEx function adds the font resource from a memory image to the system.
        /// </summary>
        /// <param name="pFileView">A pointer to a font resource.</param>
        /// <param name="cjSize">The number of bytes in the font resource that is pointed to by pbFont.</param>
        /// <param name="pvResrved">Reserved. Must be 0.</param>
        /// <param name="pNumFonts">A pointer to a variable that specifies the number of fonts installed.</param>
        /// <returns>
        /// If the function succeeds, the return value specifies the handle to the font added.<br/>
        /// This handle uniquely identifies the fonts that were installed on the system.<br/>
        /// If the function fails, the return value is zero. No extended error information is available.
        /// </returns>
        [DllImport(ExternDll.Gdi32)]
        public static extern IntPtr AddFontMemResourceEx(IntPtr pFileView, uint cjSize, IntPtr pvResrved, ref uint pNumFonts);
        #endregion

      

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
