using System.Runtime.InteropServices;

namespace Se7en
{
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct ShortRegister
    {
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

        public unsafe static explicit operator ShortRegister(short value) => *((ShortRegister*)&value);
        public unsafe static explicit operator short(ShortRegister value) => *((short*)&value);
    }
}
