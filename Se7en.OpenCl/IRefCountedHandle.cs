using Se7en.OpenCl.Api.Enum;
using System;

namespace Se7en.OpenCl
{
    internal interface IRefCountedHandle: IDisposable
    {
        ErrorCode Retain();
        ErrorCode Release();

    }
}