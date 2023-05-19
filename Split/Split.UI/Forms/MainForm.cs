using Split.UI.UserControls;
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
    public partial class MainForm : Form
    {
        private readonly SplitServiceApi client;

        public MainForm(SplitServiceApi client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var control = new GroupControl
            {
                Width = groupsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            control.NewGroup();

            var control2 = new GroupControl
            {
                Width = groupsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            groupsTlp.Controls.Add(control);
            groupsTlp.Controls.Add(control2);

            var control3 = new FriendControl
            {
                Width = groupsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            friendsTlp.Controls.Add(control3);
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
            this.Text = "Split - " + tabControl1.SelectedTab.Text;
        }
    }
}
