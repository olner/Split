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

        public FriendControl()
        {
            InitializeComponent();
            controlsAdditions = new ControlsAdditions();
        }
        public FriendControl(SplitServiceApi client, GroupMember member )
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
            if(friend.UserId == Data.Id)
            {
                var user = await client.GetUserByIdAsync((int)friend.FriendId);
                Name = user.Login;
                nameLbl.Text = Name;
            }
            else
            {
                var user = await client.GetUserByIdAsync((int)friend.UserId);
                Name = user.Login;
                nameLbl.Text = Name;
            }
        }

        public async void SetMembers()
        {
            var user = await client.GetUserByIdAsync((int)member.UserId);
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
            tableLayoutPanel1.Controls.Add(button, 3, 0);

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

            tableLayoutPanel1.Controls.Remove(deleteBtn);
            tableLayoutPanel1.Controls.Remove(pictureBox1);
            tableLayoutPanel1.Controls.Add(button, 3, 0);
            AddNameTextBox();
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
            tableLayoutPanel1.Controls.Add(nameTb, 1, 0);
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
            MessageBox.Show("Вы точно хотите удалить пользователя из друзей?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
