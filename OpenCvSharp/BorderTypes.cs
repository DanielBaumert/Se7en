using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.OpenCvSharp
{
    /// <summary>
    /// Type of the border to create around the copied source image rectangle
    /// </summary>
        public enum BorderTypes
    {
        /// <summary>
        /// Border is filled with the fixed value, passed as last parameter of the function.
        /// `iiiiii|abcdefgh|iiiiiii`  with some specified `i`
        /// </summary>
        Constant,
        /// <summary>
        /// The pixels from the top and bottom rows, the left-most and right-most columns are replicated to fill the border.
        /// `aaaaaa|abcdefgh|hhhhhhh`
        /// </summary>
        Replicate,
        /// <summary>
        /// `fedcba|abcdefgh|hgfedcb`
        /// </summary>
        Reflect,
        /// <summary>
        /// `cdefgh|abcdefgh|abcdefg`
        /// </summary>
        Wrap,
        /// <summary>
        /// `gfedcb|abcdefgh|gfedcba`
        /// </summary>
        Reflect101,
        /// <summary>
        /// `uvwxyz|absdefgh|ijklmno`
        /// </summary>
        Transparent,
        /// <summary>
        /// same as BORDER_REFLECT_101
        /// </summary>
        Default = 4,
        /// <summary>
        /// do not look outside of ROI
        /// </summary>
        Isolated = 16
    }
}
