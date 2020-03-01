using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Se7en
{
    static class InternalLibLoader
    {
        public const string OpenCL = "OpenCL.dll";
        public const string D3D11 = "d3d11.dll";

        static InternalLibLoader()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                return e.Name switch
                {
                    OpenCL => LoadLib(sender, OpenCL),
                    D3D11 => LoadLib(sender, D3D11),
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
