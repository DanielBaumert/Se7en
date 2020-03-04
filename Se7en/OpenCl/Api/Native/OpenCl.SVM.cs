using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{

    public unsafe static partial class Cl
    {
        /// <summary>
        /// Allocates a shared virtual memory (SVM) buffer that can be shared by the host and all devices in an OpenCL context that support shared virtual memory.
        /// </summary>
        /// <param name="context">
        /// A valid OpenCL context used to create the SVM buffer.
        /// </param>
        /// <param name="flags">
        /// A bit-field that is used to specify allocation and usage information.
        /// </param>
        /// <param name="size">
        /// The size in bytes of the SVM buffer to be allocated.
        /// </param>
        /// <param name="alignment">
        /// The minimum alignment in bytes that is required for the newly created buffer’s memory region.<br/>
        /// It must be a power of two up to the largest data type supported by the OpenCL device.<br/>
        /// For the full profile, the largest data type is long16.<br/>
        /// For the embedded profile, it is long16 if the device supports 64-bit integers; otherwise it is int16.<br/>
        /// If alignment is 0, a default alignment will be used that is equal to the size of largest data type supported by the OpenCL implementation.</param>
        /// <returns></returns>
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clSVMAlloc")]
        public static extern IntPtr SVMAlloc(Context context,
                                          SVMMemFlags flags,
                                          IntPtr size,
                                          uint alignment = 0);

        /// <summary>
        /// Frees a shared virtual memory buffer allocated using clSVMAlloc.
        /// </summary>
        /// <param name="context">
        /// A valid OpenCL context used to create the SVM buffer.
        /// </param>
        /// <param name="svmPointer">
        /// Must be the value returned by a call to clSVMAlloc.<br/>
        /// If a NULL pointer is passed in svm_pointer, no action occurs.
        /// </param>
        /// <returns></returns>
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clSVMFree")]
        public static extern void SVMFree(Context context, IntPtr svmPointer);

        /// <summary>
        /// Enqueues a command that will allow the host to update a region of a SVM buffer
        /// </summary>
        /// <param name="commandQueue">
        /// Must be a valid host command-queue.
        /// </param>
        /// <param name="blockingMap">
        /// Indicates if the map operation is blocking or non-blocking.<para/>
        /// 1 : does not return until the application can access the contents of the SVM region specified by svm_ptr and size on the host.<br/>
        /// 0 : map operation is non-blocking, the region specified by svm_ptr and size cannot be used until the map command has completed.<br/>
        /// The event argument returns an event object which can be used to query the execution status of the map command.<br/>
        /// When the map command is completed, the application can access the contents of the region specified by svm_ptr and size.
        /// </param>
        /// <param name="mapFlags"></param>
        /// <param name="svmPtr">
        /// A pointer to a memory region and size in bytes that will be updated by the host.<br/>
        /// If svm_ptr is allocated using clSVMAlloc then it must be allocated from the same context from which command_queue was created.<br/>
        /// Otherwise the behavior is undefined.
        /// </param>
        /// <param name="size">
        /// A pointer to a memory region and size in bytes that will be updated by the host.<br/>
        /// If svm_ptr is allocated using clSVMAlloc then it must be allocated from the same context from which command_queue was created.<br/>
        /// Otherwise the behavior is undefined.
        /// </param>
        /// <param name="numEventsInWaitList"></param>
        /// <param name="eventWaitList"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clEnqueueSVMMap")]
        public static extern ErrorCode EnqueueSVMMap(IntPtr commandQueue,
                                                     int blockingMap,
                                                     MapFlags mapFlags,
                                                     IntPtr svmPtr,
                                                     IntPtr size,
                                                     uint numEventsInWaitList,
                                                     [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 6)] Event[] eventWaitList,
                                                     [Out] [MarshalAs(UnmanagedType.Struct)] out Event e);

        /// <summary>
        /// Enqueues a command to indicate that the host has completed updating the region given by svm_ptr and which was specified in a previous call to clEnqueueSVMMap.
        /// </summary>
        /// <param name="commandQueue">
        /// Must be a valid host command-queue.
        /// </param>
        /// <param name="svmPtr">
        /// A pointer that was specified in a previous call to clEnqueueSVMMap.<br/>
        /// If svmPtr is allocated using SVMAlloc then it must be allocated from the same context from which command_queue was created.<br/>
        /// Otherwise the behavior is undefined.
        /// </param>
        /// <param name="numEventsInWaitList">
        /// Specify events that need to complete before clEnqueueSVMUnmap can be executed.<br/>
        /// If event_wait_list is NULL, then clEnqueueSVMUnmap does not wait on any event to complete.
        /// </param>
        /// <returns></returns>
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clEnqueueSVMUnmap ")]
        public static extern ErrorCode EnqueueSVMUnmap(IntPtr commandQueue,
                                                  IntPtr svmPtr,
                                                  uint numEventsInWaitList,
                                                  [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 6)] Event[] eventWaitList,
                                                  [Out] [MarshalAs(UnmanagedType.Struct)] out Event e);

        


        /// <summary>
        /// Used to set a SVM pointer as the argument value for a specific argument of a kernel.
        /// </summary>
        /// <param name="kernel">
        /// A valid kernel object
        /// </param>
        /// <param name="argIndex">
        /// The argument index. Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, where n is the total number of arguments declared by a kernel.
        /// </param>
        /// <param name="arg">
        /// The SVM pointer that should be used as the argument value for argument specified by argIndex.<br/>
        ///  if the argument is declared to be global float4 *p, the SVM pointer value passed for p must be at a minimum aligned to a float4.
        /// </param>
        /// <returns></returns>
        [DllImport(InternalLibLoader.OpenCL, EntryPoint = "clSetKernelArgSVMPointer")]
        public static extern ErrorCode SetKernelArgSVMPointer(Kernel kernel,
                                                              uint argIndex,
                                                              IntPtr arg);
    }
}


/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
