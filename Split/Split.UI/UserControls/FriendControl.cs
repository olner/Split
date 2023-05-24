using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI.UserControls
{
    public partial class FriendControl : UserControl
    {
        private readonly ControlsAdditions controlsAdditions;
        private readonly SplitServiceApi client;
        private readonly Friend friend;
        private readonly GroupMember member;

        private string Name { get; set; }

        public FriendControl(SplitServiceApi client)
        {
            InitializeComponent();
            controlsAdditions = new ControlsAdditions();
            this.client = client;
        }
        public FriendControl(SplitServiceApi client, GroupMember member)
        {
            InitializeComponent();
            controlsAdditions = new ControlsAdditions();
            this.client = client;
            this.member = member;
            SetMembers();
        }
        public FriendControl(SplitServiceApi client, Friend friend)
        {
            InitializeComponent();
            controlsAdditions = new ControlsAdditions();
            this.client = client;
            this.friend = friend;
            SetFriends();
        }

        private void FriendControl_Load(object sender, EventArgs e)
        {
            deleteBtn.BackColor = Color.FromArgb(204, 68, 85);
            deleteBtn.ForeColor = Color.White;

            deleteBtn.FlatStyle = FlatStyle.Flat;
            deleteBtn.FlatAppearance.BorderSize = 0;

            SetActions(controlsAdditions.GetAll(this, typeof(System.Windows.Forms.Label)));
            SetActions(controlsAdditions.GetAll(this, typeof(Button)));

            pictureBox1.Image = Properties.Resources.noImage;
        }
        public async void SetFriends()
        {
            if (friend.UserId == Data.Id)
            {
                var result = await client.GetUserByIdAsync((int)friend.FriendId);
                var user = result.Response;

                Name = user.Login;
                nameLbl.Text = Name;
            }
            else
            {
                var result = await client.GetUserByIdAsync((int)friend.UserId);
                var user = result.Response;
                Name = user.Login;
                nameLbl.Text = Name;
            }
        }

        public async void SetMembers()
        {
            var result = await client.GetUserByIdAsync((int)member.UserId);
            var user = result.Response;
            Name = user.Login;
            nameLbl.Text = Name;
        }

        public void NewMember()
        {
            this.Height /= 2;
            var button = new Button
            {
                Name = "addBtn",
                Text = "Добавить в группу",
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(91, 197, 167),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            tableLayoutPanel1.Controls.Remove(deleteBtn);
            tableLayoutPanel1.Controls.Remove(pictureBox1);
            tableLayoutPanel1.Controls.Add(button, 4, 0);

            AddNameTextBox();
        }

        public void NewFriend()
        {
            this.Height /= 2;
            var button = new Button
            {
                Name = "addBtn",
                Text = "Добавить в друзья",
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(91, 197, 167),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Click += addBtn_Click;

            tableLayoutPanel1.Controls.Remove(deleteBtn);
            tableLayoutPanel1.Controls.Remove(pictureBox1);
            tableLayoutPanel1.Controls.Add(button, 4, 0);
            AddNameTextBox();
        }

        public void NewFriendRequest()
        {
            var button = new Button
            {
                Name = "addBtn",
                Text = "Добавить",
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(91, 197, 167),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Click += ChangeBtn_Click;
            //TODO: Сделать в сервисе чтоюы запрос в друзья менять
            tableLayoutPanel1.Controls.Add(button, 2, 0);
        }
        public async void ChangeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var rawResult = await client.ChangeFriendRequestAsync(friend.Id);
                var result = rawResult.Response;

                if (result == null) return;

                this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void AddNameTextBox()
        {
            nameLbl.Text = "";
            var nameTb = new TextBox
            {
                Name = "nameTb",
                Anchor = AnchorStyles.Right,
                Width = 200
            };
            tableLayoutPanel1.Controls.Remove(nameLbl);
            tableLayoutPanel1.Controls.Add(nameTb, 2, 0);
        }

        public void SetActions(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                control.MouseEnter += tableLayoutPanel1_MouseEnter;
                control.MouseLeave += tableLayoutPanel1_MouseLeave;
            }
        }

        private void tableLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void tableLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить пользователя из друзей?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (member == null)
            {
                DeleteFriend();
                this.Dispose();
            }
            else
            {
                //DeleteMember();
                this.Dispose();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var controls = controlsAdditions.GetAll(this, typeof(TextBox));
            foreach (var control in controls)
            {
                AddFriend(control.Text);
            }
        }


        public async void AddFriend(string name)
        {
            if (name.Length == 0) return;

            var result = await client.GetUserByLoginAsync(name);
            var friend = result.Response;

            if (friend == null) return;

            await client.AddFriendAsync(Data.Id, friend.Id, true);
        }
        public async void DeleteFriend()
        {
            await client.DeleteFriendAsync(friend.Id);
        }
        public async void DeleteMember()
        {
            var result = await client.GetGroupAsync(member.GroupId);
            var group = result.Response;
            if (group.Admin == member.Id) return;

            await client.DeleteGroupMemberAsync(member.GroupId, member.UserId);
        }
    }
}
