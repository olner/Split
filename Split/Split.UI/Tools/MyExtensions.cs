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

        public static string SetDataFormat(string data)
        {
            string[] words = data.Split(' ');

            var sb = new StringBuilder();

            for (int i = 0; i < words[1].Length / 2; i++)
            {
                sb.Append(' ');
            }
            if (words[0].Length < 2) sb.Append(' ');

            sb.AppendLine(words[0]);
            
            sb.AppendLine(words[1]);

            return sb.ToString();
        }
    }
}
