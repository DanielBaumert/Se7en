﻿using Se7en.OpenCl.Api.Enum;
using System;
using System.Runtime.InteropServices;

namespace Se7en.OpenCl.Api.Native
{
    public unsafe static partial class Cl
    {

        [DllImport(Library, EntryPoint = "clWaitForEvents")]
        public static extern ErrorCode WaitForEvents(uint numEvents,
                                                       [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysUInt, SizeParamIndex = 0)] Event[] eventWaitList);

        [DllImport(Library, EntryPoint = "clGetEventInfo")]
        public static extern ErrorCode GetEventInfo(IntPtr e,
                                                      EventInfo paramName,
                                                      uint paramValueSize,
                                                      void* paramValue,
                                                      out uint paramValueSizeRet);

        [DllImport(Library, EntryPoint = "clRetainEvent")]
        public static extern ErrorCode RetainEvent(IntPtr e);

        [DllImport(Library, EntryPoint = "clReleaseEvent")]
        public static extern ErrorCode ReleaseEvent(IntPtr e);

    }
}


/**
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 **/
