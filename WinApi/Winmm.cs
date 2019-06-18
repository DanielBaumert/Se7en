using System.Runtime.InteropServices;

namespace Se7en.WinApi {

    public class Winmm {
        public const string ImportKey = "Winmm.dll";

        /// <summary>
        /// The timeGetTime function retrieves the system time, in milliseconds. The system time is the time elapsed since Windows was started.
        /// </summary>
        /// <returns>Returns the system time, in milliseconds</returns>
        [DllImport(ImportKey, EntryPoint = "CopyMemory", SetLastError = true)]
        public static extern int timeGetTime();
    }
}