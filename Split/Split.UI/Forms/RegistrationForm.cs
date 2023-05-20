﻿using Split.WebClient;
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
    public partial class RegistrationForm : Form
    {
        private readonly SplitServiceApi client;
        private readonly ApplicationContext context;
        public RegistrationForm(ApplicationContext context, SplitServiceApi client)
        {
            InitializeComponent();
            this.context = context;
            this.client = client;
        }
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            registartionBtn.BackColor = Color.FromArgb(24, 165, 130);
            registartionBtn.BackColor2 = Color.FromArgb(28, 172, 120);
            registartionBtn.ForeColor = Color.White;

            registartionBtn.ButtonHighlightColor = Color.FromArgb(31, 209, 165);
            registartionBtn.ButtonHighlightColor2 = Color.FromArgb(64, 227, 186);

            registartionBtn.ButtonPressedColor = Color.FromArgb(31, 209, 165);
            registartionBtn.ButtonPressedColor2 = Color.FromArgb(64, 227, 186);
        }

        private void registartionBtn_Click(object sender, EventArgs e)
        {
            var form = new MainForm(client);
            context.MainForm = form;
            form.Show();
            //TODO: null exception
            this.Hide();
        }

        
    }
}
