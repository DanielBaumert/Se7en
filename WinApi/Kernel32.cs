using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.WinApi
{
    public class Kernel32
    {
        public const string ImportKey = "kernel32.dll";

        [DllImport(ImportKey, EntryPoint = "GetCurrentProcess", SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();

        [DllImport(ImportKey, EntryPoint = "CopyMemory", SetLastError = true)]
        public static extern void CopyMemory([In]IntPtr dest, [In] IntPtr src, uint count);
        [DllImport(ImportKey, EntryPoint = "MoveMemory", SetLastError = true)]
        public static extern void MoveMemory([In] IntPtr dest, [In] IntPtr src, uint count);
        [DllImport(ImportKey, EntryPoint = "GlobalAlloc", SetLastError = true)]
        public static extern IntPtr GlobalAlloc(GlobalAllocFlag flag, int byteCount);
        [DllImport(ImportKey, EntryPoint = "GlobalFree", SetLastError = true)]
        public static extern IntPtr GlobalFree(IntPtr memPtr);
        /// <summary>
        /// Opens an existing local process object.
        /// </summary>
        /// <param name="processAccess"></param>
        /// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
        /// <param name="processID">The identifier of the local process to be opened.</param>
        /// <returns>If the function succeeds, the return value is an open handle to the specified process.</returns>
        [DllImport(ImportKey, EntryPoint = "OpenProcess", SetLastError = true)]
        public static extern IntPtr OpenProcess(ProcessAccessFlag processAccess, bool bInheritHandle, int processID);
        /// <summary>
        /// Retrieves the process identifier of the specified process.
        /// </summary>
        /// <param name="process">A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.</param>
        /// <returns>return the process id</returns>
        [DllImport(ImportKey, EntryPoint = "GetProcessId", SetLastError = true)]
        public static extern int GetProcessId(IntPtr process);

        /// <summary>
        /// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
        /// <param name="dwSize">The number of bytes to be read from the specified process.</param>
        /// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is NULL, the parameter is ignored.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "ReadProcessMemory", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,[Out] byte[] lpBuffer,int dwSize, out IntPtr lpNumberOfBytesRead);

        /// <summary>
        /// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">A handle to the process with memory that is being read. The handle must have PROCESS_VM_READ access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
        /// <param name="dwSize">The number of bytes to be read from the specified process.</param>
        /// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes transferred into the specified buffer. If lpNumberOfBytesRead is NULL, the parameter is ignored.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "ReadProcessMemory", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);
        /// <summary>
        /// Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days.
        /// </summary>
        /// <returns>The return value is the number of milliseconds that have elapsed since the system was started.</returns>
        [DllImport(ImportKey, EntryPoint = "GetTickCount", SetLastError = true)]
        public static extern int GetTickCount();

        /// <summary>
        /// Retrieves the number of milliseconds that have elapsed since the system was started.
        /// </summary>
        /// <returns>The return value is the number of milliseconds that have elapsed since the system was started.</returns>
        [DllImport(ImportKey, EntryPoint = "GetTickCount64", SetLastError = true)]
        public static extern int GetTickCount64();
        /// <summary>
        /// Retrieves the current value of the performance counter, which is a high resolution (<1us) time stamp that can be used for time-interval measurements.
        /// </summary>
        /// <param name="lpPerformanceCount">A pointer to a variable that receives the current performance-counter value, in counts.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "QueryPerformanceCounter", SetLastError = true)]
        public static unsafe extern bool QueryPerformanceCounter([Out] long* lpPerformanceCount);
        /// <summary>
        /// Retrieves the current value of the performance counter, which is a high resolution (<1us) time stamp that can be used for time-interval measurements.
        /// </summary>
        /// <param name="lpPerformanceCount">A pointer to a variable that receives the current performance-counter value, in counts.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "QueryPerformanceCounter", SetLastError = true)]
        public static extern bool QueryPerformanceCounter([Out] IntPtr lpPerformanceCount);
        /// <summary>
        /// etrieves the frequency of the performance counter. 
        /// The frequency of the performance counter is fixed at system boot and is consistent across all processors. 
        /// Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
        /// </summary>
        /// <param name="lpFrequency">A pointer to a variable that receives the current performance-counter frequency, in counts per second. </param>
        /// <returns>If the installed hardware supports a high-resolution performance counter, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "QueryPerformanceFrequency", SetLastError = true)]
        public static unsafe extern bool QueryPerformanceFrequency([Out] long* lpFrequency);
        /// <summary>
        /// etrieves the frequency of the performance counter. 
        /// The frequency of the performance counter is fixed at system boot and is consistent across all processors. 
        /// Therefore, the frequency need only be queried upon application initialization, and the result can be cached.
        /// </summary>
        /// <param name="lpFrequency">A pointer to a variable that receives the current performance-counter frequency, in counts per second. </param>
        /// <returns>If the installed hardware supports a high-resolution performance counter, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "QueryPerformanceFrequency", SetLastError = true)]
        public static extern bool QueryPerformanceFrequency([Out] IntPtr lpFrequency);
        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="hModul">
        /// A handle to the DLL module that contains the function or variable. 
        /// The LoadLibrary, LoadLibraryEx, LoadPackagedLibrary, or GetModuleHandle function returns this handle.</param>
        /// <param name="lpProcName">The function or variable name, or the function's ordinal value.</param>
        /// <returns>If the function succeeds, the return value is the address of the exported function or variable.</returns>
        [DllImport(ImportKey, EntryPoint = "GetProcAddress", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModul, string lpProcName);
        /// <summary>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpLibFileName">
        /// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). <para/>
        /// If the string specifies a full path, the function searches only that path for the module.<para/>
        /// If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (\), not forward slashes (/).
        /// </param>
        /// <returns>If the function succeeds, the return value is a handle to the module.</returns>
        [DllImport(ImportKey, EntryPoint = "LoadLibrary", SetLastError = true)]
        public static extern IntPtr LoadLibraryW(string lpLibFileName);
        /// <summary>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpLibFileName">
        /// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). <para/>
        /// If the string specifies a full path, the function searches only that path for the module.<para/>
        /// If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (\), not forward slashes (/).
        /// </param>
        /// <param name="hFile">This parameter is reserved for future use. It must be NULL.</param>
        /// <param name="dwFlag">
        /// The action to be taken when loading the module. If no flags are specified, the behavior of this function is identical to that of the LoadLibrary function. 
        /// This parameter can be one of the following values.</param>
        /// <returns>If the function succeeds, the return value is a handle to the loaded module.</returns>
        [DllImport(ImportKey, EntryPoint = "LoadLibraryEx", SetLastError = true)]
        public static extern IntPtr LoadLibraryExW(string lpLibFileName, IntPtr hFile, LoadLibraryFlags dwFlag = LoadLibraryFlags.None);
        /// <summary>
        /// Loads the specified packaged module and its dependencies into the address space of the calling process.
        /// </summary>
        /// <param name="lpLibFileName">
        /// The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). <para/>
        /// If the string specifies a full path, the function searches only that path for the module.<para/>
        /// If the function cannot find the module, the function fails. When specifying a path, be sure to use backslashes (\), not forward slashes (/).
        /// </param>
        /// <param name="Reserved">This parameter is reserved. It must be 0.</param>
        /// <returns>If the function succeeds, the return value is a handle to the loaded module.</returns>
        /// <remarks>The LoadPackagedLibrary function is a simplified version of LoadLibraryEx.</remarks>
        [DllImport(ImportKey, EntryPoint = "LoadPackagedLibrary", SetLastError = true)]
        public static extern IntPtr  LoadPackagedLibrary(string lpwLibFileName, int Reserved = 0);
        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file). 
        /// If the file name extension is omitted, the default library extension .dll is appended. <para/>
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension. <para/> 
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (), not forward slashes (/).  <para/>
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process. <para/>
        /// If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe file).
        /// </param>
        /// <returns>If the function succeeds, the return value is a handle to the specified module.</returns>
        [DllImport(ImportKey, EntryPoint = "GetModuleHandle", SetLastError = true)]
        public static extern IntPtr GetModuleHandleW(string lpModuleName);
        /// <summary>
        /// Retrieves a module handle for the specified module and increments the module's reference count unless GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT is specified. 
        /// The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="flag">This parameter can be zero or one or more of the following values. </param>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file), or an address in the module (if dwFlags is GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS).<para/>
        /// For a module name, if the file name extension is omitted, the default library extension .dll is appended. 
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension. <para/>
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (), not forward slashes (/).<para/>
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
        /// </param>
        /// <param name="phModule">A handle to the specified module. If the function fails, this parameter is NULL.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "GetModuleHandleEx", SetLastError = true)]
        public static extern bool GetModuleHandleExW(GetModuleHandleExFlag flag, string lpModuleName, IntPtr phModule);

        /// <summary>
        /// Takes a snapshot of the specified processes, as well as the heaps, modules, and threads used by these processes.
        /// </summary>
        /// <param name="flags">
        /// The portions of the system to be included in the snapshot. 
        /// This parameter can be one or more of the following values.</param>
        /// <param name="th32ProcessID">
        /// The process identifier of the process to be included in the snapshot. <para/>
        /// This parameter can be zero to indicate the current process. <para/>
        /// This parameter is used when the SnapHeapList, SnapModule, SnapModule32, or SnapAll value is specified.
        /// Otherwise, it is ignored and all processes are included in the snapshot. <para/>
        /// If the specified process is the Idle process or one of the CSRSS processes, this function fails and the last error code is ERROR_ACCESS_DENIED because their access restrictions prevent user-level code from opening them.<para/>
        /// If the specified process is a 64-bit process and the caller is a 32-bit process, this function fails and the last error code is ERROR_PARTIAL_COPY(299).
        /// </param>
        /// <returns>If the function succeeds, it returns an open handle to the specified snapshot.</returns>
        [DllImport(ImportKey, EntryPoint = "CreateToolhelp32Snapshot", SetLastError = true)]
        public static extern IntPtr CreateToolhelp32Snapshot(CreateToolhelp32SnapshotFlags flags, int th32ProcessID);
        
        /// <summary>
        /// Retrieves information about the first process encountered in a system snapshot.
        /// </summary>
        /// <param name="hSnapshot">A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</param>
        /// <param name="lppe">
        /// A pointer to a PROCESSENTRY32 structure. 
        /// It contains process information such as the name of the executable file, the process identifier, and the process identifier of the parent process.</param>
        /// <returns>Returns TRUE if the first entry of the process list has been copied to the buffer or FALSE otherwise.</returns>
        [DllImport(ImportKey, EntryPoint = "Process32First", SetLastError = true)]
        public unsafe static extern bool Process32First(IntPtr hSnapshot, ref ProcessEntry32 lppe);
        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// https://docs.microsoft.com/en-us/windows/desktop/api/handleapi/nf-handleapi-closehandle !!remarks
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(ImportKey, EntryPoint = "CloseHandle", SetLastError = true)]
        public unsafe static extern bool CloseHandle(IntPtr hObject);
        /// <summary>
        /// Retrieves information about the next process recorded in a system snapshot.
        /// </summary>
        /// <param name="hSnapshot">A handle to the snapshot returned from a previous call to the CreateToolhelp32Snapshot function.</param>
        /// <param name="lppe">A pointer to a PROCESSENTRY32 structure.</param>
        /// <returns></returns>
        [DllImport(ImportKey, EntryPoint = "Process32Next", SetLastError = true)]
        public unsafe static extern bool Process32Next(IntPtr hSnapshot, ref ProcessEntry32 lppe);

    }
}
