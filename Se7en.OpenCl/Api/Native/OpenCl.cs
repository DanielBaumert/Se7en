using System;
using System.IO;
using System.Reflection;

namespace Se7en.OpenCl.Api.Native
{
    public delegate void ContextNotify(string errInfo, byte[] data, IntPtr cb, IntPtr userData);
    public delegate void ProgramNotify(Program program, IntPtr userData);
    public unsafe static partial class Cl
    {
        private const string Library = "OpenCL.dll";

        static Cl()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                if (e.Name == "OpenCl.dll")
                {
                    using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("OpenCl.dll"))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        s.CopyTo(ms);
                        return ((AppDomain)sender).Load(ms.ToArray());
                    }
                }

                return null;
            };
        }


    }
}


/**
 * \[DllImport\(Library\)\]\s*\n\s+((?:[^\s]+\s){4})(cl([^(]+))
 * [DllImport(Library, EntryPoint = "$2")]\n$1$3
 **/
