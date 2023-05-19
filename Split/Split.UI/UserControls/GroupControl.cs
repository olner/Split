using Split.UI.Forms;
using Split.UI.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Split.UI.UserControls
{
    public partial class GroupControl : UserControl
    {
        private readonly ControlsAdditions controlsAdditions;
        public GroupControl()
        {
            InitializeComponent();   
            controlsAdditions = new ControlsAdditions();
        }

        public void NewGroup()
        {
            var button = new Button
            {
                Name = "addBtn",
                Text = "Добавить группу",
                Size = new Size(300,50),
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
            button.Click += addBtn_Click;
            tableLayoutPanel1.Controls.Remove(label1);
            tableLayoutPanel1.Controls.Add(button, 3, 0);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var form = new AddGroupForm();
            form.ShowDialog();
        }

        private void GroupControl_Load(object sender, EventArgs e)
        {
            SetActions(controlsAdditions.GetAll(this, typeof(Label)));
            SetActions(controlsAdditions.GetAll(this, typeof(Button)));
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


    }
}
