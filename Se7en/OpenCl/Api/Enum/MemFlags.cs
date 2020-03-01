using System;

namespace Se7en.OpenCl.Api.Enum
{
    [Flags]
    public enum MemFlags : ulong // cl_ulong
    {
        None = 0,
        ReadWrite = (1 << 0),
        WriteOnly = (1 << 1),
        ReadOnly = (1 << 2),
        UseHostPtr = (1 << 3),
        AllocHostPtr = (1 << 4),
        CopyHostPtr = (1 << 5),
    }
}