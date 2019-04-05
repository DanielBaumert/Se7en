using System.Runtime.InteropServices;

namespace Se7en.UI.Drawing
{
    [StructLayout(LayoutKind.Explicit, Size = 40)]
    public struct Bitmap
    {

        [FieldOffset(0)]
        uint _Size;
        [FieldOffset(4)]
        public Size2D Size;
        /// <summary>
        /// The width of the bitmap, in pixels.
        /// </summary>
        [FieldOffset(4)]
        public int Width;
        /// <summary>
        /// The height of the bitmap, in pixels
        /// </summary>
        [FieldOffset(8)]
        public int Height;
        /// <summary>
        /// The number of planes for the target device. This value must be set to 1.
        /// </summary>
        [FieldOffset(12)]
        private ushort Planes;
        /// <summary>
        /// The number of bits-per-pixel
        /// </summary>
        [FieldOffset(14)]
        public ushort BitCount;
        [FieldOffset(16)]
        uint Compression;
        [FieldOffset(20)]
        uint SizeImage;
        [FieldOffset(24)]
        int XPelsPerMeter;
        [FieldOffset(28)]
        int YPelsPerMeter;
        [FieldOffset(32)]
        uint ClrUsed;
        [FieldOffset(36)]
        uint ClrImportant;
    }

    public enum PixelFormat
    {
        None = 0,
        Bit1 = 1,
        Bit4 = 4,
        BIt8 = 8,
        BIt16 = 16,
        Bit32 = 32
    }
}
