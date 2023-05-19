﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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