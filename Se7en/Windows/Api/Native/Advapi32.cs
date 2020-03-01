using Microsoft.Win32.SafeHandles;
using Se7en.Windows.Api.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace Se7en.Windows.Api.Native
{
    public static class Advapi32
    {
        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        internal static extern int RegConnectRegistry(String machineName,
                    SafeRegistryHandle key, out SafeRegistryHandle result);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        internal static extern int RegCreateKeyEx(SafeRegistryHandle hKey, String lpSubKey,
                    int Reserved, string lpClass, int dwOptions,
                    int samDesired, SecurityAttributes lpSecurityAttributes,
                    out SafeRegistryHandle hkResult, out int lpdwDisposition);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        internal static extern int RegDeleteKey(SafeRegistryHandle hKey, String lpSubKey);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        internal static extern int RegDeleteKeyEx(SafeRegistryHandle hKey, String lpSubKey,
                    int samDesired, int Reserved);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        internal static extern int RegDeleteValue(SafeRegistryHandle hKey, String lpValueName);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal unsafe static extern int RegEnumKeyEx(SafeRegistryHandle hKey, int dwIndex,
                    char* lpName, ref int lpcbName, int[] lpReserved,
                    [Out]StringBuilder lpClass, int[] lpcbClass,
                    long[] lpftLastWriteTime);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal unsafe static extern int RegEnumValue(SafeRegistryHandle hKey, int dwIndex,
                    char* lpValueName, ref int lpcbValueName,
                    IntPtr lpReserved_MustBeZero, int[] lpType, byte[] lpData,
                    int[] lpcbData);


        [DllImport(ExternDll.Advapi32)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegFlushKey(SafeRegistryHandle hKey);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        internal static extern int RegOpenKeyEx(SafeRegistryHandle hKey, String lpSubKey,
                    int ulOptions, int samDesired, out SafeRegistryHandle hkResult);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        internal static extern int RegOpenKeyEx(IntPtr hKey, String lpSubKey,
                    int ulOptions, int samDesired, out SafeRegistryHandle hkResult);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegQueryInfoKey(SafeRegistryHandle hKey, [Out]StringBuilder lpClass,
                    int[] lpcbClass, IntPtr lpReserved_MustBeZero, ref int lpcSubKeys,
                    int[] lpcbMaxSubKeyLen, int[] lpcbMaxClassLen,
                    ref int lpcValues, int[] lpcbMaxValueNameLen,
                    int[] lpcbMaxValueLen, int[] lpcbSecurityDescriptor,
                    int[] lpftLastWriteTime);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, [Out] byte[] lpData,
                    ref int lpcbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, ref int lpData,
                    ref int lpcbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, ref long lpData,
                    ref int lpcbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                     int[] lpReserved, ref int lpType, [Out] char[] lpData,
                     ref int lpcbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, [Out]StringBuilder lpData,
                    ref int lpcbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, byte[] lpData, int cbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, ref int lpData, int cbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, ref long lpData, int cbData);

        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, String lpData, int cbData);


    }

}
