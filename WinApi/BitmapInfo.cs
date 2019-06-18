using System.Runtime.InteropServices;

namespace Se7en.WinApi {

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BitmapInfo {

        /// <summary>
        /// The number of bytes required by the structure.
        /// </summary>
        public uint Size;

        /// <summary>
        /// The width of the bitmap, in pixels.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of the bitmap, in pixels
        /// </summary>
        public int Height;

        /// <summary>
        /// The number of planes for the target device. This value must be set to 1.
        /// </summary>
        public ushort Planes;

        /// <summary>
        /// The number of bits-per-pixel.
        /// </summary>
        public BitCount BitCount;

        /// <summary>
        /// The type of compression for a compressed bottom-up bitmap (top-down DIBs cannot be compressed).
        /// </summary>
        public BitmapInfoCompression Compression;

        /// <summary>
        /// The size, in bytes, of the image. This may be set to zero for BI_RGB bitmaps.
        /// </summary>
        public uint SizeImage;

        /// <summary>
        /// The horizontal resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        public int XPelsPerMeter;

        /// <summary>
        /// The vertical resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        public int YPelsPerMeter;

        /// <summary>
        /// The number of color indexes in the color table that are actually used by the bitmap.
        /// </summary>
        public int ClrUsed;

        /// <summary>
        /// The number of color indexes that are required for displaying the bitmap.
        /// </summary>
        public int ClrImportant;

        /// <summary>
        /// The intensity of blue in the color.
        /// </summary>
        public byte RgbBlue;

        /// <summary>
        /// The intensity of green in the color.
        /// </summary>
        public byte RgbGreen;

        /// <summary>
        /// The intensity of red in the color.
        /// </summary>
        public byte RgbRed;

        /// <summary>
        /// This member is reserved and must be zero.
        /// </summary>
        public byte RgbReserved;
    }
}