using System;

namespace Se7en.Utils
{
    internal interface IRefCountedHandle : IDisposable
    {
        int Retain();
        int Release();
    }
}