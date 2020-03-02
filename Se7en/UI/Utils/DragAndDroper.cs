using Se7en.Windows.Api.Enum;
using Se7en.Windows.Api.Native;
using System.Windows.Forms;

namespace Se7en.UI.Utils {

    public class DragAndDroper {

        public static void Init(Form content, Control control) {
            control.MouseMove += (sender, e) => {
                if (e.Button == MouseButtons.Left) {
                    User32.ReleaseCapture();
                    User32.SendMessage(content.Handle, WindowsMessage.NCLBUTTONDOWN, 0x2, 0);
                }
            };
        }
    }
}