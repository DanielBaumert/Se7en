using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.CompilerServices;

namespace Se7en.OpenCl
{
    internal unsafe delegate ErrorCode GetInfoHandler<TInfo>(IntPtr handle, TInfo info, uint paramValSize, void* paramVal, out uint paramValSizeRet);
    internal static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe static TOut[] GetTInfo<TInfo, TOut>(IntPtr handle, TInfo info, GetInfoHandler<TInfo> getInfoHandler, out uint length)
           where TInfo : Enum
           where TOut : unmanaged
        {
            ErrorCode err;
            if ((err = getInfoHandler(handle, info, 0, null, out length)) == ErrorCode.Success)
            {
                TOut[] target = new TOut[length];
                fixed (TOut* targetPtr = target)
                {
                    if ((err = getInfoHandler(handle, info, length, targetPtr, out _)) == ErrorCode.Success)
                    {
                        return target;
                    }
                    throw new Exception($"{err}");
                }
            }
            throw new Exception($"{err}");
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe static TOut GetTInfo<TInfo, TOut>(IntPtr handle, TInfo info, GetInfoHandler<TInfo> getInfoHandler)
          where TInfo : Enum
          where TOut : unmanaged
        {
            ErrorCode err;
            if ((err = getInfoHandler(handle, info, 0, null, out uint length)) == ErrorCode.Success)
            {
                TOut @out/* = default*/;
                if ((err = getInfoHandler(handle, info, length, &@out, out _)) == ErrorCode.Success)
                {
                    return @out;
                }
                throw new Exception($"{err}");
            }
            throw new Exception($"{err}");
        }
    }
}
