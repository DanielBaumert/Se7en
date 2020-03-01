namespace Se7en
{
    public unsafe static class BitUtils
    {
        #region Byte 
        /// <summary>
        /// Get the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <returns>Value of the bit.</returns>
        public static bool GetBit(this byte pByte, int bitNo)
            => (pByte & (1 << bitNo)) != 0;

        /// <summary>
        ///     Set the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <param name="value">Value of the bit.</param>
        /// <returns>Byte with changed bit.</returns>
        public static byte SetBit(this byte pByte, int bitNo, bool value)
        {
            int result = pByte | (value ? (1 << bitNo) : ~(1 << bitNo));
            return *(byte*)&result;
        }
        #endregion
        #region Short 
        /// <summary>
        /// Get the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <returns>Value of the bit.</returns>
        public static bool GetBit(this short pByte, int bitNo)
            => (pByte & (1 << bitNo)) != 0;

        /// <summary>
        ///     Set the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <param name="value">Value of the bit.</param>
        /// <returns>Byte with changed bit.</returns>
        public static short SetBit(this short pByte, int bitNo, bool value)
        {
            int result = pByte | (value ? (1 << bitNo) : ~(1 << bitNo));
            return *(short*)&result;
        }
        #endregion
        #region Int
        /// <summary>
        ///     Get the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <returns>Value of the bit.</returns>
        public static bool GetBit(this int pByte, int bitNo)
            => (pByte & (1 << bitNo)) != 0;
        /// <summary>
        ///     Set the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <param name="value">Value of the bit.</param>
        /// <returns>Byte with changed bit.</returns>
        public static int SetBit(this int pByte, int bitNo, bool value) 
            => pByte | (value ? (1 << bitNo) : ~(1 << bitNo));
        #endregion
        #region SByte 
        /// <summary>
        /// Get the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <returns>Value of the bit.</returns>
        public static bool GetBit(this sbyte pByte, int bitNo)
            => (pByte & (1 << bitNo)) != 0;

        /// <summary>
        ///     Set the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <param name="value">Value of the bit.</param>
        /// <returns>Byte with changed bit.</returns>
        public static sbyte SetBit(this sbyte pByte, int bitNo, bool value)
        {
            int result = pByte | (value ? (1 << bitNo) : ~(1 << bitNo));
            return *(sbyte*)&result;
        }
        #endregion
        #region Short 
        /// <summary>
        /// Get the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <returns>Value of the bit.</returns>
        public static bool GetBit(this ushort pByte, int bitNo)
            => (pByte & (1 << bitNo)) != 0;

        /// <summary>
        ///     Set the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <param name="value">Value of the bit.</param>
        /// <returns>Byte with changed bit.</returns>
        public static ushort SetBit(this ushort pByte, int bitNo, bool value)
        {
            int result = pByte | (value ? (1 << bitNo) : ~(1 << bitNo));
            return *(ushort*)&result;
        }
        #endregion
        #region int
        /// <summary>
        ///     Get the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <returns>Value of the bit.</returns>
        public static bool GetBit(this uint pByte, int bitNo)
            => (pByte & (1 << bitNo)) != 0;
        /// <summary>
        ///     Set the bit value in a byte.
        /// </summary>
        /// <param name="pByte">The byte where the value is encoded.</param>
        /// <param name="bitNo">The number of the bit (zero-based index).</param>
        /// <param name="value">Value of the bit.</param>
        /// <returns>Byte with changed bit.</returns>
        public static uint SetBit(this uint pByte, int bitNo, bool value) 
            => (uint)(pByte | (value ? (1 << bitNo) : ~(1 << bitNo)));
        #endregion
    }
}
