using System.Drawing;
using System.Windows.Forms;

namespace Se7en.UI
{
    public partial class WinFrom : Form
    {

        public Color TitlebarColor {
            get => Pl_WinForm == null ? default : Pl_WinForm.BackColor;
            set { if (value != Pl_WinForm.BackColor) Pl_WinForm.BackColor = value; }
        }

        public Color TitleColor {
            get => Lb_WinFormTitle == null ? default : Lb_WinFormTitle.ForeColor;
            set { if (value != Lb_WinFormTitle.ForeColor) Lb_WinFormTitle.ForeColor = value; }
        }
        public override string Text {
            get => Lb_WinFormTitle == null ? string.Empty : Lb_WinFormTitle.Text;
            set { if (value != Lb_WinFormTitle.Text) Lb_WinFormTitle.Text = value; }
        }

        public WinFrom()
        {
            InitializeComponent();

        }

        private void Bt_WinFromClose_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
