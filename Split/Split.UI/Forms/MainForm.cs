using Split.UI.Tools;
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
            deleteBtn.Visible = false;
            deleteBtn.BackColor = Color.FromArgb(204, 68, 85);
            deleteBtn.ForeColor = Color.White;

            profilePb.Image = Properties.Resources.noImage;
            saveBtn.BackColor = Color.FromArgb(91, 197, 167);
            saveBtn.ForeColor = Color.White;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.FlatAppearance.BorderSize = 0;

            SetProfile(Data.Id);
            SetExpense(Data.Id);
            SetFriends(Data.Id);
            SetGroups(Data.Id);
        }

        private async void SetProfile(int id)
        {
            var user = await client.GetUserByIdAsync(id);
            nameTb.Text = user.Login;
            emailTb.Text = user.Email;
            passwordTb.Text = "*******";
        }

        private async void SetExpense(int id)
        {
            var expenses = await client.GetUserExpensesAsync(id);

            var i = 0;
            foreach (var item in expenses)
            {
                var control = new ExpenseControl(client, item)
                {
                    Name = $"expensseControl{i}",
                    Width = expensesTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                expensesTlp.Controls.Add(control);
                i++;
            }
        }

        private async void SetFriends(int id)
        {
            var newFriendControl = new FriendControl(client)
            {
                Name = $"newFriendControl",
                Width = friendsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            newFriendControl.NewFriend();
            friendsTlp.Controls.Add(newFriendControl);

            var frined = await client.GetFriendsAsync(id);

            var i = 0;
            foreach (var item in frined)
            {
                var control = new FriendControl(client, item)
                {
                    Name = $"friendControl{i}",
                    Width = friendsTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                friendsTlp.Controls.Add(control);
                i++;
            }
        }

        private async void SetGroups(int id)
        {
            var newControl = new GroupControl(client)
            {
                Width = groupsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            newControl.NewGroup();
            groupsTlp.Controls.Add(newControl);

            var groups = await client.GetUserGroupsAsync(id);

            var i = 0;
            foreach (var item in groups)
            {
                var control = new GroupControl(client, item)
                {
                    Name = $"groupControl{i}",
                    Width = groupsTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                groupsTlp.Controls.Add(control);
                i++;
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
            this.Text = "Split - " + tabControl1.SelectedTab.Text;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить аккаунт без возможности восстановления?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.OK) return;
            MessageBox.Show("Я не понял, ты сейчас быканул или как?");
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //TODO: В сервисе сделать метод для изменения данных профиля
        }

    }
}
