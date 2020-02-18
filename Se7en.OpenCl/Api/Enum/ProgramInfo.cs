namespace Se7en.OpenCl.Api.Enum
{
    public enum ProgramInfo : uint // cl_uint
    {
        /// <summary>
        /// the program reference count
        /// </summary>
        ReferenceCount = 0x1160,
        /// <summary>
        /// the context specified when the program object is created
        /// </summary>
        Context = 0x1161,
        /// <summary>
        ///  the number of devices associated with program
        /// </summary>
        NumDevices = 0x1162,
        /// <summary>
        /// the list of devices associated with the program object.<br/>
        /// This can be the devices associated with context on which the program object has been created or can be a subset of devices that are specified when a program object is created using clCreateProgramWithBinary.
        /// </summary>
        Devices = 0x1163,
        /// <summary>
        /// the program source code specified by clCreateProgramWithSource<para/>
        /// If program is created using clCreateProgramWithBinary, clCreateProgramWithIL or clCreateProgramWithBuiltInKernels,<br/>
        /// a null string or the appropriate program source code is returned depending on whether or not the program source code is stored in the binary.
        /// </summary>
        Source = 0x1164,
        /// <summary>
        /// an array that contains the size in bytes of the program binary (could be an executable binary, compiled binary or library binary) for each device associated with program.<br/>
        /// The size of the array is the number of devices associated with program.<para/>
        /// If a binary is not available for a device(s), a size of zero is returned.
        /// </summary>
        BinarySizes = 0x1165,
        /// <summary>
        /// the program binaries (could be an executable binary, compiled binary or library binary) for all devices associated with program.<para/>
        /// https://www.khronos.org/registry/OpenCL/sdk/2.2/docs/man/html/clGetProgramInfo.html
        /// </summary>
        Binaries = 0x1166,
        /// <summary>
        /// the number of kernels declared in program that can be created with clCreateKernel
        /// </summary>
        NumKernels = 0x1167,
        /// <summary>
        /// a semi-colon separated list of kernel names in program that can be created with clCreateKernel.
        /// </summary>
        KernelNames = 0x1168,
        /// <summary>
        /// Returns the program IL for programs created with clCreateProgramWithIL.<para/>#
        /// If program is created with clCreateProgramWithSource, clCreateProgramWithBinary or clCreateProgramWithBuiltInKernels the memory pointed to by param_value will be unchanged and param_value_size_retwill be set to 0.
        /// </summary>
        IL = 0x1169,
        /// <summary>
        /// This indicates that the program object contains non-trivial constructor(s) that will be executed by runtime before any kernel from the program is executed.
        /// </summary>
        ScopeGlobalCtorsPresent = 0x116A,
        /// <summary>
        /// This indicates that the program object contains non-trivial destructor(s) that will be executed by runtime when program is destroyed.
        /// </summary>
        ScopeGlobalDtorsPresent = 0x116B
    };


}