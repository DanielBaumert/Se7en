using System;

namespace Se7en.OpenCvSharp
{
    /// <summary>
	/// Proxy datatype for passing Mat's and vector&lt;&gt;'s as input parameters
	/// </summary>
	public class InputArray : DisposableCvObject
	{  
        private readonly object obj;
        public bool IsUtilMap { get => obj is UtilMap; }
        internal InputArray(UtilMap mat)
		{
			if (mat == null) {
				throw new ArgumentNullException("mat");
			}
			ptr = UtilMap.InputArray(mat.Ptr);
			GC.KeepAlive(mat);
			obj = mat;
		}

        public static implicit operator InputArray(UtilMap mat) => new InputArray(mat);
    }
}