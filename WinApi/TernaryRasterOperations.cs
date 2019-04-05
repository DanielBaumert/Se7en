namespace Se7en.WinApi
{
    public enum TernaryRasterOperations : uint
    {
        /// <summary>
        /// dest = source
        /// </summary>
        SrcCopy = 0x00CC0020,
        /// <summary>
        /// dest = source OR dest 
        /// </summary>
        SrcPaint = 0x00EE0086,
        /// <summary>
        /// dest = source AND dest
        /// </summary>
        SrcAnd = 0x008800C6,
        /// <summary>
        /// 
        /// </summary>dest = source XOR dest
        SrcInvert = 0x00660046,
        /// <summary>
        /// dest = source AND (NOT dest)
        /// </summary>
        SrcErase = 0x00440328,
        /// <summary>
        /// dest = (NOT source)
        /// </summary>
        NotSrcCopy = 0x00330008,
        /// <summary>
        /// dest = (NOT src) AND (NOT dest)
        /// </summary>
        NotSrcErase = 0x001100A6,
        /// <summary>
        /// dest = (source AND pattern)
        /// </summary>
        MergeCopy = 0x00C000CA,
        /// <summary>
        /// dest = (NOT source) OR dest
        /// </summary>
        MergePaint = 0x00BB0226,
        /// <summary>
        /// dest = pattern
        /// </summary>
        PatCopy = 0x00F00021,
        /// <summary>
        /// dest = DPSnoo
        /// </summary>
        PatPaint = 0x00FB0A09,
        /// <summary>
        /// dest = pattern XOR dest
        /// </summary>
        PatInvert = 0x005A0049,
        /// <summary>
        /// dest = (NOT dest)
        /// </summary>
        DstInvert = 0x00550009,
        /// <summary>
        /// dest = BLACK
        /// </summary>
        Blackness = 0x00000042,
        /// <summary>
        /// dest = WHITE
        /// </summary>
        Whiteness = 0x00FF0062,
        /// <summary>
        /// Capture window as seen on screen.  This includes layered windows such as WPF windows with AllowsTransparency="true"
        /// </summary>
        CaptureBlt = 0x40000000
    }
}