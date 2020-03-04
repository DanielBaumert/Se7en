#if Windows
using Se7en.Windows.Api.Enum;
using System.Runtime.InteropServices;

namespace Se7en.Windows
{

    // If the source bitmap has no per-pixel alpha value (that is, AC_SRC_ALPHA is not set), 
    // the SourceConstantAlpha value determines the blend of the source and destination bitmaps, as shown in the following table. 
    // Note that SCA is used for SourceConstantAlpha here. Also, SCA is divided by 255 because it has a value that ranges from 0 to 255.
    // 
    // Dst.Red	    = Src.Red   * (SCA/255.0) + Dst.Red   * (1.0 - (SCA/255.0))
    // Dst.Green	= Src.Green * (SCA/255.0) + Dst.Green * (1.0 - (SCA/255.0))
    // Dst.Blue	    = Src.Blue  * (SCA/255.0) + Dst.Blue  * (1.0 - (SCA/255.0))
    // ----------------------------------------------
    // If the destination bitmap has an alpha channel, then the blend is as follows.
    // 
    // Dst.Alpha	= Src.Alpha * (SCA/255.0) + Dst.Alpha * (1.0 - (SCA/255.0))
    // ----------------------------------------------- 
    // If the source bitmap does not use SourceConstantAlpha (that is, it equals 0xFF), 
    // the per-pixel alpha determines the blend of the source and destination bitmaps, as shown in the following table.
    // 
    // Dst.Red	    = Src.Red	+ (1 - Src.Alpha) * Dst.Red
    // Dst.Green	= Src.Green	+ (1 - Src.Alpha) * Dst.Green
    // Dst.Blue	    = Src.Blue	+ (1 - Src.Alpha) * Dst.Blue
    // -----------------------------------------------
    // If the destination bitmap has an alpha channel, then the blend is as follows.
    // 
    // Dest.alpha	= Src.Alpha	+ (1 - SrcAlpha) * Dst.Alpha
    // -----------------------------------------------
    // If the source has both the SourceConstantAlpha (that is, it is not 0xFF) and per-pixel alpha, 
    // the source is pre-multiplied by the SourceConstantAlpha and then the blend is based on the per-pixel alpha. 
    // The following tables show this. Note that SourceConstantAlpha is divided by 255 because it has a value that ranges from 0 to 255.
    // 
    // Src.Red	    = Src.Red	* SourceConstantAlpha / 255.0;
    // Src.Green	= Src.Green	* SourceConstantAlpha / 255.0;
    // Src.Blue	    = Src.Blue	* SourceConstantAlpha / 255.0;
    // Src.Alpha	= Src.Alpha	* SourceConstantAlpha / 255.0;
    // Dst.Red	    = Src.Red	+ (1 - Src.Alpha) * Dst.Red
    // Dst.Green	= Src.Green	+ (1 - Src.Alpha) * Dst.Green
    // Dst.Blue	    = Src.Blue	+ (1 - Src.Alpha) * Dst.Blue
    // Dst.Alpha	= Src.Alpha	+ (1 - Src.Alpha) * Dst.Alpha

    /// <summary>
    /// The BLENDFUNCTION structure controls blending by specifying the blending functions for source and destination bitmaps.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BlendFunction
    {
        /// <summary>
        /// Default = { BlendOp := BlendOpType.AC_SRC_OVER, BlendFlag := 0, SourceConstantAlpha := 0, AlphaFormat := AlphaFormatType.None }
        /// </summary>
        public static BlendFunction Default => new BlendFunction { BlendOp = BlendOpType.AC_SRC_OVER, BlendFlag = 0, SourceConstantAlpha = 0, AlphaFormat = AlphaFormatType.None };
        /// <summary>
        /// The source blend operation. Currently, the only source and destination blend operation that has been defined is AC_SRC_OVER. 
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public BlendOpType BlendOp;
        /// <summary>
        /// Must be zero.
        /// </summary>
        public byte BlendFlag;
        /// <summary>
        /// Specifies an alpha transparency value to be used on the entire source bitmap.<br/>
        /// The SourceConstantAlpha value is combined with any per-pixel alpha values in the source bitmap.<br/>
        /// If you set SourceConstantAlpha to 0, it is assumed that your image is transparent.<br/>
        /// Set the SourceConstantAlpha value to 255 (opaque) when you only want to use per-pixel alpha values.
        /// </summary>
        public byte SourceConstantAlpha;
        /// <summary>
        /// This member controls the way the source and destination bitmaps are interpreted.<br/>
        /// AlphaFormat has the following value.
        /// </summary>
        [MarshalAs(UnmanagedType.I1)]
        public AlphaFormatType AlphaFormat;
    }

}
#endif