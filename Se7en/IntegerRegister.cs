using System.Runtime.InteropServices;

namespace Se7en
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct IntegerRegister
    {
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

        public unsafe static explicit operator IntegerRegister(int value) => *((IntegerRegister*)&value);
        public unsafe static explicit operator int(IntegerRegister value) => *((int*)&value);
    }
}
