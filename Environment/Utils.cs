using System.Security.Principal;

namespace Se7en.Environment {

    public class Utils {

        public static bool IsUserAdministrator() {
            try {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            } catch {
                return false;
            }
        }
    }
}