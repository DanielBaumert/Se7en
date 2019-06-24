using System;
using System.Diagnostics;
namespace WindowsClean {
    public static class PowerShell {
        private static ProcessStartInfo ProcessStartInfo = new ProcessStartInfo() {
            FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe",
            CreateNoWindow = true,
            ErrorDialog = false,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };


        public static string RunCommand(string argument) {
            if (argument.Contains(@""""))
                throw new NotSupportedException(@"use ' instat of """);

            ProcessStartInfo.Arguments = argument;
            using(Process proc = new Process() { StartInfo = ProcessStartInfo }) {
                proc.Start();
                while(!proc.StandardOutput.EndOfStream) {
                    string result = proc.StandardOutput.ReadToEnd();
                    return result;
                }
                return string.Empty;
            }
        }
    }
}
