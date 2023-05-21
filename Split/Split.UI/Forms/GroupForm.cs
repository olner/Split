using Split.UI.UserControls;
using Split.WebClient;

namespace Split.UI.Forms
{
    public partial class GroupForm : Form
    {
        private readonly SplitServiceApi client;
        private readonly Guid groupId;
        private string GroupName { get; set; }

        public GroupForm(SplitServiceApi client, Guid groupId)
        {
            InitializeComponent();
            this.client = client;
            this.groupId = groupId;
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            SetData();

            addExpenseBtn.BackColor = Color.FromArgb(91, 197, 167);
            addExpenseBtn.ForeColor = Color.White;
            addExpenseBtn.FlatStyle = FlatStyle.Flat;
            addExpenseBtn.FlatAppearance.BorderSize = 0;
        }

        public async void SetData()
        {
            var expenses = await client.GetGroupExpensesAsync(groupId);
            var group = await client.GetGroupAsync(groupId);

            GroupName = group.Name;
            groupNameLbl.Text = GroupName;
            nameTb.Text = GroupName;
            this.Text = GroupName + " - группы";

            var i = 0;
            foreach (var item in expenses)
            {
                var control = new ExpenseControl(client, item)
                {
                    Name = $"expensseControl{i}",
                    Width = expenseTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                expenseTlp.Controls.Add(control);
                i++;
            }

            var addMember = new FriendControl
            {
                Width = expenseTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            addMember.NewMember();
            membersTlp.Controls.Add(addMember);

            var members = await client.GetGroupMembersAsync(groupId);
            var j = 0;
            foreach (var item in members)
            {
                var control = new FriendControl(client, item)
                {
                    Name = $"friednControl{j}",
                    Width = membersTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                membersTlp.Controls.Add(control);
                j++;
            }
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
            this.Text = GroupName + " - " + tabControl1.SelectedTab.Text;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            nameTb.Text = GroupName;
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            var group = await client.UpdateNameAsync(groupId, nameTb.Text);
            GroupName = group.Name;
        }
    }
}
