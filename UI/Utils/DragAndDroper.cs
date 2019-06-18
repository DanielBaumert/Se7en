using Se7en.WinApi;
using System;
using System.Windows.Forms;

namespace Se7en.UI.Utils {

    public class DragAndDroper {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private Control Control;
        private Form Ctx;

        public DragAndDroper(Form content, Control control) {
            Control = control;
            Ctx = content;
            Control.MouseMove += C_MouseDown;
        }

        private void C_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                User32.ReleaseCapture();
                User32.SendMessage((IntPtr)Ctx.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}