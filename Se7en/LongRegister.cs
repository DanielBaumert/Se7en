using System.Runtime.InteropServices;

namespace Se7en
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct LongRegister
    {
        /// <summary>
        /// Bytes from 0 to 3
        /// </summary>
        [FieldOffset(0)]
        public int Int1;
        /// <summary>
        /// Bytes from 4 to 7
        /// </summary>
        [FieldOffset(4)]
        public int Int2;

        /// <summary>
        /// Bytes from 0 and 1;
        /// </summary>
        [FieldOffset(0)]
        public short Short1;
        /// <summary>
        /// Bytes from 2 and 3;
        /// </summary>
        [FieldOffset(2)]
        public short Short2;
        /// <summary>
        /// Bytes from 4 and 5;
        /// </summary>
        [FieldOffset(4)]
        public short Short3;
        /// <summary>
        /// Bytes from 6 and 7;
        /// </summary>
        [FieldOffset(6)]
        public short Short4;

        /// <summary>
        /// Byte 0
        /// </summary>
        [FieldOffset(0)]
        public byte Byte0;
        /// <summary>
        /// Byte 1
        /// </summary>
        [FieldOffset(1)]
        public byte Byte1;
        /// <summary>
        /// Byte 2
        /// </summary>
        [FieldOffset(2)]
        public byte Byte2;
        /// <summary>
        /// Byte 3
        /// </summary>
        [FieldOffset(3)]
        public byte Byte3;
        /// <summary>
        /// Byte 4
        /// </summary>
        [FieldOffset(4)]
        public byte Byte4;
        /// <summary>
        /// Byte 5
        /// </summary>
        [FieldOffset(5)]
        public byte Byte5;
        /// <summary>
        /// Byte 6
        /// </summary>
        [FieldOffset(6)]
        public byte Byte6;
        /// <summary>
        /// Byte 7
        /// </summary>
        [FieldOffset(7)]
        public byte Byte7;

        public unsafe static explicit operator LongRegister(long value) => *((LongRegister*)&value);
        public unsafe static explicit operator long(LongRegister value) => *((long*)&value);
    }
}
