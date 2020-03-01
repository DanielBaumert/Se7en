using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace Se7en.Windows.Api.Native
{
    public static class Psapi
    {
        [DllImport(ExternDll.Psapi, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool EnumProcessModules(IntPtr handle, IntPtr modules, int size, ref int needed);

        [DllImport(ExternDll.Psapi, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool EnumProcesses(int[] processIds, int size, out int needed);

        [DllImport(ExternDll.Psapi, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetModuleFileNameEx(HandleRef processHandle, HandleRef moduleHandle, StringBuilder baseName, int size);

        [DllImport(ExternDll.Psapi, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool GetModuleInformation(IntPtr processHandle, HandleRef moduleHandle, NtModuleInfo ntModuleInfo, int size);
        [DllImport(ExternDll.Psapi, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetModuleBaseName(IntPtr processHandle, HandleRef moduleHandle, StringBuilder baseName, int size);
        [DllImport(ExternDll.Psapi, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetModuleFileNameEx(IntPtr processHandle, HandleRef moduleHandle, StringBuilder baseName, int size);
    }
}
