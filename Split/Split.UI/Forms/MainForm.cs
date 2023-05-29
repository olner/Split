using Split.UI.Tools;
using Split.UI.UserControls;
using Split.WebClient;

namespace Split.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SplitServiceApi client;
        private int Friends { get; set; }
        private int FriendRequsets { get; set; }
        private int Groups { get; set; }
        private int Expenses { get; set; }
        private List<int> GroupsMembers { get; set; }

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

            SetGroups(Data.Id);
            SetProfile(Data.Id);
            SetExpense(Data.Id);
            SetFriends(Data.Id);
            SetFriendsRequests(Data.Id);

            updateTimer.Start();
        }

        private async void SetProfile(int id)
        {
            var result = await client.GetUserByIdAsync(id);
            var user = result.Response;

            nameTb.Text = user.Login;
            emailTb.Text = user.Email;
            passwordTb.Text = user.Password;
        }

        private async void SetExpense(int id)
        {
            var result = await client.GetUserExpensesAsync(id);
            var expenses = result.Response;
            if (expenses == null) return;

            var i = 0;
            foreach (var item in expenses)
            {
                var control = new ExpenseControl(client, item)
                {
                    Name = $"expensseControl{i}",
                    Width = expensesTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                control.RemoveDeleteBtn();
                expensesTlp.Controls.Add(control);
                i++;
            }

            Expenses = i;
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

            var result = await client.GetFriendsAsync(id);
            var friend = result.Response;
            if (friend == null) return;

            var i = 0;
            foreach (var item in friend)
            {
                if (item.Request == true) break;
                var control = new FriendControl(client, item)
                {
                    Name = $"friendControl{i}",
                    Width = friendsTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                friendsTlp.Controls.Add(control);
                i++;
            }

            Friends = i;
        }
        //TODO: Возможно объединить два метода в один !!! (метод сверху и снизу!) 
        private async void SetFriendsRequests(int id)
        {
            var result = await client.GetFriendsAsync(id);
            var friend = result.Response;
            if (friend == null) return;

            var i = 0;
            foreach (var item in friend)
            {
                if (item.Request == false) break;
                var control = new FriendControl(client, item)
                {
                    Name = $"friendControl{i}",
                    Width = friendRequestTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                control.NewFriendRequest();
                friendRequestTlp.Controls.Add(control);
                i++;
            }

            FriendRequsets = i;
        }

        private async void SetGroups(int id)
        {
            GroupsMembers.Clear();

            var newControl = new GroupControl(client)
            {
                Width = groupsTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            newControl.NewGroup();
            groupsTlp.Controls.Add(newControl);

            var result = await client.GetUserGroupsAsync(id);
            var groups = result.Response;
            if (groups == null) return;

            var i = 0;
            foreach (var item in groups)
            {
                var rawMembers = await client.GetGroupMembersAsync(item.Id);
                var mebers = rawMembers.Response;
                GroupsMembers.Add(mebers.Count);

                var control = new GroupControl(client, item)
                {
                    Name = $"groupControl{i}",
                    Width = groupsTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                groupsTlp.Controls.Add(control);
                i++;
            }

            Groups = i;
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

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Enabled = false;
            var user = await client.UpdateUserDataAsync(Data.Id, nameTb.Text, emailTb.Text, passwordTb.Text);
            if (user == null)
            {
                //TODO: не знаю
            }
            saveBtn.Enabled = true;
        }

        private void showPaswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPaswordCheckBox.Checked)
            {
                passwordTb.PasswordChar = '\0';
            }
            else
            {
                passwordTb.PasswordChar = '*';
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            CheckFriends();
            CheckGroups();
            CheckExpenses();  
            CheckMembers();
        }
        private async void CheckFriends()
        {
            var rawFriends = await client.GetFriendsAsync(Data.Id);
            var friends = rawFriends.Response;
            if (friends == null) return;

            var requestsCount = 0;
            var friendsCount = 0;
            foreach (var item in friends)
            {
                if (item.Request == false) friendsCount++;
                else requestsCount++;
            }

            if (friendsCount != Friends)
            {
                friendsTlp.Controls.Clear();
                SetFriends(Data.Id);
            }
            if (requestsCount != FriendRequsets)
            {
                friendRequestTlp.Controls.Clear();
                SetFriendsRequests(Data.Id);
            }
        }
        private async void CheckGroups()
        {
            var rawGroups = await client.GetUserGroupsAsync(Data.Id);
            var groups = rawGroups.Response;
            if (groups == null) return;

            if (groups.Count != Groups)
            {
                groupsTlp.Controls.Clear();
                SetGroups(Data.Id);
            }
        }
        private async void CheckExpenses()
        {
            var rawExpenses = await client.GetUserExpensesAsync(Data.Id);
            var expenses = rawExpenses.Response;
            if (expenses == null) return;

            if (expenses.Count != Expenses)
            {
                expensesTlp.Controls.Clear();
                SetExpense(Data.Id);
            }
        }

        private async void CheckMembers()
        {
            var rawGroups = await client.GetUserGroupsAsync(Data.Id);
            var groups = rawGroups.Response;
            if (groups == null) return;

            int counter = 0;
            foreach(var group in groups)
            {
                var rawMembers = await client.GetGroupMembersAsync(group.Id);
                var members = rawMembers.Response;

                if(members.Count != GroupsMembers[counter])
                {
                    expensesTlp.Controls.Clear();
                    SetExpense(Data.Id);
                }
                counter++;
            }
        }
    }
}
