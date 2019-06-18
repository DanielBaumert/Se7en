using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Se7en.UI {

    internal class PromptedTextBoxBase : System.Windows.Forms.TextBox {

        public PromptedTextBoxBase() {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string _Cue = "WaterMark";

        [Localizable(true)]
        public string Cue {
            get => _Cue;
            set {
                if (_Cue != value) {
                    _Cue = value;
                    UpdateCue();
                }
            }
        }

        private void UpdateCue() {
            if (IsHandleCreated && _Cue != null) {
                SendMessage(Handle, 0x1501, (IntPtr)1, _Cue);
            }
        }

        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            UpdateCue();
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
    }
}