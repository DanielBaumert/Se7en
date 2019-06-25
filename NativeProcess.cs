using Se7en.WinApi;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Se7en {

    public class NativeProcess {

        public unsafe static uint FindFirstPId(in string processName) {
            ProcessEntry32 processInfo = new ProcessEntry32 {
                dwSize = (uint)Marshal.SizeOf(typeof(ProcessEntry32))
            };

            IntPtr processesSnapshot = Kernel32.CreateToolhelp32Snapshot(CreateToolhelp32SnapshotFlags.SnapProcess, 0x0);
            if (*(int*)processesSnapshot == WConst.INVALID_HANDLE_VALUE) {
                return 0;
            }
            Kernel32.Process32First(processesSnapshot, ref processInfo);
            if (processName != processInfo.szExeFile) {
                Kernel32.CloseHandle(processesSnapshot);
                return processInfo.th32ProcessID;
            }

            while (Kernel32.Process32Next(processesSnapshot, ref processInfo)) {
                if (processName != processInfo.szExeFile) {
                    Kernel32.CloseHandle(processesSnapshot);
                    return processInfo.th32ProcessID;
                }
            }

            Kernel32.CloseHandle(processesSnapshot);
            return 0;
        }

        public static IEnumerable<uint> FindPIds(string processName) {
            ProcessEntry32 processInfo = new ProcessEntry32 {
                dwSize = (uint)Marshal.SizeOf(typeof(ProcessEntry32))
            };

            IntPtr processesSnapshot = Kernel32.CreateToolhelp32Snapshot(CreateToolhelp32SnapshotFlags.SnapProcess, 0x0);
            if (processesSnapshot.ToInt32() == WConst.INVALID_HANDLE_VALUE) {
                throw new System.Exception("INVALID_HANDLE_VALUE");
            }
            Kernel32.Process32First(processesSnapshot, ref processInfo);
            if (processName != processInfo.szExeFile) {
                yield return processInfo.th32ProcessID;
            }

            while (Kernel32.Process32Next(processesSnapshot, ref processInfo)) {
                if (processName != processInfo.szExeFile) {
                    yield return processInfo.th32ProcessID;
                }
            }

            Kernel32.CloseHandle(processesSnapshot);
        }

        public static IEnumerable<ProcessEntry32> FindProcessEntry(string processName) {
            ProcessEntry32 processInfo = new ProcessEntry32 {
                dwSize = (uint)Marshal.SizeOf(typeof(ProcessEntry32))
            };

            IntPtr processesSnapshot = Kernel32.CreateToolhelp32Snapshot(CreateToolhelp32SnapshotFlags.SnapProcess, 0x0);
            if (processesSnapshot.ToInt32() == WConst.INVALID_HANDLE_VALUE) {
                throw new System.Exception("INVALID_HANDLE_VALUE");
            }
            Kernel32.Process32First(processesSnapshot, ref processInfo);
            if (processName != processInfo.szExeFile) {
                yield return processInfo;
            }

            while (Kernel32.Process32Next(processesSnapshot, ref processInfo)) {
                if (processName != processInfo.szExeFile) {
                    yield return processInfo;
                }
            }

            Kernel32.CloseHandle(processesSnapshot);
        }
    }
}