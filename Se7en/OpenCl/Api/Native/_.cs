using System;
using System.IO;
using System.Reflection;

namespace Se7en.OpenCl.Api.Native
{
    public delegate void ContextNotify(string errInfo, byte[] data, IntPtr cb, IntPtr userData);
    public delegate void ProgramNotify(Program program, IntPtr userData);
}


/**
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 **/
