using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Se7en.WinApi
{
    public class Winmm
    {
        public const string ImportKey = "Winmm.dll";
        /// <summary>
        /// The timeGetTime function retrieves the system time, in milliseconds. The system time is the time elapsed since Windows was started.
        /// </summary>
        /// <returns>Returns the system time, in milliseconds</returns>
        [DllImport(ImportKey, EntryPoint = "CopyMemory", SetLastError = true)]
        public static extern int timeGetTime();
    }
}
