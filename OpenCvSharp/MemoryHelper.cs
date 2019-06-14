using System;

namespace Se7en.OpenCvSharp
{
    public static class MemoryHelper
    {
        
        /// <param name="outDest"></param>
        /// <param name="inSrc"></param>
        /// <param name="inNumOfBytes"></param>
        public unsafe static void CopyMemory(void* outDest, void* inSrc, uint inNumOfBytes) 
            => Buffer.MemoryCopy(inSrc, outDest, (long)((ulong)inNumOfBytes), (long)((ulong)inNumOfBytes));

        public unsafe static void CopyMemory(void* outDest, void* inSrc, int inNumOfBytes) 
            => Buffer.MemoryCopy(inSrc, outDest, (long)inNumOfBytes, (long)inNumOfBytes);

        public unsafe static void CopyMemory(IntPtr outDest, IntPtr inSrc, uint inNumOfBytes) 
            => Buffer.MemoryCopy(inSrc.ToPointer(), outDest.ToPointer(), (long)((ulong)inNumOfBytes), (long)((ulong)inNumOfBytes));

        public unsafe static void CopyMemory(IntPtr outDest, IntPtr inSrc, int inNumOfBytes) 
            => Buffer.MemoryCopy(inSrc.ToPointer(), outDest.ToPointer(), (long)inNumOfBytes, (long)inNumOfBytes);

        
        /// <param name="outDest"></param>
        /// <param name="inNumOfBytes"></param>
        public unsafe static void ZeroMemory(void* outDest, uint inNumOfBytes)
        {
            uint offset = *(uint*)outDest & 3u;
            if (offset != 0u)
            {
                offset = 3u - offset;
            }
            offset = Math.Min(offset, inNumOfBytes);
            for (uint i = 0u; i < offset; i += 1u)
            {
                ((byte*)outDest)[i] = 0;
            }
            uint* dst = (uint*)((byte*)outDest + offset);
            uint numOfUInt = (inNumOfBytes - offset) / 4u;
            for (uint j = 0u; j < numOfUInt; j += 1u)
            {
                dst[(ulong)j * 4UL / 4UL] = 0u;
            }
            for (uint k = offset + numOfUInt * 4u; k < inNumOfBytes; k += 1u)
            {
                ((byte*)outDest)[k] = 0;
            }
        }

        public unsafe static void ZeroMemory(void* outDest, int inNumOfBytes) 
            => ZeroMemory(outDest, (uint)inNumOfBytes);

        public unsafe static void ZeroMemory(IntPtr outDest, uint inNumOfBytes) 
            => ZeroMemory(outDest.ToPointer(), inNumOfBytes);

        public unsafe static void ZeroMemory(IntPtr outDest, int inNumOfBytes) 
            => ZeroMemory(outDest.ToPointer(), (uint)inNumOfBytes);
    }
}