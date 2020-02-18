namespace Se7en.OpenCl.Api.Enum
{
    public enum MemInfo : uint // cl_uint
    {
        Type = 0x1100,
        Flags = 0x1101,
        Size = 0x1102,
        HostPtr = 0x1103,
        MapCount = 0x1104,
        ReferenceCount = 0x1105,
        Context = 0x1106,
        AssociatedMemObject = 0x1107,
        Offset = 0x1108,
        UsesSvmPointer = 0x1109
    };
}