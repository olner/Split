using Split.UI.Tools;

namespace Split.UI.UserControls
{
    public partial class FriendControl : UserControl
    {
        private readonly ControlsAdditions controlsAdditions;
        public FriendControl()
        {
            InitializeComponent();
            controlsAdditions = new ControlsAdditions();
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
