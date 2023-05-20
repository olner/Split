using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.UI.Tools
{
    public static class MyExtensions
    {
        public static void Disable(this Control control, Control focusTarget)
        {
            control.TabStop = false;
            control.BackColor = Color.White;
            control.Cursor = Cursors.Arrow;
            control.Enter += delegate { focusTarget.Focus(); };
        }
    }
}
