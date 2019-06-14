using System;

namespace Se7en.OpenCvSharp
{
    public interface IStdVector<T>
    {
        /// <summary>
        /// vector.size()
        /// </summary>
        int Size { get; }

        /// <summary>
        /// &amp;vector[0]
        /// </summary>
        IntPtr ElemPtr { get; }

        /// <summary>
        /// Convert std::vector&lt;T&gt; to managed array T[]
        /// </summary>
        T[] ToArray();
    }
}