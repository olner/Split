namespace Split.UI.Forms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            groupsPage = new TabPage();
            groupsTlp = new TableLayoutPanel();
            friendsPage = new TabPage();
            friendsTlp = new TableLayoutPanel();
            accountPage = new TabPage();
            profileTlp = new TableLayoutPanel();
            label4 = new Label();
            accLbl = new Label();
            groupBox1 = new GroupBox();
            showPaswordCheckBox = new CheckBox();
            deleteBtn = new Button();
            profilePb = new PictureBox();
            saveBtn = new Button();
            label1 = new Label();
            passwordTb = new TextBox();
            nameTb = new TextBox();
            label3 = new Label();
            label2 = new Label();
            emailTb = new TextBox();
            additionalTlp = new TableLayoutPanel();
            expensesTlp = new TableLayoutPanel();
            friendRequestTlp = new TableLayoutPanel();
            label5 = new Label();
            updateTimer = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            groupsPage.SuspendLayout();
            friendsPage.SuspendLayout();
            accountPage.SuspendLayout();
            profileTlp.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePb).BeginInit();
            additionalTlp.SuspendLayout();
            friendRequestTlp.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(groupsPage);
            tabControl1.Controls.Add(friendsPage);
            tabControl1.Controls.Add(accountPage);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.ItemSize = new Size(30, 120);
            tabControl1.Location = new Point(-3, 12);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1212, 548);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 0;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // groupsPage
            // 
            groupsPage.Controls.Add(groupsTlp);
            groupsPage.Location = new Point(124, 4);
            groupsPage.Name = "groupsPage";
            groupsPage.Padding = new Padding(3);
            groupsPage.Size = new Size(1084, 540);
            groupsPage.TabIndex = 0;
            groupsPage.Text = "Группы";
            groupsPage.UseVisualStyleBackColor = true;
            // 
            // groupsTlp
            // 
            groupsTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupsTlp.ColumnCount = 1;
            groupsTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            groupsTlp.Location = new Point(6, 6);
            groupsTlp.Name = "groupsTlp";
            groupsTlp.RowCount = 2;
            groupsTlp.RowStyles.Add(new RowStyle());
            groupsTlp.RowStyles.Add(new RowStyle());
            groupsTlp.Size = new Size(1075, 528);
            groupsTlp.TabIndex = 0;
            // 
            // friendsPage
            // 
            friendsPage.Controls.Add(friendsTlp);
            friendsPage.Location = new Point(124, 4);
            friendsPage.Name = "friendsPage";
            friendsPage.Padding = new Padding(3);
            friendsPage.Size = new Size(1084, 540);
            friendsPage.TabIndex = 1;
            friendsPage.Text = "Друзья";
            friendsPage.UseVisualStyleBackColor = true;
            // 
            // friendsTlp
            // 
            friendsTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            friendsTlp.ColumnCount = 1;
            friendsTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            friendsTlp.Location = new Point(6, 6);
            friendsTlp.Name = "friendsTlp";
            friendsTlp.RowCount = 2;
            friendsTlp.RowStyles.Add(new RowStyle());
            friendsTlp.RowStyles.Add(new RowStyle());
            friendsTlp.Size = new Size(1072, 528);
            friendsTlp.TabIndex = 0;
            // 
            // accountPage
            // 
            accountPage.Controls.Add(profileTlp);
            accountPage.Location = new Point(124, 4);
            accountPage.Name = "accountPage";
            accountPage.Size = new Size(1084, 540);
            accountPage.TabIndex = 2;
            accountPage.Text = "Профиль";
            accountPage.UseVisualStyleBackColor = true;
            // 
            // profileTlp
            // 
            profileTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            profileTlp.ColumnCount = 2;
            profileTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 485F));
            profileTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            profileTlp.Controls.Add(label4, 1, 0);
            profileTlp.Controls.Add(accLbl, 0, 0);
            profileTlp.Controls.Add(groupBox1, 0, 1);
            profileTlp.Controls.Add(additionalTlp, 1, 1);
            profileTlp.Location = new Point(3, 3);
            profileTlp.Name = "profileTlp";
            profileTlp.RowCount = 2;
            profileTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 6.65362024F));
            profileTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 93.34638F));
            profileTlp.Size = new Size(1078, 534);
            profileTlp.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(488, 0);
            label4.Name = "label4";
            label4.Size = new Size(194, 35);
            label4.TabIndex = 12;
            label4.Text = "Ваши покупки";
            // 
            // accLbl
            // 
            accLbl.AutoSize = true;
            accLbl.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            accLbl.Location = new Point(3, 0);
            accLbl.Name = "accLbl";
            accLbl.Size = new Size(169, 35);
            accLbl.TabIndex = 1;
            accLbl.Text = "Ваш аккаунт";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(showPaswordCheckBox);
            groupBox1.Controls.Add(deleteBtn);
            groupBox1.Controls.Add(profilePb);
            groupBox1.Controls.Add(saveBtn);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(passwordTb);
            groupBox1.Controls.Add(nameTb);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(emailTb);
            groupBox1.Location = new Point(3, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(479, 493);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            // 
            // showPaswordCheckBox
            // 
            showPaswordCheckBox.AutoSize = true;
            showPaswordCheckBox.Location = new Point(296, 200);
            showPaswordCheckBox.Name = "showPaswordCheckBox";
            showPaswordCheckBox.Size = new Size(176, 24);
            showPaswordCheckBox.TabIndex = 11;
            showPaswordCheckBox.Text = "Показывать пароль?";
            showPaswordCheckBox.UseVisualStyleBackColor = true;
            showPaswordCheckBox.CheckedChanged += showPaswordCheckBox_CheckedChanged;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(328, 452);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(145, 35);
            deleteBtn.TabIndex = 10;
            deleteBtn.Text = "Удалить аккаунт";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // profilePb
            // 
            profilePb.Location = new Point(6, 26);
            profilePb.Name = "profilePb";
            profilePb.Size = new Size(204, 168);
            profilePb.SizeMode = PictureBoxSizeMode.Zoom;
            profilePb.TabIndex = 2;
            profilePb.TabStop = false;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(329, 230);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(144, 42);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "Сохранить";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(230, 26);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 3;
            label1.Text = "Имя";
            // 
            // passwordTb
            // 
            passwordTb.Location = new Point(230, 167);
            passwordTb.Name = "passwordTb";
            passwordTb.PasswordChar = '*';
            passwordTb.Size = new Size(242, 27);
            passwordTb.TabIndex = 8;
            // 
            // nameTb
            // 
            nameTb.Location = new Point(230, 49);
            nameTb.Name = "nameTb";
            nameTb.Size = new Size(242, 27);
            nameTb.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(230, 144);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 7;
            label3.Text = "Пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 91);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // emailTb
            // 
            emailTb.Location = new Point(230, 114);
            emailTb.Name = "emailTb";
            emailTb.Size = new Size(242, 27);
            emailTb.TabIndex = 6;
            // 
            // additionalTlp
            // 
            additionalTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            additionalTlp.ColumnCount = 1;
            additionalTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            additionalTlp.Controls.Add(expensesTlp, 0, 0);
            additionalTlp.Controls.Add(friendRequestTlp, 0, 1);
            additionalTlp.Location = new Point(488, 38);
            additionalTlp.Name = "additionalTlp";
            additionalTlp.RowCount = 2;
            additionalTlp.RowStyles.Add(new RowStyle());
            additionalTlp.RowStyles.Add(new RowStyle());
            additionalTlp.Size = new Size(587, 493);
            additionalTlp.TabIndex = 13;
            // 
            // expensesTlp
            // 
            expensesTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            expensesTlp.ColumnCount = 1;
            expensesTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            expensesTlp.Location = new Point(3, 3);
            expensesTlp.Name = "expensesTlp";
            expensesTlp.RowCount = 2;
            expensesTlp.RowStyles.Add(new RowStyle());
            expensesTlp.RowStyles.Add(new RowStyle());
            expensesTlp.Size = new Size(581, 240);
            expensesTlp.TabIndex = 12;
            // 
            // friendRequestTlp
            // 
            friendRequestTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            friendRequestTlp.ColumnCount = 1;
            friendRequestTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            friendRequestTlp.Controls.Add(label5, 0, 0);
            friendRequestTlp.Location = new Point(3, 249);
            friendRequestTlp.Name = "friendRequestTlp";
            friendRequestTlp.RowCount = 2;
            friendRequestTlp.RowStyles.Add(new RowStyle());
            friendRequestTlp.RowStyles.Add(new RowStyle());
            friendRequestTlp.Size = new Size(581, 241);
            friendRequestTlp.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(243, 38);
            label5.TabIndex = 0;
            label5.Text = "Запросы в друзья";
            // 
            // updateTimer
            // 
            updateTimer.Interval = 1000;
            updateTimer.Tick += updateTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 572);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Split - Группы";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            groupsPage.ResumeLayout(false);
            friendsPage.ResumeLayout(false);
            accountPage.ResumeLayout(false);
            profileTlp.ResumeLayout(false);
            profileTlp.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)profilePb).EndInit();
            additionalTlp.ResumeLayout(false);
            friendRequestTlp.ResumeLayout(false);
            friendRequestTlp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage groupsPage;
        private TabPage friendsPage;
        private TabPage accountPage;
        private TableLayoutPanel groupsTlp;
        private TableLayoutPanel friendsTlp;
        private Label accLbl;
        private PictureBox profilePb;
        private TextBox passwordTb;
        private Label label3;
        private TextBox emailTb;
        private Label label2;
        private TextBox nameTb;
        private Label label1;
        private Button saveBtn;
        private GroupBox groupBox1;
        private TableLayoutPanel profileTlp;
        private Label label4;
        private Button deleteBtn;
        private TableLayoutPanel additionalTlp;
        private TableLayoutPanel expensesTlp;
        private TableLayoutPanel friendRequestTlp;
        private Label label5;
        private CheckBox showPaswordCheckBox;
        private System.Windows.Forms.Timer updateTimer;
    }
}