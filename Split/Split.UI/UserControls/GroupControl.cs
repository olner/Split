using Split.UI.Forms;
using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI.UserControls
{
    public partial class GroupControl : UserControl
    {
        private readonly ControlsAdditions controlsAdditions;
        private readonly SplitServiceApi client;
        private readonly Guid groupId;

        public GroupControl()
        {
            InitializeComponent();
            controlsAdditions = new ControlsAdditions();
        }

        public GroupControl(SplitServiceApi client, Guid groupId)
        {
            InitializeComponent();
            controlsAdditions = new ControlsAdditions();
            this.client = client;
            this.groupId = groupId;
            SetData();
        }

        private void GroupControl_Load(object sender, EventArgs e)
        {
            SetActions(controlsAdditions.GetAll(this, typeof(ListBox)));
            SetActions(controlsAdditions.GetAll(this, typeof(RichTextBox)));
            SetActions(controlsAdditions.GetAll(this, typeof(Label)));
            SetActions(controlsAdditions.GetAll(this, typeof(Button)));

            descriptionTb.ReadOnly = true;
            descriptionTb.BackColor = Color.White;
            //MyExtensions.Disable(descriptionTb, nameLbl);
        }

        private async void SetData()
        {
            var group = await client.GetGroupAsync(groupId);
            if (group == null) return;

            dateLbl.Text = group.Date.Value.Date.ToShortDateString();
            nameLbl.Text = group.Name;
        }

        public void NewGroup()
        {
            this.Height /= 2;
            var button = new Button
            {
                Name = "addBtn",
                Text = "Создать группу",
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(91, 197, 167),
                ForeColor = Color.White,
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Click += addBtn_Click;

            nameLbl.Text = "";
            dateLbl.Text = "";
            descriptionTb.Text = "";

            tableLayoutPanel1.Controls.Remove(descriptionTb);
            tableLayoutPanel1.Controls.Remove(membersLb);
            tableLayoutPanel1.Controls.Add(button, 3, 0);


        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var form = new AddGroupForm();
            form.ShowDialog();
        }

        public void SetActions(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                control.MouseEnter += tableLayoutPanel1_MouseEnter;
                control.MouseLeave += tableLayoutPanel1_MouseLeave;
                control.MouseClick += tableLayoutPanel1_MouseClick;
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

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            var form = new GroupForm();
            form.ShowDialog();
        }

    }
}
