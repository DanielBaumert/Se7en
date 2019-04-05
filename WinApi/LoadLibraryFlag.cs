using System;

namespace Se7en.WinApi
{
    [Flags]
    public enum LoadLibraryFlags : uint
    {
        None = 0,
        /// <summary>
        /// If this value is used, and the executable module is a DLL, the system does not call DllMain for process and thread initialization and termination. 
        /// Also, the system does not load additional executable modules that are referenced by the specified module.
        /// </summary>
        DontResolveDllReferences = 0x00000001,
        /// <summary>
        /// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies for the DLL. This action applies only to the DLL being loaded and not to its dependencies. 
        /// This value is recommended for use in setup programs that must run extracted DLLs during installation.
        /// </summary>
        LoadIgnoreCodeAuthzLevel = 0x00000010,
        /// <summary>
        /// If this value is used, the system maps the file into the calling process's virtual address space as if it were a data file. 
        /// Nothing is done to execute or prepare to execute the mapped file. 
        /// Therefore, you cannot call functions like GetModuleFileName, GetModuleHandle or GetProcAddress with this DLL. 
        /// Using this value causes writes to read-only memory to raise an access violation. 
        /// Use this flag when you want to load a DLL only to extract messages or resources from it.
        /// </summary>
        LoadLibraryAsDatafile = 0x00000002,
        /// <summary>
        /// Similar to LOAD_LIBRARY_AS_DATAFILE, except that the DLL file is opened with exclusive write access for the calling process. 
        /// Other processes cannot open the DLL file for write access while it is in use. 
        /// However, the DLL can still be opened by other processes.
        /// </summary>
        LoadLibraryAsDatafileExclusive = 0x00000040,
        /// <summary>
        /// If this value is used, the system maps the file into the process's virtual address space as an image file. 
        /// However, the loader does not load the static imports or perform the other usual initialization steps. 
        /// Use this flag when you want to load a DLL only to extract messages or resources from it.
        /// Unless the application depends on the file having the in-memory layout of an image, 
        /// this value should be used with either LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE or LOAD_LIBRARY_AS_DATAFILE.
        /// </summary>
        LoadLibraryAsImageResource = 0x00000020,
        /// <summary>
        /// If this value is used, the application's installation directory is searched for the DLL and its dependencies. 
        /// Directories in the standard search path are not searched. 
        /// This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.
        /// </summary>
        LoadLibrarySearchApplicationDir = 0x00000200,
        /// <summary>
        /// This value is a combination of LOAD_LIBRARY_SEARCH_APPLICATION_DIR, LOAD_LIBRARY_SEARCH_SYSTEM32, and LOAD_LIBRARY_SEARCH_USER_DIRS. 
        /// Directories in the standard search path are not searched. 
        /// This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.<para/>
        /// This value represents the recommended maximum number of directories an application should include in its DLL search path.
        /// </summary>
        LoadLibrarySearchDefaultDirs = 0x00001000,
        /// <summary>
        /// If this value is used, the directory that contains the DLL is temporarily added to the beginning of the list of directories that are searched for the DLL's dependencies. 
        /// Directories in the standard search path are not searched.
        /// The lpFileName parameter must specify a fully qualified path. This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.
        /// </summary>
        LoadLibrarySearchDllLoadDir = 0x00000100,
        /// <summary>
        /// If this value is used, %windows%\system32 is searched for the DLL and its dependencies. 
        /// Directories in the standard search path are not searched. 
        /// This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.
        /// </summary>
        LoadLibrarySearchSystem32 = 0x00000800,
        /// <summary>
        /// If this value is used, directories added using the AddDllDirectory or the SetDllDirectory function are searched for the DLL and its dependencies. 
        /// If more than one directory has been added, the order in which the directories are searched is unspecified. 
        /// Directories in the standard search path are not searched. 
        /// This value cannot be combined with LOAD_WITH_ALTERED_SEARCH_PATH.
        /// </summary>
        LoadLibrarySearchUserDirs = 0x00000400,
        /// <summary>
        /// If this value is used and lpFileName specifies an absolute path, the system uses the alternate file search strategy discussed in the Remarks section to find associated executable modules that the specified module causes to be loaded.
        /// If this value is used and lpFileName specifies a relative path, the behavior is undefined. <para/>
        /// If this value is not used, or if lpFileName does not specify a path, the system uses the standard search strategy discussed in the Remarks section to find associated executable modules that the specified module causes to be loaded.
        /// </summary>
        LoadWithAlteredSearchPath = 0x00000008
    }
}

