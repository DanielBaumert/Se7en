using Se7en.WinApi;
using System;
using System.Windows.Forms;

namespace Se7en.UI.Utils {

    public class DragAndDroper {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public static void Init(Form content, Control control) {
            control.MouseMove += (sender, e) => {
                if (e.Button == MouseButtons.Left) {
                    User32.ReleaseCapture();
                    User32.SendMessage((IntPtr)content.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }
    }
}