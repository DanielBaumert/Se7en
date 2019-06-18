namespace Se7en.OpenCvSharp {

    /// <summary>
    /// Proxy datatype for passing Mat's and vector&lt;&gt;'s as input parameters.
    /// Synonym for OutputArray.
    /// </summary>
    public class InputOutputArray : OutputArray {

        /// <summary>
        ///
        /// </summary>
        /// <param name="mat"></param>
        internal InputOutputArray(UtilMap mat) : base(mat) {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static implicit operator InputOutputArray(UtilMap mat)
            => new InputOutputArray(mat);
    }
}