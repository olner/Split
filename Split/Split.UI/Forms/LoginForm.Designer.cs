﻿namespace Split.UI
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            loginTb = new TextBox();
            passwordTb = new TextBox();
            linkLabel1 = new LinkLabel();
            loginBtn = new Tools.CustomControls.RoundButton();
            errorGB = new GroupBox();
            errorLbl = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            errorGB.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.8484859F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.81818F));
            tableLayoutPanel1.Size = new Size(433, 477);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Location = new Point(3, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(427, 365);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Вход";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(loginTb, 0, 0);
            tableLayoutPanel2.Controls.Add(passwordTb, 0, 1);
            tableLayoutPanel2.Controls.Add(linkLabel1, 0, 3);
            tableLayoutPanel2.Controls.Add(loginBtn, 0, 2);
            tableLayoutPanel2.Controls.Add(errorGB, 0, 4);
            tableLayoutPanel2.Location = new Point(6, 26);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 21.09375F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 23.046875F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20.3125F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35.546875F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel2.Size = new Size(415, 333);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // loginTb
            // 
            loginTb.Location = new Point(3, 3);
            loginTb.Multiline = true;
            loginTb.Name = "loginTb";
            loginTb.Size = new Size(409, 40);
            loginTb.TabIndex = 0;
            loginTb.Enter += loginTb_Enter;
            // 
            // passwordTb
            // 
            passwordTb.Location = new Point(3, 57);
            passwordTb.Multiline = true;
            passwordTb.Name = "passwordTb";
            passwordTb.Size = new Size(409, 40);
            passwordTb.TabIndex = 1;
            passwordTb.Enter += passwordTb_Enter;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(132, 165);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(151, 20);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Зарегистрироваться";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.Gainsboro;
            loginBtn.BackColor2 = Color.Silver;
            loginBtn.ButtonBorderColor = Color.Black;
            loginBtn.ButtonHighlightColor = Color.Orange;
            loginBtn.ButtonHighlightColor2 = Color.OrangeRed;
            loginBtn.ButtonHighlightForeColor = Color.Black;
            loginBtn.ButtonPressedColor = Color.Red;
            loginBtn.ButtonPressedColor2 = Color.Maroon;
            loginBtn.ButtonPressedForeColor = Color.White;
            loginBtn.ButtonRoundRadius = 30;
            loginBtn.Location = new Point(3, 116);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(409, 46);
            loginBtn.TabIndex = 4;
            loginBtn.Text = "Вход";
            loginBtn.Click += loginBtn_Click;
            // 
            // errorGB
            // 
            errorGB.Controls.Add(errorLbl);
            errorGB.Location = new Point(3, 259);
            errorGB.Name = "errorGB";
            errorGB.Size = new Size(409, 71);
            errorGB.TabIndex = 5;
            errorGB.TabStop = false;
            errorGB.Visible = false;
            // 
            // errorLbl
            // 
            errorLbl.AutoSize = true;
            errorLbl.Location = new Point(6, 14);
            errorLbl.Name = "errorLbl";
            errorLbl.Size = new Size(50, 20);
            errorLbl.TabIndex = 0;
            errorLbl.Text = "label2";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(173, 60);
            label1.Name = "label1";
            label1.Size = new Size(86, 46);
            label1.TabIndex = 0;
            label1.Text = "Split";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 501);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Авторизация";
            Load += LoginForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            errorGB.ResumeLayout(false);
            errorGB.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox loginTb;
        private TextBox passwordTb;
        private LinkLabel linkLabel1;
        private Tools.CustomControls.RoundButton loginBtn;
        private GroupBox errorGB;
        private Label errorLbl;
    }
}