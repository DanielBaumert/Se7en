using System;

namespace Se7en.OpenCl.Api.Enum
{
    [Flags]
    public enum MapFlags : uint
    {
        /// <summary>
        /// This flag specifies that the region being mapped in the memory object is being mapped for reading.
        /// </summary>
        Read = (1 << 0),
        /// <summary>
        /// This flag specifies that the region being mapped in the memory object is being mapped for writing.
        /// </summary>
        Write = (1 << 1),
        /// <summary>
        /// This flag specifies that the region being mapped in the memory object is being mapped for writing.<br/>
        /// MapFlags.Read or MapFlags.Write and MapFlags.WriteInvalidateRegion are mutually exclusive.
        /// </summary>
        WriteInvalidateRegion = (1 << 2),
    }
}


/*
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 */
