using System;
using System.Runtime.InteropServices;

namespace Se7en.Windows.Api.Native
{
    public static class Winspool
    {
        [DllImport(ExternDll.Winspool)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddMonitor([In] string pName, [In] int level, [In] ref MonitorInfo2 pMonitor);


        /// <summary>
        /// The EnumMonitors function retrieves information about the port monitors installed on the specified server.
        /// </summary>
        /// <param name="pName">
        /// A pointer to a null-terminated string that specifies the name of the server on which the monitors reside.<br/>
        /// If this parameter is NULL, the local monitors are enumerated.
        /// </param>
        /// <param name="Level">
        /// The version of the structure pointed to by pMonitors.<br/>
        /// This value can be 1 or 2.
        /// </param>
        /// <param name="pMonitors">    
        /// A pointer to a buffer that receives an array of structures.<br/>
        /// The buffer must be large enough to store the strings referenced by the structure members.<para/>
        /// To determine the required buffer size, call EnumMonitors with cbBuf set to zero.<para/>
        /// The buffer receives an array of MONITOR_INFO_1 structures if Level is 1, or MONITOR_INFO_2 structures if Level is 2.
        /// </param>
        /// <param name="cbBuf">        
        /// The size, in bytes, of the buffer pointed to by pMonitors.
        /// </param>
        /// <param name="pcbNeeded">   
        /// A pointer to a variable that receives the number of bytes copied if the function succeeds or the number of bytes required if cbBuf is too small.
        /// </param>
        /// <param name="pcReturned">   
        /// A pointer to a variable that receives the number of structures that were returned in the buffer pointed to by pMonitors.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.<br/>
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.Winspool)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumMonitors([In] string  pName, [In] int Level, [Out] IntPtr pMonitors, [In] int cbBuf, [Out] IntPtr pcbNeeded, [Out] IntPtr pcReturned);


        /// <summary>
        /// The EnumMonitors function retrieves information about the port monitors installed on the specified server.
        /// </summary>
        /// <param name="pName">
        /// A pointer to a null-terminated string that specifies the name of the server on which the monitors reside.<br/>
        /// If this parameter is NULL, the local monitors are enumerated.
        /// </param>
        /// <param name="Level">
        /// The version of the structure pointed to by pMonitors.<br/>
        /// This value can be 1 or 2.
        /// </param>
        /// <param name="pMonitors">    
        /// A pointer to a buffer that receives an array of structures.<br/>
        /// The buffer must be large enough to store the strings referenced by the structure members.<para/>
        /// To determine the required buffer size, call EnumMonitors with cbBuf set to zero.<para/>
        /// The buffer receives an array of MONITOR_INFO_1 structures if Level is 1, or MONITOR_INFO_2 structures if Level is 2.
        /// </param>
        /// <param name="cbBuf">        
        /// The size, in bytes, of the buffer pointed to by pMonitors.
        /// </param>
        /// <param name="pcbNeeded">   
        /// A pointer to a variable that receives the number of bytes copied if the function succeeds or the number of bytes required if cbBuf is too small.
        /// </param>
        /// <param name="pcReturned">   
        /// A pointer to a variable that receives the number of structures that were returned in the buffer pointed to by pMonitors.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.<br/>
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(ExternDll.Winspool)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumMonitors([In] string pName, [In] int Level, [Out] IntPtr pMonitors, [In] int cbBuf, ref int pcbNeeded,  ref int pcReturned);


    }
}
