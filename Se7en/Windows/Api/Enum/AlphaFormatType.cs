#if Windows
namespace Se7en.Windows.Api.Enum
{
    /// <summary>
    /// The way the source and destination bitmaps are interpreted
    /// </summary>
    public enum AlphaFormatType {
        /// <summary>
        /// The alpha format is not set
        /// </summary>
        None = 0,
        /// <summary>
        /// This flag is set when the bitmap has an Alpha channel (that is, per-pixel alpha).<br/>
        /// Note that the APIs use premultiplied alpha, which means that the red, green and blue channel values in the bitmap must be premultiplied with the alpha channel value.<br/>
        /// For example, if the alpha channel value is x, the red, green and blue channels must be multiplied by x and divided by 0xff prior to the call.
        /// </summary>
        AC_SRC_ALPHA = 0x01
    }
}
#endif