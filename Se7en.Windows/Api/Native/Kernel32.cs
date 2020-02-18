using Se7en.Windows.Api.Enum;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace Se7en.Windows.Api.Native
{
    public static class Kernel32
    {
        /// <summary>
        /// Retrieves the calling thread's last-error code value.<br/>
        /// The last-error code is maintained on a per-thread basis.<br/>
        /// Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <returns>
        /// The return value is the calling thread's last-error code.
        /// </returns>
        [DllImport(ExternDll.Kernel32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern uint GetLastError();
        /// <summary>
        /// Retrieves information about the current system. <para/>
        /// To retrieve accurate information for an application running on WOW64, call the GetNativeSystemInfo function.
        /// </summary>
        /// <param name="lpSystemInfo">
        /// A pointer to a SYSTEM_INFO structure that receives the information.
        /// </param>
        [DllImport(ExternDll.Kernel32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern void GetSystemInfo(ref SystemInfo lpSystemInfo);

        /// <summary>
        /// Retrieves information about the current system to an application running under WOW64.<br/>
        /// If the function is called from a 64-bit application, or on a 64-bit system that does not have an<br/>
        /// Intel64 or x64 processor (such as ARM64), it is equivalent to the GetSystemInfo function.
        /// </summary>
        /// <param name="lpSystemInfo">
        /// A pointer to a SYSTEM_INFO structure that receives the information.
        /// </param>
        /// <remarks>
        /// To determine whether a Win32-based application is running under WOW64, call the IsWow64Process2 function.
        /// </remarks>
        [DllImport(ExternDll.Kernel32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern void GetNativeSystemInfo(ref SystemInfo lpSystemInfo);

        /// <summary>
        /// Determines whether the specified process is running under WOW64 or an Intel64 of x64 processor.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. 
        /// </param>
        /// <param name="Wow64Process">
        /// A pointer to a value that is set to TRUE if the process is running under WOW64 on an Intel64 or x64 processor.<br/>
        /// If the process is running under 32-bit Windows, the value is set to FALSE.<br/>
        /// If the process is a 32-bit application running under 64-bit Windows 10 on ARM, the value is set to FALSE.<br/>
        /// If the process is a 64-bit application running under 64-bit Windows, the value is also set to FALSE.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        // BOOL IsWow64Process(HANDLE hProcess, PBOOL Wow64Process);
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out, MarshalAs(UnmanagedType.Bool)] out bool Wow64Process);

        /// <summary>
        /// Determines whether the specified process is running under WOW64; also returns additional machine process and architecture information.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
        /// </param>
        /// <param name="pProcessMachine">
        /// On success, returns a pointer to an IMAGE_FILE_MACHINE_* value. The value will be IMAGE_FILE_MACHINE_UNKNOWN if the target process is not a WOW64 process; otherwise, it will identify the type of WoW process.
        /// </param>
        /// <param name="pNativeMachine">
        /// On success, returns a pointer to a possible IMAGE_FILE_MACHINE_* value identifying the native architecture of host system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        // BOOL IsWow64Process2(HANDLE hProcess, USHORT *pProcessMachine, USHORT *pNativeMachine);
        public static extern bool IsWow64Process2([In] IntPtr hProcess, ref ushort pProcessMachine, ref ushort pNativeMachine);


        /// <summary>
        /// Determines whether the specified process is running under WOW64; also returns additional machine process and architecture information.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
        /// </param>
        /// <param name="pProcessMachine">
        /// On success, returns a pointer to an IMAGE_FILE_MACHINE_* value. The value will be IMAGE_FILE_MACHINE_UNKNOWN if the target process is not a WOW64 process; otherwise, it will identify the type of WoW process.
        /// </param>
        /// <param name="pNativeMachine">
        /// On success, returns a pointer to a possible IMAGE_FILE_MACHINE_* value identifying the native architecture of host system.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        // BOOL IsWow64Process2(HANDLE hProcess, USHORT *pProcessMachine, USHORT *pNativeMachine);
        public static extern bool IsWow64Process2([In] IntPtr hProcess, ref ImageFileMachine pProcessMachine, ref ImageFileMachine pNativeMachine);
      
        /// <summary>
        /// Loads the specified module into the address space of the calling process.<br/>
        /// The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpFileName">
        /// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file).<br/>
        /// The name specified is the file name of the module and is not related to the name stored in the library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.<para/>
        /// If the string specifies a full path, the function searches only that path for the module.<para/>
        /// If the string specifies a relative path or a module name without a path, the function uses a standard search strategy to find the module; for more information, see the Remarks.<para/>
        /// If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (), not forward slashes (/). For more information about paths, see Naming a File or Directory.<para/>
        /// If the string specifies a module name without a path and the file name extension is omitted, the function appends the default library extension .dll to the module name. To prevent the function from appending .dll to the module name, include a trailing point character (.) in the module name string.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the module.<br/>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.<para/>
        /// To avoid the race conditions described in the Remarks section, use the GetModuleHandleEx function.<para/>
        /// The returned handle is not global or inheritable. It cannot be duplicated or used by another process.
        /// </summary>
        /// <param name="moduleName">
        /// The name of the loaded module (either a .dll or .exe file).<br/>
        /// If the file name extension is omitted, the default library extension .dll is appended.<br/>
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.<br/>
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (), not forward slashes (/).<br/>
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.<para/>
        /// If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe file).<para/>
        /// The GetModuleHandle function does not retrieve handles for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag. <br/>
        /// For more information, see LoadLibraryEx.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified module.<para/>
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPStr)] string moduleName);
        /// <summary>
        /// Retrieves a module handle for the specified module and increments the module's reference count unless GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT is specified.<br/>
        /// The module must have been loaded by the calling process.<para/>
        /// The handle returned is not global or inheritable. It cannot be duplicated or used by another process.
        /// </summary>
        /// <param name="dwFlag">
        /// This parameter can be zero or one or more of the following values.<br/>
        /// If the module's reference count is incremented, the caller must use the FreeLibrary function to decrement the reference count when the module handle is no longer needed.
        /// </param>
        /// <param name="moduleName">
        /// The name of the loaded module (either a .dll or .exe file), or an address in the module (if dwFlags is GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS).<para/>
        /// For a module name, if the file name extension is omitted, the default library extension .dll is appended.<br/>
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.<br/>
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (), not forward slashes (/).<br/>
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.<para/>
        /// If this parameter is NULL, the function returns a handle to the file used to create the calling process (.exe file).
        /// </param>
        /// <param name="phModule">
        /// A handle to the specified module. If the function fails, this parameter is NULL.<para/>
        /// The GetModuleHandleEx function does not retrieve handles for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag.<br/>
        /// For more information, see LoadLibraryEx.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<para/>
        /// If the function fails, the return value is zero. To get extended error information, see GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        [ResourceExposure(ResourceScope.Process)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleHandleEx(int dwFlag, [MarshalAs(UnmanagedType.LPStr)] string moduleName, out IntPtr phModule);
        /// <summary>
        /// Retrieves a module handle for the specified module and increments the module's reference count unless GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT is specified.<br/>
        /// The module must have been loaded by the calling process.<para/>
        /// The handle returned is not global or inheritable. It cannot be duplicated or used by another process.
        /// </summary>
        /// <param name="dwFlag">
        /// This parameter can be zero or one or more of the following values.<br/>
        /// If the module's reference count is incremented, the caller must use the FreeLibrary function to decrement the reference count when the module handle is no longer needed.
        /// </param>
        /// <param name="moduleName">
        /// The name of the loaded module (either a .dll or .exe file), or an address in the module (if dwFlags is GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS).<para/>
        /// For a module name, if the file name extension is omitted, the default library extension .dll is appended.<br/>
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.<br/>
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (), not forward slashes (/).<br/>
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.<para/>
        /// If this parameter is NULL, the function returns a handle to the file used to create the calling process (.exe file).
        /// </param>
        /// <param name="phModule">
        /// A handle to the specified module. If the function fails, this parameter is NULL.<para/>
        /// The GetModuleHandleEx function does not retrieve handles for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag.<br/>
        /// For more information, see LoadLibraryEx.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<para/>
        /// If the function fails, the return value is zero. To get extended error information, see GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        [ResourceExposure(ResourceScope.Process)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleHandleEx(ModuleHandleExFlag dwFlag, [MarshalAs(UnmanagedType.LPStr)] string moduleName, out IntPtr phModule);
        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count.<br/>
        /// When the reference count reaches zero, the module is unloaded from the address space of the calling process and the handle is no longer valid.
        /// </summary>
        /// <param name="hModule">
        /// A handle to the loaded library module. The LoadLibrary, LoadLibraryEx,GetModuleHandle, or GetModuleHandleEx function returns this handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<para/>
        /// If the function fails, the return value is zero. To get extended error information, see GetLastError. 
        /// </returns>
        [DllImport(ExternDll.Kernel32, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="hModule">
        /// A handle to the DLL module that contains the function or variable. The LoadLibrary, LoadLibraryEx, LoadPackagedLibrary, or GetModuleHandle function returns this handle.<para/>
        /// The GetProcAddress function does not retrieve addresses from modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag.
        /// </param>
        /// <param name="methodName">
        /// The function or variable name, or the function's ordinal value.<br/>
        /// If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.
        /// </param>
        /// <returns></returns>
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Ansi, BestFitMapping = false, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string methodName);

        /// <summary>
        /// Sets the label of a file system volume.
        /// </summary>
        /// <param name="lpRootPathName">
        /// A pointer to a string that contains the volume's drive letter (for example, X:) or the path of a mounted folder that is associated with the volume (for example, Y:\MountX).<br/>
        /// The string must end with a trailing backslash ('').<br/>
        /// If this parameter is NULL, the root of the current directory is used.
        /// </param>
        /// <param name="lpVolumeName">
        /// A pointer to a string that contains the new label for the volume.<br/>
        /// If this parameter is NULL, the function deletes any existing label from the specified volume and does not assign a new label.<para/>
        /// The maximum volume label length is 32 characters.<br/>
        /// FAT filesystems:  The maximum volume label length is 11 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetVolumeLabelA(string lpRootPathName, string lpVolumeName);
        /// <summary>
        /// Sets the label of a file system volume.
        /// </summary>
        /// <param name="lpRootPathName">
        /// A pointer to a string that contains the volume's drive letter (for example, X:) or the path of a mounted folder that is associated with the volume (for example, Y:\MountX).<br/>
        /// The string must end with a trailing backslash ('').<br/>
        /// If this parameter is NULL, the root of the current directory is used.
        /// </param>
        /// <param name="lpVolumeName">
        /// A pointer to a string that contains the new label for the volume.<br/>
        /// If this parameter is NULL, the function deletes any existing label from the specified volume and does not assign a new label.<para/>
        /// The maximum volume label length is 32 characters.<br/>
        /// FAT filesystems:  The maximum volume label length is 11 characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.<br/>
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetVolumeLabelW(string lpRootPathName, string lpVolumeName);

        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern uint GetTempPath(int bufferLen, [Out] StringBuilder buffer);

        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr OpenProcess(int access, bool inherit, int processId);


        #region ProcessMemory
        #region Read
        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] IntPtr lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);
        #endregion
        #region Write
        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr Dest, IntPtr sourceAddress, IntPtr size, out IntPtr bytesWritten);

        [DllImport(ExternDll.Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);
        #endregion
        #endregion




    }
}
