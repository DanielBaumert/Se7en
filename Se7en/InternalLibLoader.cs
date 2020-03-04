using System;
using System.IO;
using System.Reflection;

namespace Se7en
{
    static class InternalLibLoader
    {
#if Windows
        public const string OpenCL = "OpenCL.dll";
#elif Linux
        public const string OpenCL = "libOpenCL.so";
#endif

        static InternalLibLoader()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                return e.Name switch
                {
                    OpenCL => LoadLib(sender, OpenCL),
                    _ => null,
                };
            };
        }

        private static Assembly LoadLib(object obj, string lib)
        {

            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(lib))
            using (MemoryStream ms = new MemoryStream())
            {
                s.CopyTo(ms);
                return ((AppDomain)obj).Load(ms.ToArray());
            }
        }

    }
}