using Se7en.OpenCl.Api.Enum;
using Se7en.OpenCl.Api.Native;
using Se7en.Utils;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly unsafe struct Device : IDisposable
    {

        public readonly IntPtr Handle;
        internal Device(IntPtr handle)
            => Handle = handle;

        /// <summary>
        /// A unique device vendor identifier.<br/>
        /// An example of a unique device identifier could be the PCIe ID.
        /// </summary>
        public readonly DeviceType Type => Utils.GetTInfo<DeviceInfo, DeviceType>(Handle, DeviceInfo.Type, Cl.GetDeviceInfo);

        /// <summary>
        /// A unique device vendor identifier.<br/>
        /// An example of a unique device identifier could be the PCIe ID.
        /// </summary>
        public readonly uint VendorId => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.VendorId, Cl.GetDeviceInfo);

        /// <summary>
        /// The number of parallel compute units on the OpenCL device.<br/>
        /// A work-group executes on a single compute unit.<br/>
        /// The minimum value is 1.
        /// </summary>
        public readonly uint MaxComputeUnits => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxComputeUnits, Cl.GetDeviceInfo);

        /// <summary>
        /// Maximum dimensions that specify the global and local work-item IDs used by the data parallel execution model.<br/>
        /// (Refer to clEnqueueNDRangeKernel).<br/>
        /// The minimum value is 3 for devices that are not of type CL_DEVICE_TYPE_CUSTOM.
        /// </summary>
        public readonly uint MaxWorkItemDimensions => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxWorkItemDimensions, Cl.GetDeviceInfo);

        /// <summary>
        /// Maximum number of work-items that can be specified in each dimension of the work-group to clEnqueueNDRangeKernel.<br/>
        /// Returns n int entries, where n is the value returned by the query for CL_DEVICE_MAX_WORK_ITEM_DIMENSIONS.<br/>
        /// The minimum value is (1, 1, 1) for devices that are not of type CL_DEVICE_TYPE_CUSTOM.
        /// </summary>
        public readonly uint MaxWorkItemSizes => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxWorkItemSizes, Cl.GetDeviceInfo);
        /// <summary>
        /// Maximum number of work-items in a work-group that a device is capable of executing on a single compute unit, for any given kernel-instance running on the device.<br/>
        /// (Refer also to clEnqueueNDRangeKernel and CL_KERNEL_WORK_GROUP_SIZE ).<br/>
        /// The minimum value is 1.<br/>
        /// The returned value is an upper limit and will not necessarily maximize performance.<br/>
        /// This maximum may be larger than supported by a specific kernel (refer to the CL_KERNEL_WORK_GROUP_SIZE query of clGetKernelWorkGroupInfo).
        /// </summary>
        public readonly int MaxWorkGroupSize => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.MaxWorkGroupSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint PreferredVectorWidthChar => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredVectorWidthChar, Cl.GetDeviceInfo);

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint PreferredVectorWidthShort => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredVectorWidthShort, Cl.GetDeviceInfo);

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint PreferredVectorWidthInt => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredVectorWidthInt, Cl.GetDeviceInfo);

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint PreferredVectorWidthLong => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredVectorWidthLong, Cl.GetDeviceInfo);

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint PreferredVectorWidthFloat => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredVectorWidthFloat, Cl.GetDeviceInfo);

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint PreferredVectorWidthDouble => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredVectorWidthDouble, Cl.GetDeviceInfo);

        /// <summary>
        /// Preferred native vector width size for built-in scalar types that can be put into vectors.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_PREFERRED_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint PreferredVectorWidthHalf => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredVectorWidthHalf, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the native ISA vector width.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF must return 0.
        /// </summary>

        public readonly uint NativeVectorWidthChar => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.NativeVectorWidthChar, Cl.GetDeviceInfo);
        /// <summary>
        /// Returns the native ISA vector width.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint NativeVectorWidthShort => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.NativeVectorWidthShort, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the native ISA vector width.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint NativeVectorWidthInt => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.NativeVectorWidthInt, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the native ISA vector width.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint NativeVectorWidthLong => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.NativeVectorWidthLong, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the native ISA vector width.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint NativeVectorWidthFloat => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.NativeVectorWidthFloat, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the native ISA vector width.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint NativeVectorWidthDouble => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.NativeVectorWidthDouble, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the native ISA vector width.<br/>
        /// The vector width is defined as the number of scalar elements that can be stored in the vector.<br/>
        /// If double precision is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_DOUBLE must return 0.<br/>
        /// If the cl_khr_fp16 extension is not supported, CL_DEVICE_NATIVE_VECTOR_WIDTH_HALF must return 0.
        /// </summary>
        public readonly uint NativeVectorWidthHalf => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.NativeVectorWidthHalf, Cl.GetDeviceInfo);

        /// <summary>
        /// Clock frequency of the device in MHz.<br/>
        /// The meaning of this value is implementation-defined.<br/>
        /// For devices with multiple clock domains, the clock frequency for any of the clock domains may be returned.<br/>
        /// For devices that dynamically change frequency for power or thermal reasons, the returned clock frequency may be any valid frequency.
        /// </summary>
        public readonly uint MaxClockFrequency => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxClockFrequency, Cl.GetDeviceInfo);

        /// <summary>
        /// The default compute device address space size of the global address space specified as an unsigned integer value in bits.<br/>
        /// Currently supported values are 32 or 64 bits.
        /// </summary>
        public readonly uint AddressBits => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.AddressBits, Cl.GetDeviceInfo);

        /// <summary>
        /// Max size of memory object allocation in bytes.<br/>
        /// The minimum value is max(min(1024 × 1024 × 1024, 1/4th of CL_DEVICE_GLOBAL_MEM_SIZE), 32 × 1024 × 1024) for devices that are not of type CL_DEVICE_TYPE_CUSTOM.
        /// </summary>
        public readonly ulong MaxMemAllocSize => Utils.GetTInfo<DeviceInfo, ulong>(Handle, DeviceInfo.MaxMemAllocSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_TRUE if images are supported by the OpenCL device and CL_FALSE otherwise.
        /// </summary>
        public readonly bool ImageSupport => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.ImageSupport, Cl.GetDeviceInfo);

        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the read_only qualifier.<br/>
        /// The minimum value is 128 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly uint MaxReadImageArgs => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxReadImageArgs, Cl.GetDeviceInfo);

        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the write_only qualifier.<br/>
        /// The minimum value is 64 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly uint MaxWriteImageArgs => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxWriteImageArgs, Cl.GetDeviceInfo);

        /// <summary>
        /// Max number of image objects arguments of a kernel declared with the write_only or read_write qualifier.<br/>
        /// The minimum value is 64 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly uint MaxReadWriteImageArgs => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxReadWriteImageArgs, Cl.GetDeviceInfo);

        
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'End tag 'summary' does not match the start tag 'Minor_Version'.'
/// <summary>
        /// The intermediate languages that can be supported by clCreateProgramWithIL for this device.<br/>
        /// Returns a space-separated list of IL version strings of the form <IL_Prefix>_<Major_Version>.<br/>
        /// <Minor_Version>.<br/>
        /// For OpenCL 2.<br/>
        /// 2, SPIR-V is a required IL prefix.
        /// </summary>
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'IL_Prefix'.'
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
#pragma warning disable CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'Major_Version'.'
        public readonly string IlVersion => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.IlVersion, Cl.GetDeviceInfo, out _).ToStrg();
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'IL_Prefix'.'
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'summary'.'
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'Expected an end tag for element 'Major_Version'.'
#pragma warning restore CS1570 // XML comment has badly formed XML -- 'End tag 'summary' does not match the start tag 'Minor_Version'.'

        /// <summary>
        /// Max width of 2D image or 1D image not created from a buffer object in pixels.<br/>
        /// The minimum value is 16384 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly int Image2dMaxWidth => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.Image2dMaxWidth, Cl.GetDeviceInfo);

        /// <summary>
        /// Max height of 2D image in pixels.<br/>
        /// The minimum value is 16384 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly int Image2dMaxHeight => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.Image2dMaxHeight, Cl.GetDeviceInfo);

        /// <summary>
        /// Max width of 3D image in pixels.<br/>
        /// The minimum value is 2048 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly int Image3dMaxWidth => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.Image3dMaxWidth, Cl.GetDeviceInfo);

        /// <summary>
        /// Max height of 3D image in pixels.<br/>
        /// The minimum value is 2048 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly int Image3dMaxHeight => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.Image3dMaxHeight, Cl.GetDeviceInfo);

        /// <summary>
        /// Max depth of 3D image in pixels.<br/>
        /// The minimum value is 2048 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly int Image3dMaxDepth => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.Image3dMaxDepth, Cl.GetDeviceInfo);

        /// <summary>
        /// Max number of pixels for a 1D image created from a buffer object.<br/>
        /// The minimum value is 65536 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly int ImageMaxBufferSize => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.ImageMaxBufferSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Max number of images in a 1D or 2D image array.<br/>
        /// The minimum value is 2048 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly int ImageMaxArraySize => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.ImageMaxArraySize, Cl.GetDeviceInfo);

        /// <summary>
        /// Maximum number of samplers that can be used in a kernel.<br/>
        /// The minimum value is 16 if CL_DEVICE_IMAGE_SUPPORT is CL_TRUE.
        /// </summary>
        public readonly uint MaxSamplers => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxSamplers, Cl.GetDeviceInfo);

        /// <summary>
        /// The row pitch alignment size in pixels for 2D images created from a buffer.<br/>
        /// The value returned must be a power of 2.<br/>
        /// If the device does not support images, this value must be 0.
        /// </summary>
        public readonly uint ImagePitchAlignment => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.ImagePitchAlignment, Cl.GetDeviceInfo);

        /// <summary>
        /// This query should be used when a 2D image is created from a buffer which was created using CL_MEM_USE_HOST_PTR.<br/>
        /// The value returned must be a power of 2.<br/>
        /// This query specifies the minimum alignment in pixels of the host_ptr specified to clCreateBuffer.<br/>
        /// If the device does not support images, this value must be 0.
        /// </summary>
        public readonly uint ImageBaseAddressAlignment => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.ImageBaseAddressAlignment, Cl.GetDeviceInfo);

        /// <summary>
        /// The maximum number of pipe objects that can be passed as arguments to a kernel.<br/>
        /// The minimum value is 16.
        /// </summary>
        public readonly uint MaxPipeArgs => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxPipeArgs, Cl.GetDeviceInfo);

        /// <summary>
        /// The maximum number of reservations that can be active for a pipe per work-item in a kernel.<br/>
        /// A work-group reservation is counted as one reservation per work-item.<br/>
        /// The minimum value is 1.
        /// </summary>
        public readonly uint PipeMaxActiveReservations => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PipeMaxActiveReservations, Cl.GetDeviceInfo);

        /// <summary>
        /// The maximum size of pipe packet in bytes.<br/>
        /// The minimum value is 1024 bytes.
        /// </summary>
        public readonly uint PipeMaxPacketSize => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PipeMaxPacketSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Max size in bytes of all arguments that can be passed to a kernel.<br/>
        /// The minimum value is 1024 for devices that are not of type CL_DEVICE_TYPE_CUSTOM.<br/>
        /// For this minimum value, only a maximum of 128 arguments can be passed to a kernel
        /// </summary>
        public readonly int MaxParameterSize => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.MaxParameterSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Alignment requirement (in bits) for sub-buffer offsets.<br/>
        /// The minimum value is the size (in bits) of the largest OpenCL built-in data type supported by the device (long16 in FULL profile, long16 or int16 in EMBEDDED profile) for devices that are not of type CL_DEVICE_TYPE_CUSTOM.
        /// </summary>
        public readonly uint MemBaseAddrAlign => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MemBaseAddrAlign, Cl.GetDeviceInfo);

        /// <summary>
        /// Describes single precision floating-point capability of the device.<br/>
        /// This is a bit-field that describes one or more of the following values: CL_FP_DENORM - denorms are supported CL_FP_INF_NAN - INF and quiet NaNs are supported.<br/>
        /// CL_FP_ROUND_TO_NEAREST-- round to nearest even rounding mode supported CL_FP_ROUND_TO_ZERO - round to zero rounding mode supported CL_FP_ROUND_TO_INF - round to positive and negative infinity rounding modes supported CL_FP_FMA - IEEE754-2008 fused multiply-add is supported.<br/>
        /// CL_FP_CORRECTLY_ROUNDED_DIVIDE_SQRT - divide and sqrt are correctly rounded as defined by the IEEE754 specification.<br/>
        /// CL_FP_SOFT_FLOAT - Basic floating-point operations (such as addition, subtraction, multiplication) are implemented in software.<br/>
        /// For the full profile, the mandated minimum floating-point capability for devices that are not of type CL_DEVICE_TYPE_CUSTOM is: CL_FP_ROUND_TO_NEAREST | CL_FP_INF_NAN.<br/>
        /// For the embedded profile, see the dedicated table.
        /// </summary>
        public readonly DeviceFPConfig SingleFpConfig => Utils.GetTInfo<DeviceInfo, DeviceFPConfig>(Handle, DeviceInfo.SingleFpConfig, Cl.GetDeviceInfo);

        /// <summary>
        /// Describes double precision floating-point capability of the OpenCL device.<br/>
        /// This is a bit-field that describes one or more of the following values: CL_FP_DENORM - denorms are supported CL_FP_INF_NAN - INF and NaNs are supported.<br/>
        /// CL_FP_ROUND_TO_NEAREST - round to nearest even rounding mode supported.<br/>
        /// CL_FP_ROUND_TO_ZERO - round to zero rounding mode supported.<br/>
        /// CL_FP_ROUND_TO_INF - round to positive and negative infinity rounding modes supported.<br/>
        /// CL_FP_FMA - IEEE754-2008 fused multiply-add is supported.<br/>
        /// CL_FP_SOFT_FLOAT - Basic floating-point operations (such as addition, subtraction, multiplication) are implemented in software.<br/>
        /// Double precision is an optional feature so the mandated minimum double precision floating-point capability is 0.<br/>
        /// If double precision is supported by the device, then the minimum double precision floating-point capability must be: CL_FP_FMA | CL_FP_ROUND_TO_NEAREST | CL_FP_INF_NAN | CL_FP_DENORM.
        /// </summary>
        public readonly DeviceFPConfig DoubleFpConfig => Utils.GetTInfo<DeviceInfo, DeviceFPConfig>(Handle, DeviceInfo.DoubleFpConfig, Cl.GetDeviceInfo);

        /// <summary>
        /// Type of global memory cache supported.<br/>
        /// Valid values are: CL_NONE, CL_READ_ONLY_CACHE, and CL_READ_WRITE_CACHE.
        /// </summary>
        public readonly DeviceMemCacheType GlobalMemCacheType => Utils.GetTInfo<DeviceInfo, DeviceMemCacheType>(Handle, DeviceInfo.GlobalMemCacheType, Cl.GetDeviceInfo);

        /// <summary>
        /// Size of global memory cache line in bytes.
        /// </summary>
        public readonly uint GlobalMemCachelineSize => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.GlobalMemCachelineSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Size of global memory cache in bytes.
        /// </summary>
        public readonly ulong GlobalMemCacheSize => Utils.GetTInfo<DeviceInfo, ulong>(Handle, DeviceInfo.GlobalMemCacheSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Size of global device memory in bytes.
        /// </summary>
        public readonly ulong GlobalMemSize => Utils.GetTInfo<DeviceInfo, ulong>(Handle, DeviceInfo.GlobalMemSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Max size in bytes of a constant buffer allocation.<br/>
        /// The minimum value is 64 KB for devices that are not of type CL_DEVICE_TYPE_CUSTOM.
        /// </summary>
        public readonly ulong MaxConstantBufferSize => Utils.GetTInfo<DeviceInfo, ulong>(Handle, DeviceInfo.MaxConstantBufferSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Max number of arguments declared with the __constant qualifier in a kernel.<br/>
        /// The minimum value is 8 for devices that are not of type CL_DEVICE_TYPE_CUSTOM.
        /// </summary>
        public readonly uint MaxConstantArgs => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxConstantArgs, Cl.GetDeviceInfo);

        /// <summary>
        /// The maximum number of bytes of storage that may be allocated for any single variable in program scope or inside a function in an OpenCL kernel language declared in the global address space.<br/>
        /// The minimum value is 64 KB.
        /// </summary>
        public readonly int MaxGlobalVariableSize => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.MaxGlobalVariableSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Maximum preferred total size, in bytes, of all program variables in the global address space.<br/>
        /// This is a performance hint.<br/>
        /// An implementation may place such variables in storage with optimized device access.<br/>
        /// This query returns the capacity of such storage.<br/>
        /// The minimum value is 0.
        /// </summary>
        public readonly int GlobalVariablePreferredTotalSize => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.GlobalVariablePreferredTotalSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Type of local memory supported.<br/>
        /// This can be set to CL_LOCAL implying dedicated local memory storage such as SRAM , or CL_GLOBAL.<br/>
        /// For custom devices, CL_NONE can also be returned indicating no local memory support.
        /// </summary>
        public readonly DeviceLocalMemType LocalMemType => Utils.GetTInfo<DeviceInfo, DeviceLocalMemType>(Handle, DeviceInfo.LocalMemType, Cl.GetDeviceInfo);

        /// <summary>
        /// Size of local memory region in bytes.<br/>
        /// The minimum value is 32 KB for devices that are not of type CL_DEVICE_TYPE_CUSTOM.
        /// </summary>
        public readonly ulong LocalMemSize => Utils.GetTInfo<DeviceInfo, ulong>(Handle, DeviceInfo.LocalMemSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_TRUE if the device implements error correction for all accesses to compute device memory (global and constant).<br/>
        /// Is CL_FALSE if the device does not implement such error correction.
        /// </summary>
        public readonly bool ErrorCorrectionSupport => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.ErrorCorrectionSupport, Cl.GetDeviceInfo);

        /// <summary>
        /// Describes the resolution of device timer.<br/>
        /// This is measured in nanoseconds.<br/>
        /// Refer to Profiling Operations for details.
        /// </summary>
        public readonly int ProfilingTimerResolution => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.ProfilingTimerResolution, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_TRUE if the OpenCL device is a little endian device and CL_FALSE otherwise
        /// </summary>
        public readonly bool EndianLittle => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.EndianLittle, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_TRUE if the device is available and CL_FALSE otherwise.<br/>
        /// A device is considered to be available if the device can be expected to successfully execute commands enqueued to the device.
        /// </summary>
        public readonly bool Available => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.Available, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_FALSE if the implementation does not have a compiler available to compile the program source.<br/>
        /// Is CL_TRUE if the compiler is available.<br/>
        /// This can be CL_FALSE for the embedded platform profile only.
        /// </summary>
        public readonly bool CompilerAvailable => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.CompilerAvailable, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_FALSE if the implementation does not have a linker available.<br/>
        /// Is CL_TRUE if the linker is available.<br/>
        /// This can be CL_FALSE for the embedded platform profile only.<br/>
        /// This must be CL_TRUE if CL_DEVICE_COMPILER_AVAILABLE is CL_TRUE.
        /// </summary>
        public readonly bool LinkerAvailable => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.LinkerAvailable, Cl.GetDeviceInfo);

        /// <summary>
        /// Describes the execution capabilities of the device.<br/>
        /// This is a bit-field that describes one or more of the following values: CL_EXEC_KERNEL - The OpenCL device can execute OpenCL kernels.<br/>
        /// CL_EXEC_NATIVE_KERNEL - The OpenCL device can execute native kernels.<br/>
        /// The mandated minimum capability is: CL_EXEC_KERNEL.
        /// </summary>
        public readonly DeviceExecCapabilities ExecutionCapabilities => Utils.GetTInfo<DeviceInfo, DeviceExecCapabilities>(Handle, DeviceInfo.ExecutionCapabilities, Cl.GetDeviceInfo);

        /// <summary>
        /// Describes the on host command-queue properties supported by the device.<br/>
        /// This is a bit-field that describes one or more of the following values: CL_QUEUE_OUT_OF_ORDER_EXEC_MODE_ENABLE CL_QUEUE_PROFILING_ENABLE These properties are described in the Queue Properties table.<br/>
        /// The mandated minimum capability is: CL_QUEUE_PROFILING_ENABLE.
        /// </summary>
        public readonly CommandQueueProperties QueueOnHostProperties => Utils.GetTInfo<DeviceInfo, CommandQueueProperties>(Handle, DeviceInfo.QueueOnHostProperties, Cl.GetDeviceInfo);

        /// <summary>
        /// Describes the on device command-queue properties supported by the device.<br/>
        /// This is a bit-field that describes one or more of the following values: CL_QUEUE_OUT_OF_ORDER_EXEC_MODE_ENABLE CL_QUEUE_PROFILING_ENABLE These properties are described in the Queue Properties table.<br/>
        /// The mandated minimum capability is: CL_QUEUE_OUT_OF_ORDER_EXEC_MODE_ENABLE | CL_QUEUE_PROFILING_ENABLE.
        /// </summary>
        public readonly CommandQueueProperties QueueOnDeviceProperties => Utils.GetTInfo<DeviceInfo, CommandQueueProperties>(Handle, DeviceInfo.QueueOnDeviceProperties, Cl.GetDeviceInfo);

        /// <summary>
        /// The size of the device queue in bytes preferred by the implementation.<br/>
        /// Applications should use this size for the device queue to ensure good performance.<br/>
        /// The minimum value is 16 KB
        /// </summary>
        public readonly uint QueueOnDevicePreferredSize => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.QueueOnDevicePreferredSize, Cl.GetDeviceInfo);

        /// <summary>
        /// The max.<br/>
        /// size of the device queue in bytes.<br/>
        /// The minimum value is 256 KB for the full profile and 64 KB for the embedded profile
        /// </summary>
        public readonly uint QueueOnDeviceMaxSize => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.QueueOnDeviceMaxSize, Cl.GetDeviceInfo);

        /// <summary>
        /// The maximum number of device queues that can be created for this device in a single context.<br/>
        /// The minimum value is 1.
        /// </summary>
        public readonly uint MaxOnDeviceQueues => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxOnDeviceQueues, Cl.GetDeviceInfo);

        /// <summary>
        /// The maximum number of events in use by a device queue.<br/>
        /// These refer to events returned by the enqueue_built-in functions to a device queue or user events returned by the create_user_event built-in function that have not been released.<br/>
        /// The minimum value is 1024.
        /// </summary>
        public readonly uint MaxOnDeviceEvents => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxOnDeviceEvents, Cl.GetDeviceInfo);

        /// <summary>
        /// A semi-colon separated list of built-in kernels supported by the device.<br/>
        /// An empty string is returned if no built-in kernels are supported by the device.
        /// </summary>
        public readonly string BuiltInKernels => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.BuiltInKernels, Cl.GetDeviceInfo, out _).ToStrg();
        /// <summary>
        /// The platform associated with this device.
        /// </summary>
        public readonly IntPtr Platform => Utils.GetTInfo<DeviceInfo, IntPtr>(Handle, DeviceInfo.Platform, Cl.GetDeviceInfo);

        /// <summary>
        /// Device name string.
        /// </summary>
        public readonly string Name => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.Name, Cl.GetDeviceInfo, out _).ToStrg();

        /// <summary>
        /// Vendor name string.
        /// </summary>
        public readonly string Vendor => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.Vendor, Cl.GetDeviceInfo, out _).ToStrg();

        /// <summary>
        /// OpenCL software driver version string.<br/>
        /// Follows a vendor-specific format.
        /// </summary>
        public readonly string DriverVersion => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.DriverVersion, Cl.GetDeviceInfo, out _).ToStrg();

        /// <summary>
        /// OpenCL profile string.<br/>
        /// Returns the profile name supported by the device.<br/>
        /// The profile name returned can be one of the following strings: FULL_PROFILE - if the device supports the OpenCL specification (functionality defined as part of the core specification and does not require any extensions to be supported).<br/>
        /// EMBEDDED_PROFILE - if the device supports the OpenCL embedded profile.
        /// </summary>
        public readonly IntPtr Profile => Utils.GetTInfo<DeviceInfo, IntPtr>(Handle, DeviceInfo.Profile, Cl.GetDeviceInfo);

        /// <summary>
        /// OpenCL version string.<br/>
        /// Returns the OpenCL version supported by the device.<br/>
        /// This version string has the following format: OpenCL&lt;space>&lt;major_version.<br/>
        /// &lt;minor_version>&lt;space>&lt;vendor-specific information>The major_version.<br/>
        /// minor_version value returned will be one of 1.0, 1.1, 1.2, 2.0, 2.1 or 2.2.
        /// </summary>
        public readonly string Verion => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.Version, Cl.GetDeviceInfo, out _).ToStrg();

        /// <summary>
        /// OpenCL C version string.<br/>
        /// Returns the highest OpenCL C version supported by the compiler for this device that is not of type CL_DEVICE_TYPE_CUSTOM.<br/>
        /// This version string has the following format: OpenCL&lt;space>C&lt;space>&lt;major_version.<br/>
        /// &lt;minor_version>&lt;space>&lt;vendor-specific information> The major_version.<br/>
        /// minor_version value returned must be 2.0 <br/>
        /// if CL_DEVICE_VERSION is OpenCL 2.0, OpenCL 2.1, or OpenCL 2.2.<br/>
        /// The major_version. minor_version value returned must be 1.2<br/>
        /// if CL_DEVICE_VERSION is OpenCL 1.2.<br/>
        /// the major_version.minor_version value returned must be 1.1<br/>
        /// if CL_DEVICE_VERSION is OpenCL 1.1.<br/>
        /// The major_version.minor_version value returned can be 1.0 or 1.1<br/>
        /// if CL_DEVICE_VERSION is OpenCL 1.0.
        /// </summary>
        public readonly string OpenClVersion => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.OpenClVersion, Cl.GetDeviceInfo, out _).ToStrg();
        /// <summary>
        /// Returns a space separated list of extension names (the extension names themselves do not contain any spaces) supported by the device.<br/>
        /// The list of extension names returned can be vendor supported extension names and one or more of the following Khronos approved extension names: cl_khr_int64_base_atomics cl_khr_int64_extended_atomics cl_khr_fp16 cl_khr_gl_sharing cl_khr_gl_event cl_khr_d3d10_sharing cl_khr_dx9_media_sharing cl_khr_d3d11_sharing cl_khr_gl_depth_images cl_khr_gl_msaa_sharing cl_khr_initialize_memory cl_khr_terminate_context cl_khr_spir cl_khr_srgb_image_writes The following approved Khronos extension names must be returned by all devices that support OpenCL C 2.<br/>
        /// 0: cl_khr_byte_addressable_store cl_khr_fp64 (for backward compatibility if double precision is supported) cl_khr_3d_image_writes cl_khr_image2d_from_buffer cl_khr_depth_images Please refer to the OpenCL Extension Specification for a detailed description of these extensions.
        /// </summary>
        public readonly string Extensions => Utils.GetTInfo<DeviceInfo, byte>(Handle, DeviceInfo.Extensions, Cl.GetDeviceInfo, out _).ToStrg();

        /// <summary>
        /// Maximum size in bytes of the internal buffer that holds the output of printf calls from a kernel.<br/>
        /// The minimum value for the FULL profile is 1 MB.
        /// </summary>
        public readonly int PrintfBufferSize => Utils.GetTInfo<DeviceInfo, int>(Handle, DeviceInfo.PrintfBufferSize, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_TRUE if the devices preference is for the user to be responsible for synchronization, when sharing memory objects between OpenCL and other APIs such as DirectX, CL_FALSE if the device / implementation has a performant path for performing synchronization of memory object shared between OpenCL and other APIs such as DirectX.
        /// </summary>
        public readonly bool PreferredInteropUserSync => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.PreferredInteropUserSync, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the IntPtr of the parent device to which this sub-device belongs.<br/>
        /// If device is a root-level device, a NULL value is returned.
        /// </summary>
        public readonly IntPtr ParentDevice => Utils.GetTInfo<DeviceInfo, IntPtr>(Handle, DeviceInfo.ParentDevice, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the maximum number of sub-devices that can be created when a device is partitioned.<br/>
        /// The value returned cannot exceed CL_DEVICE_MAX_COMPUTE_UNITS.
        /// </summary>
        public readonly uint PartitionMaxSubDevices => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PartitionMaxSubDevices, Cl.GetDeviceInfo);
        /// <summary>
        /// Returns the list of partition types supported by device.<br/>
        /// This is an array of DevicePartitionProperty values drawn from the following list: CL_DEVICE_PARTITION_EQUALLY CL_DEVICE_PARTITION_BY_COUNTS CL_DEVICE_PARTITION_BY_AFFINITY_DOMAIN If the device cannot be partitioned (i.<br/>
        /// e.g.:<br/>
        /// there is no partitioning scheme supported by the device that will return at least two subdevices), a value of 0 will be returned.
        /// </summary>
        public readonly DevicePartitionProperty PartitionProperties => Utils.GetTInfo<DeviceInfo, DevicePartitionProperty>(Handle, DeviceInfo.PartitionProperties, Cl.GetDeviceInfo);


        /// <summary>
        /// Returns the list of supported affinity domains for partitioning the device using CL_DEVICE_PARTITION_BY_AFFINITY_DOMAIN.<br/>
        /// This is a bit-field that describes one or more of the following values: CL_DEVICE_AFFINITY_DOMAIN_NUMA CL_DEVICE_AFFINITY_DOMAIN_L4_CACHE CL_DEVICE_AFFINITY_DOMAIN_L3_CACHE CL_DEVICE_AFFINITY_DOMAIN_L2_CACHE CL_DEVICE_AFFINITY_DOMAIN_L1_CACHE CL_DEVICE_AFFINITY_DOMAIN_NEXT_PARTITIONABLE If the device does not support any affinity domains, a value of 0 will be returned.
        /// </summary>
        public readonly DeviceAffinityDomain PartitionAffinityDomain => Utils.GetTInfo<DeviceInfo, DeviceAffinityDomain>(Handle, DeviceInfo.PartitionAffinityDomain, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the properties argument specified in clCreateSubDevices if device is a sub-device.<br/>
        /// In the case where the properties argument to clCreateSubDevices is CL_DEVICE_PARTITION_BY_AFFINITY_DOMAIN, CL_DEVICE_AFFINITY_DOMAIN_NEXT_PARTITIONABLE, the affinity domain used to perform the partition will be returned.<br/>
        /// This can be one of the following values: CL_DEVICE_AFFINITY_DOMAIN_NUMA CL_DEVICE_AFFINITY_DOMAIN_L4_CACHE CL_DEVICE_AFFINITY_DOMAIN_L3_CACHE CL_DEVICE_AFFINITY_DOMAIN_L2_CACHE CL_DEVICE_AFFINITY_DOMAIN_L1_CACHE Otherwise the implementation may either return a param_value_size_ret of 0 i.<br/>
        /// e.g.:<br/>
        /// there is no partition type associated with device or can return a property value of 0 (where 0 is used to terminate the partition property list) in the memory that param_value points to.
        /// </summary>
        public readonly DevicePartitionProperty PartitionType => Utils.GetTInfo<DeviceInfo, DevicePartitionProperty>(Handle, DeviceInfo.PartitionType, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the device reference count.<br/>
        /// If the device is a root-level device, a reference count of one is returned.
        /// </summary>
        public readonly uint ReferenceCount => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.ReferenceCount, Cl.GetDeviceInfo);

        /// <summary>
        /// Describes the various shared virtual memory (a.<br/>
        /// k.<br/>
        /// a.<br/>
        /// SVM) memory allocation types the device supports.<br/>
        /// Coarse-grain SVM allocations are required to be supported by all OpenCL 2.<br/>
        /// 0 devices.<br/>
        /// This is a bit-field that describes a combination of the following values: CL_DEVICE_SVM_COARSE_GRAIN_BUFFER - Support for coarse-grain buffer sharing using clSVMAlloc.<br/>
        /// Memory consistency is guaranteed at synchronization points and the host must use calls to clEnqueueMapBuffer and clEnqueueUnmapMemObject.<br/>
        /// CL_DEVICE_SVM_FINE_GRAIN_BUFFER - Support for fine-grain buffer sharing using clSVMAlloc.<br/>
        /// Memory consistency is guaranteed at synchronization points without need for clEnqueueMapBuffer and clEnqueueUnmapMemObject.<br/>
        /// CL_DEVICE_SVM_FINE_GRAIN_SYSTEM - Support for sharing the host&#8217;s entire virtual memory including memory allocated using malloc.<br/>
        /// Memory consistency is guaranteed at synchronization points.<br/>
        /// CL_DEVICE_SVM_ATOMICS - Support for the OpenCL 2.<br/>
        /// 0 atomic operations that provide memory consistency across the host and all OpenCL devices supporting fine-grain SVM allocations.<br/>
        /// The mandated minimum capability is CL_DEVICE_SVM_COARSE_GRAIN_BUFFER.
        /// </summary>
        public readonly SVMCapabilities SvmCapabilities => Utils.GetTInfo<DeviceInfo, SVMCapabilities>(Handle, DeviceInfo.SvmCapabilities, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.<br/>
        /// 0 fine-grained SVM atomic types.<br/>
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        public readonly uint PreferredPlatformAtomicAlignment => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredPlatformAtomicAlignment, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.<br/>
        /// 0 atomic types to global memory.<br/>
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        public readonly uint PreferredGlobalAtomicAlignment => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredGlobalAtomicAlignment, Cl.GetDeviceInfo);

        /// <summary>
        /// Returns the value representing the preferred alignment in bytes for OpenCL 2.<br/>
        /// 0 atomic types to local memory.<br/>
        /// This query can return 0 which indicates that the preferred alignment is aligned to the natural size of the type.
        /// </summary>
        public readonly uint PreferredLocalAtomicAlignment => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.PreferredLocalAtomicAlignment, Cl.GetDeviceInfo);

        /// <summary>
        /// Maximum number of sub-groups in a work-group that a device is capable of executing on a single compute unit, for any given kernel-instance running on the device.<br/>
        /// The minimum value is 1.<br/>
        /// (Refer also to clGetKernelSubGroupInfo.)
        /// </summary>
        public readonly uint MaxNumSubGroups => Utils.GetTInfo<DeviceInfo, uint>(Handle, DeviceInfo.MaxNumSubGroups, Cl.GetDeviceInfo);

        /// <summary>
        /// Is CL_TRUE if this device supports independent forward progress of sub-groups, CL_FALSE otherwise.<br/>
        /// If cl_khr_subgroups is supported by the device this must return CL_TRUE.
        /// </summary>
        public readonly bool SubGroupIndependentForwardProgress => Utils.GetTInfo<DeviceInfo, bool>(Handle, DeviceInfo.SubGroupIndependentForwardProgress, Cl.GetDeviceInfo);

        public unsafe Context CreateContext()
            => new Context(Cl.CreateContext(null, 1, new[] { this }, null, IntPtr.Zero, out ErrorCode _));
        public void Dispose() => Cl.ReleaseDevice(Handle);

        public static implicit operator IntPtr(Device device) => device.Handle;
    }
}