using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Se7en.Windows.Api.Native
{
    public static class Advapi32
    {
        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(IntPtr hKey, string subKey, int ulOptions, int samDesired, out IntPtr hkResult);

    }
}
