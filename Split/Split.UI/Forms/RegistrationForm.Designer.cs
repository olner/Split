namespace Split.UI.Forms
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            loginTb = new TextBox();
            passwordTb = new TextBox();
            registartionBtn = new Tools.CustomControls.RoundButton();
            emailTb = new TextBox();
            warningLbl = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.8484859F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51.81818F));
            tableLayoutPanel1.Size = new Size(433, 477);
            tableLayoutPanel1.TabIndex = 1;
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
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel2);
            groupBox1.Location = new Point(3, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(427, 365);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Регистрация";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(loginTb, 0, 0);
            tableLayoutPanel2.Controls.Add(passwordTb, 0, 1);
            tableLayoutPanel2.Controls.Add(registartionBtn, 0, 3);
            tableLayoutPanel2.Controls.Add(emailTb, 0, 2);
            tableLayoutPanel2.Controls.Add(warningLbl, 0, 4);
            tableLayoutPanel2.Location = new Point(6, 26);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 22.8699551F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 22.8699551F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 26.0089684F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 28.3237F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
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
            passwordTb.Location = new Point(3, 54);
            passwordTb.Multiline = true;
            passwordTb.Name = "passwordTb";
            passwordTb.Size = new Size(409, 40);
            passwordTb.TabIndex = 1;
            passwordTb.Enter += passwordTb_Enter;
            // 
            // registartionBtn
            // 
            registartionBtn.BackColor = Color.Gainsboro;
            registartionBtn.BackColor2 = Color.Silver;
            registartionBtn.ButtonBorderColor = Color.Black;
            registartionBtn.ButtonHighlightColor = Color.Orange;
            registartionBtn.ButtonHighlightColor2 = Color.OrangeRed;
            registartionBtn.ButtonHighlightForeColor = Color.Black;
            registartionBtn.ButtonPressedColor = Color.Red;
            registartionBtn.ButtonPressedColor2 = Color.Maroon;
            registartionBtn.ButtonPressedForeColor = Color.White;
            registartionBtn.ButtonRoundRadius = 30;
            registartionBtn.Location = new Point(3, 163);
            registartionBtn.Name = "registartionBtn";
            registartionBtn.Size = new Size(409, 46);
            registartionBtn.TabIndex = 4;
            registartionBtn.Text = "Регистрация";
            registartionBtn.Click += registartionBtn_Click;
            // 
            // emailTb
            // 
            emailTb.Location = new Point(3, 105);
            emailTb.Multiline = true;
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(409, 40);
            emailTb.TabIndex = 2;
            emailTb.Enter += emailTb_Enter;
            // 
            // warningLbl
            // 
            warningLbl.AutoSize = true;
            warningLbl.Location = new Point(3, 223);
            warningLbl.Name = "warningLbl";
            warningLbl.Size = new Size(64, 20);
            warningLbl.TabIndex = 5;
            warningLbl.Text = "Warning";
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 501);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            Name = "RegistrationForm";
            Text = "Регистрация";
            Load += RegistrationForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox loginTb;
        private TextBox passwordTb;
        private TextBox emailTb;
        private Tools.CustomControls.RoundButton registartionBtn;
        private Label warningLbl;
    }
}