﻿using Split.UI.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Split.UI.Forms
{
    public partial class AddGroupForm : Form
    {
        public AddGroupForm()
        {
            InitializeComponent();
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            addTb.Text = "Name";
            addTb.ForeColor = Color.Gray;

            /*dataGridView1.BackgroundColor = Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ReadOnly = tr
            //dataGridView1.Columns["YourIdColumn"].Visible = false;*/
        }

        private void addLinklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addTb.Visible = true;
        }

        private void addTb_Enter(object sender, EventArgs e)
        {
            addTb.Text = null;
            addTb.ForeColor = Color.Black;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                listBox1.Items.Add(addTb.Text);
            }
        }
    }
}