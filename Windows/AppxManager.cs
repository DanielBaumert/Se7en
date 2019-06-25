using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Se7en.Windows {
    public static class AppxManager {
        private static Regex _regexAppx = new Regex(Const.REGEX_APPX, RegexOptions.Multiline);
        public static List<Appx> GetAppx() {
            string result = PowerShell.RunCommand(Const.GET_APPX);
            List<Appx> apps = new List<Appx>();

            foreach (Match m in _regexAppx.Matches(result)) {
                string name = m.Groups[1].Value;
                string installLocation = m.Groups[2].Value;
                if (!string.IsNullOrWhiteSpace(name) && name != "Name") {
                    apps.Add(new Appx { Name = name, InstallLocation = installLocation });
                }
            }

            return apps;
        }

        public static void Remove(Appx app) {
            string query = string.Format(Const.DEINSTALL_APPX, app.Name);
            PowerShell.RunCommand(query);
        }

        public static bool Exists(Appx app) {
            string query = string.Format(Const.EXISTS_APPX, app.Name);
            return PowerShell.RunCommand(query).Contains("True"); 
        }
        private static class Const {
            public const string GET_APPX = "Get-AppxPackage -allusers | select Name,InstallLocation,NonRemovable,SignatureKind,IsFramework | where {$_.NonRemovable -Match 'False' -and $_.SignatureKind -Match 'Store' -and $_.IsFramework -Match 'False'} | select Name,InstallLocation";
            public const string DEINSTALL_APPX = "Get-AppxPackage {0} | Remove-AppxPackage";
            public const string EXISTS_APPX = "Get-AppxPackage | Select {{$_.Name -eq '{0}'}}";
            public const string REGEX_APPX = "^((?=.*[\\w\\d].*)[^\\s]*)\\s*(.+)$";
        }
    }
}
