using Se7en.Math;
using System.Runtime.InteropServices;

namespace Se7en.Graphic {

    [StructLayout(LayoutKind.Explicit, Size = 40)]
    public unsafe struct SBitmap {

        [FieldOffset(0)]
        public void* Ptr;

        [FieldOffset(0)]
        public uint _Size;

        [FieldOffset(4)]
        public Vector2i Size;

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
        public uint Compression;

        [FieldOffset(20)]
        public uint SizeImage;

        [FieldOffset(24)]
        public int XPelsPerMeter;

        [FieldOffset(28)]
        public int YPelsPerMeter;

        [FieldOffset(32)]
        public uint ClrUsed;

        [FieldOffset(36)]
        public uint ClrImportant;
    }
}