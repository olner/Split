using Split.WebClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Split.UI.Forms
{
    public partial class PayForm : Form
    {
        private readonly Expense expense;

        public PayForm(Expense expense)
        {
            InitializeComponent();
            this.expense = expense;
        }

        private void payBtn_Click(object sender, EventArgs e)
        {

        }

        private void sumTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control || e.Alt || e.Shift || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left
        || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
                return;

            if (sumTb.Text == "" && e.KeyCode == Keys.Decimal)
                e.SuppressKeyPress = true;

            if (e.KeyCode != Keys.Decimal)
                if ((sumTb.Text == "" && e.KeyValue == 188) || (sumTb.Text == "" && e.KeyValue == 190) || !(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9
                  || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && e.KeyValue != 188 && e.KeyValue != 190)
                    e.SuppressKeyPress = true;

            char[] c = (sumTb.Text + e.KeyData).ToCharArray();
            for (int i = 0; i < c.Length; i++)
                if (c[i] == '.' || c[i] == ',')
                    if (e.KeyValue == 188 || e.KeyValue == 190 || e.KeyCode == Keys.Decimal || (sumTb.Text.Length - i) > 2)
                        e.SuppressKeyPress = true;
        }
    }
}
