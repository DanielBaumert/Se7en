using System;

namespace Se7en.OpenCvSharp
{
    public class Cv2
    {
        /// <summary>
        /// Finds edges in an image using Canny algorithm.
        /// </summary>
        /// <param name="src">Single-channel 8-bit input image</param>
        /// <param name="edges">The output edge map. It will have the same size and the same type as image</param>
        /// <param name="threshold1">The first threshold for the hysteresis procedure</param>
        /// <param name="threshold2">The second threshold for the hysteresis procedure</param>
        /// <param name="apertureSize">Aperture size for the Sobel operator [By default this is ApertureSize.Size3]</param>
        /// <param name="L2gradient">Indicates, whether the more accurate L2 norm should be used to compute the image gradient magnitude (true), or a faster default L1 norm is enough (false). [By default this is false]</param>
        public static void Canny(InputArray src, OutputArray edges, double threshold1, double threshold2, int apertureSize = 3, bool L2gradient = false)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (edges == null)
            {
                throw new ArgumentNullException("edges");
            }
            src.ThrowIfDisposed();
            edges.ThrowIfNotReady();
            NativeMethods.imgproc_Canny(src.CvPtr, edges.CvPtr, threshold1, threshold2, apertureSize, L2gradient ? 1 : 0);
            GC.KeepAlive(src);
            GC.KeepAlive(edges);
            edges.Fix();
        }
        /// <summary>
		/// Returns the number of installed CUDA-enabled devices.
		/// Use this function before any other GPU functions calls. 
		/// If OpenCV is compiled without GPU support, this function returns 0.
		/// </summary>
        public static int GetCudaEnabledDeviceCount() => NativeMethods.cuda_getCudaEnabledDeviceCount();

    }
}