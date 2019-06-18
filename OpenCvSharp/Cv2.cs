using System;

namespace Se7en.OpenCvSharp {

    public class Cv2 {
        public const double CV_PI = 3.1415926535897932384626433832795;

        /// <summary>
        /// computes weighted sum of two arrays (dst = alpha*src1 + beta*src2 + gamma)
        /// </summary>
        /// <param name="src1"></param>
        /// <param name="alpha"></param>
        /// <param name="src2"></param>
        /// <param name="beta"></param>
        /// <param name="gamma"></param>
        /// <param name="dst"></param>
        /// <param name="dtype"></param>
        // Token: 0x06000075 RID: 117 RVA: 0x00005C50 File Offset: 0x00003E50
        public static void AddWeighted(InputArray src1, double alpha, InputArray src2, double beta, double gamma, OutputArray dst, int dtype = -1) {
            if (src1 == null) {
                throw new ArgumentNullException("src1");
            }
            if (src2 == null) {
                throw new ArgumentNullException("src2");
            }
            if (dst == null) {
                throw new ArgumentNullException("dst");
            }
            src1.ThrowIfDisposed();
            src2.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_addWeighted(src1.CvPtr, alpha, src2.CvPtr, beta, gamma, dst.CvPtr, dtype);
            GC.KeepAlive(src1);
            GC.KeepAlive(src2);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Converts image from one color space to another
        /// </summary>
        /// <param name="src">The source image, 8-bit unsigned, 16-bit unsigned or single-precision floating-point</param>
        /// <param name="dst">The destination image; will have the same size and the same depth as src</param>
        /// <param name="code">The color space conversion code</param>
        /// <param name="dstCn">The number of channels in the destination image; if the parameter is 0, the number of the channels will be derived automatically from src and the code</param>
        public static void CvtColor(InputArray src, OutputArray dst, ColorConversionCodes code, int dstCn = 0) {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_cvtColor(src.CvPtr, dst.CvPtr, code, dstCn);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        /// <summary>
        /// Finds edges in an image using Canny algorithm.
        /// </summary>
        /// <param name="src">Single-channel 8-bit input image</param>
        /// <param name="edges">The output edge map. It will have the same size and the same type as image</param>
        /// <param name="threshold1">The first threshold for the hysteresis procedure</param>
        /// <param name="threshold2">The second threshold for the hysteresis procedure</param>
        /// <param name="apertureSize">Aperture size for the Sobel operator [By default this is ApertureSize.Size3]</param>
        /// <param name="L2gradient">Indicates, whether the more accurate L2 norm should be used to compute the image gradient magnitude (true), or a faster default L1 norm is enough (false). [By default this is false]</param>
        public static void Canny(InputArray src, OutputArray edges, double threshold1, double threshold2, int apertureSize = 3, bool L2gradient = false) {
            if (src == null)
                throw new ArgumentNullException("src");
            if (edges == null)
                throw new ArgumentNullException("edges");

            src.ThrowIfDisposed();
            edges.ThrowIfNotReady();
            NativeMethods.imgproc_Canny(src.CvPtr, edges.CvPtr, threshold1, threshold2, apertureSize, L2gradient ? 1 : 0);
            GC.KeepAlive(src);
            GC.KeepAlive(edges);
            edges.Fix();
        }

        /// <summary>
        /// Blurs an image using a Gaussian filter.
        /// </summary>
        /// <param name="src">input image; the image can have any number of channels, which are processed independently,
        /// but the depth should be CV_8U, CV_16U, CV_16S, CV_32F or CV_64F.</param>
        /// <param name="dst">output image of the same size and type as src.</param>
        /// <param name="ksize">Gaussian kernel size. ksize.width and ksize.height can differ but they both must be positive and odd.
        /// Or, they can be zero�s and then they are computed from sigma* .</param>
        /// <param name="sigmaX">Gaussian kernel standard deviation in X direction.</param>
        /// <param name="sigmaY">Gaussian kernel standard deviation in Y direction; if sigmaY is zero, it is set to be equal to sigmaX,
        /// if both sigmas are zeros, they are computed from ksize.width and ksize.height,
        /// respectively (see getGaussianKernel() for details); to fully control the result
        /// regardless of possible future modifications of all this semantics, it is recommended to specify all of ksize, sigmaX, and sigmaY.</param>
        /// <param name="borderType">pixel extrapolation method</param>
        public static void GaussianBlur(InputArray src, OutputArray dst, Size ksize, double sigmaX, double sigmaY = 0.0, BorderTypes borderType = BorderTypes.Reflect101) {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.imgproc_GaussianBlur(src.CvPtr, dst.CvPtr, ksize, sigmaX, sigmaY, (int)borderType);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            dst.Fix();
        }

        public static LineSegmentPolar[] HoughLines(InputArray image, double rho, double theta, int threshold, double srn = 0.0, double stn = 0.0) {
            if (image == null) {
                throw new ArgumentNullException("image");
            }
            LineSegmentPolar[] result;
            using (VectorOfVec2f vec = new VectorOfVec2f()) {
                NativeMethods.imgproc_HoughLines(image.CvPtr, vec.CvPtr, rho, theta, threshold, srn, stn);
                GC.KeepAlive(image);
                result = vec.ToArray<LineSegmentPolar>();
            }
            return result;
        }

        /// <summary>
        /// Finds lines segments in a binary image using probabilistic Hough transform.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="rho">Distance resolution of the accumulator in pixels</param>
        /// <param name="theta">Angle resolution of the accumulator in radians</param>
        /// <param name="threshold">The accumulator threshold parameter. Only those lines are returned that get enough votes ( &gt; threshold )</param>
        /// <param name="minLineLength">The minimum line length. Line segments shorter than that will be rejected. [By default this is 0]</param>
        /// <param name="maxLineGap">The maximum allowed gap between points on the same line to link them. [By default this is 0]</param>
        /// <returns>The output lines. Each line is represented by a 4-element vector (x1, y1, x2, y2)</returns>
        public static LineSegmentPoint[] HoughLinesP(InputArray image, double rho, double theta, int threshold, double minLineLength = 0.0, double maxLineGap = 0.0) {
            if (image == null) {
                throw new ArgumentNullException("image");
            }
            image.ThrowIfDisposed();
            LineSegmentPoint[] result;
            using (VectorOfVec4i vec = new VectorOfVec4i()) {
                NativeMethods.imgproc_HoughLinesP(image.CvPtr, vec.CvPtr, rho, theta, threshold, minLineLength, maxLineGap);
                GC.KeepAlive(image);
                result = vec.ToArray<LineSegmentPoint>();
            }
            return result;
        }

        /// <summary>
        /// Erodes an image by using a specific structuring element.
        /// </summary>
        /// <param name="src">The source image</param>
        /// <param name="dst">The destination image. It will have the same size and the same type as src</param>
        /// <param name="element">The structuring element used for dilation. If element=new Mat(), a 3x3 rectangular structuring element is used</param>
        /// <param name="anchor">Position of the anchor within the element. The default value (-1, -1) means that the anchor is at the element center</param>
        /// <param name="iterations">The number of times erosion is applied</param>
        /// <param name="borderType">The pixel extrapolation method</param>
        /// <param name="borderValue">The border value in case of a constant border. The default value has a special meaning. [By default this is CvCpp.MorphologyDefaultBorderValue()]</param>
        public static void Erode(InputArray src, OutputArray dst, InputArray element, Point? anchor = null, int iterations = 1, BorderTypes borderType = BorderTypes.Constant, Scalar? borderValue = null) {
            if (src == null)
                throw new ArgumentNullException("src");
            if (dst == null)
                throw new ArgumentNullException("dst");

            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            Point anchor2 = anchor.GetValueOrDefault(new Point(-1, -1));
            Scalar borderValue2 = borderValue.GetValueOrDefault(MorphologyDefaultBorderValue());
            IntPtr elementPtr = element.CvPtr;
            NativeMethods.imgproc_erode(src.CvPtr, dst.CvPtr, elementPtr, anchor2, iterations, (int)borderType, borderValue2);
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(element);
            dst.Fix();
        }

        /// <summary>
        /// Draws a line segment connecting two points
        /// </summary>
        /// <param name="img">The image. </param>
        /// <param name="pt1">First point of the line segment. </param>
        /// <param name="pt2">Second point of the line segment. </param>
        /// <param name="color">Line color. </param>
        /// <param name="thickness">Line thickness. [By default this is 1]</param>
        /// <param name="lineType">Type of the line. [By default this is LineType.Link8]</param>
        /// <param name="shift">Number of fractional bits in the point coordinates. [By default this is 0]</param>
        public static void Line(InputOutputArray img, Point pt1, Point pt2, Scalar color, int thickness = 1, LineTypes lineType = LineTypes.Link8, int shift = 0) {
            if (img == null) {
                throw new ArgumentNullException("img");
            }
            img.ThrowIfNotReady();
            NativeMethods.imgproc_line(img.CvPtr, pt1, pt2, color, thickness, (int)lineType, shift);
            img.Fix();
            GC.KeepAlive(img);
        }

        public static void BitwiseNot(InputArray src, OutputArray dst, InputArray mask = null) {
            if (src == null) {
                throw new ArgumentNullException("src");
            }
            if (dst == null) {
                throw new ArgumentNullException("dst");
            }
            src.ThrowIfDisposed();
            dst.ThrowIfNotReady();
            NativeMethods.core_bitwise_not(src.CvPtr, dst.CvPtr, Cv2.ToPtr(mask));
            GC.KeepAlive(src);
            GC.KeepAlive(dst);
            GC.KeepAlive(mask);
            dst.Fix();
        }

        /// <summary>
		/// Returns the number of installed CUDA-enabled devices.
		/// Use this function before any other GPU functions calls.
		/// If OpenCV is compiled without GPU support, this function returns 0.
		/// </summary>
        public static int GetCudaEnabledDeviceCount() => NativeMethods.cuda_getCudaEnabledDeviceCount();

        public static Scalar MorphologyDefaultBorderValue() => Scalar.All(double.MaxValue);

        internal static IntPtr ToPtr(InputArray obj) {
            if (obj == null)
                return IntPtr.Zero;
            return obj.CvPtr;
        }
    }
}