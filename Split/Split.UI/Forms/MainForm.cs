using Split.UI.UserControls;
using Split.WebClient;

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
            pictureBox1.Image = Properties.Resources.noImage;
            saveBtn.BackColor = Color.FromArgb(91, 197, 167);
            saveBtn.ForeColor = Color.White;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.FlatAppearance.BorderSize = 0;

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
                Width = friendsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            control3.NewFriend();
            var control4 = new FriendControl
            {
                Width = friendsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            friendsTlp.Controls.Add(control3);
            friendsTlp.Controls.Add(control4);

            var control5 = new ExpenseControl
            {
                Width = expensesTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            var control6 = new ExpenseControl
            {
                Width = expensesTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            expensesTlp.Controls.Add(control5);
            expensesTlp.Controls.Add(control6);
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
