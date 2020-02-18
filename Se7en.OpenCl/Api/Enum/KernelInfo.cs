namespace Se7en.OpenCl.Api.Enum
{
    public enum KernelInfo : int // cl_int
    {
        /// <summary>
        /// the kernel function name
        /// </summary>
        FunctionName = 0x1190,
        /// <summary>
        /// the number of arguments to kernel
        /// </summary>
        NumArgs = 0x1191,
        /// <summary>
        /// the kernel reference count
        /// </summary>
        ReferenceCount = 0x1192,
        /// <summary>
        /// the context associated with kernel
        /// </summary>
        Context = 0x1193,
        /// <summary>
        /// the program object associated with kernel
        /// </summary>
        Program = 0x1194,
        /// <summary>
        /// any attributes specified using the __attribute__ OpenCL C qualifier
        /// </summary>
        Attributes = 0x1195,

        MaxNumSubGroups = 0x11B9,
          
        CompileNumSubGroups = 0x11BA

    }
}
