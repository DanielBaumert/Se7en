using System.Runtime.InteropServices;

namespace Se7en.WinApi {
    /// <summary>
    /// ANIMATIONINFO specifies animation effects associated with user actions. 
    /// Used with SystemParametersInfo when SPI_GETANIMATION or SPI_SETANIMATION action is specified.
    /// </summary>
    /// <remark>
    /// The uiParam value must be set to (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO)) when using this structure.
    /// </remark>
    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationInfo {
        /// <summary>
        /// Creates an AMINMATIONINFO structure.
        /// </summary>
        /// <param name="IMinAnimate">If non-zero and SPI_SETANIMATION is specified, enables minimize/restore animation.</param>
        public AnimationInfo(int iMinAnimate) {
            CbSize = (uint)Marshal.SizeOf(typeof(AnimationInfo));
            IMinAnimate = iMinAnimate;
        }

        /// <summary>
        /// Always must be set to (System.UInt32)Marshal.SizeOf(typeof(ANIMATIONINFO)).
        /// </summary>
        public uint CbSize;

        /// <summary>
        /// If non-zero, minimize/restore animation is enabled, otherwise disabled.
        /// </summary>
        public int IMinAnimate;
    }
}
