using Split.UI.UserControls;
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
    public partial class GroupForm : Form
    {
        public GroupForm()
        {
            InitializeComponent();
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            addExpenseBtn.BackColor = Color.FromArgb(91, 197, 167);
            addExpenseBtn.ForeColor = Color.White;
            addExpenseBtn.FlatStyle = FlatStyle.Flat;
            addExpenseBtn.FlatAppearance.BorderSize = 0;

            var expense = new ExpenseControl
            {
                Width = expenseTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            expenseTlp.Controls.Add(expense);

            var addMember = new FriendControl
            {
                Width = expenseTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            addMember.NewMember();
            membersTlp.Controls.Add(addMember);

            var member = new FriendControl
            {
                Width = expenseTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            membersTlp.Controls.Add(member);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g;
            string sText;
            int iX;
            float iY;

            SizeF sizeText;
            TabControl ctlTab;

            ctlTab = (TabControl)sender;

            g = e.Graphics;

            sText = ctlTab.TabPages[e.Index].Text;
            sizeText = g.MeasureString(sText, ctlTab.Font);
            iX = e.Bounds.Left + 6;
            iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;
            g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "GroupName - " + tabControl1.SelectedTab.Text;
        }
    }
}
