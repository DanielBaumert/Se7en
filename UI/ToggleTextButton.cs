using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsClean.UI {
    public partial class ToggleTextButton : UserControl {
        private string _OnText;
        private string _OffText;

        public event Action<ToggleTextButton> Toggled;

        [Category("States")]
        public string OnText {
            get => _OnText; set {
                if(_OnText != value) {
                    _OnText = value;
                    if(!Status) {
                        label1.Text = _OnText;
                    }
                }
            }
        }

        [Category("States")]
        public string OffText {
            get => _OffText; set {
                if(_OffText != value) {
                    _OffText = value;
                    if(!Status) {
                        label1.Text = _OffText;
                    }
                }
            }
        }

        [Category("States")]
        public bool Status {
            get => toggleButton1.ToggleState; set {
                if(toggleButton1.ToggleState != value) {
                    toggleButton1.ToggleState = value;
                    label1.Text = value ? OnText : OffText;
                }
            }
        }

        public ToggleTextButton() {
            InitializeComponent();
        }

        private void ToggleButton1_Toggled(Se7en.UI.ToggleButton toggle) {
            if(toggle.ToggleState) {
                label1.Text = _OnText;
            } else {
                label1.Text = _OffText;
            }
            Toggled?.Invoke(this);
        }
    }
}
