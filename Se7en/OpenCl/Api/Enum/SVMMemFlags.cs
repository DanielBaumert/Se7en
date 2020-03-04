using System;

namespace Se7en.OpenCl.Api.Enum
{
    [Flags]
    public enum SVMMemFlags
    {
        /// <summary>
        /// This flag specifies that the SVM buffer will be read and written by a kernel. This is the default.
        /// </summary>
        ReadWrite = (1 << 0),
        /// <summary>
        /// This flag specifies that the SVM buffer will be written but not read by a kernel.<br/>
        /// Reading from a SVM buffer created with CL_MEM_WRITE_ONLY inside a kernel is undefined.<br/>
        /// ReadWrite and WriteOnly are mutually exclusive.
        /// </summary>
        WriteOnly = (1 << 1),
        /// <summary>
        /// This flag specifies that the SVM buffer object is a read-only memory object when used inside a kernel.<br/>
        /// Writing to a SVM buffer created with CL_MEM_READ_ONLY inside a kernel is undefined.<br/>
        /// ReadWrite or WriteOnly and ReadOnly are mutually exclusive.
        /// </summary>
        ReadOnly = (1 << 2),
        /// <summary>
        /// This specifies that the application wants the OpenCL implementation to do a fine-grained allocation.
        /// </summary>
        FineGrainBuffer = (1 << 10),
        /// <summary>
        /// This flag is valid only if CL_MEM_SVM_FINE_GRAIN_BUFFER is specified in flags.<br/>
        /// It is used to indicate that SVM atomic operations can control visibility of memory accesses in this SVM buffer.
        /// </summary>
        Atomic = (1 << 11),
    }
}


/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
