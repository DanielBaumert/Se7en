using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Se7en.UI
{
    public class ListView : Panel
    {
        private int _listHeight;

        protected override void OnControlAdded(ControlEventArgs e) {
            _listHeight = Controls.OfType<Control>().Sum(x => x.Height);
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e) {
            _listHeight = Controls.OfType<Control>().Sum(x => x.Height);
            base.OnControlRemoved(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e) {
            MessageBox.Show(e.Delta.ToString());
            base.OnMouseWheel(e);
        }
    }
}
