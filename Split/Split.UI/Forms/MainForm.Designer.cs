﻿namespace Split.UI.Forms
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
            tabControl1 = new TabControl();
            groupsPage = new TabPage();
            groupsTlp = new TableLayoutPanel();
            friendsPage = new TabPage();
            friendsTlp = new TableLayoutPanel();
            accountPage = new TabPage();
            pictureBox1 = new PictureBox();
            accLbl = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            saveBtn = new Button();
            groupBox1 = new GroupBox();
            tabControl1.SuspendLayout();
            groupsPage.SuspendLayout();
            friendsPage.SuspendLayout();
            accountPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
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
            tabControl1.Size = new Size(1096, 529);
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
            groupsPage.Size = new Size(968, 521);
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
            groupsTlp.Size = new Size(959, 509);
            groupsTlp.TabIndex = 0;
            // 
            // friendsPage
            // 
            friendsPage.Controls.Add(friendsTlp);
            friendsPage.Location = new Point(124, 4);
            friendsPage.Name = "friendsPage";
            friendsPage.Padding = new Padding(3);
            friendsPage.Size = new Size(968, 521);
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
            friendsTlp.Size = new Size(944, 512);
            friendsTlp.TabIndex = 0;
            // 
            // accountPage
            // 
            accountPage.Controls.Add(groupBox1);
            accountPage.Controls.Add(accLbl);
            accountPage.Location = new Point(124, 4);
            accountPage.Name = "accountPage";
            accountPage.Size = new Size(968, 521);
            accountPage.TabIndex = 2;
            accountPage.Text = "Профиль";
            accountPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(6, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(204, 168);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // accLbl
            // 
            accLbl.AutoSize = true;
            accLbl.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            accLbl.Location = new Point(14, 16);
            accLbl.Name = "accLbl";
            accLbl.Size = new Size(169, 37);
            accLbl.TabIndex = 1;
            accLbl.Text = "Ваш аккаунт";
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
            // textBox1
            // 
            textBox1.Location = new Point(230, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 89);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(230, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(230, 142);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 7;
            label3.Text = "Пароль";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(230, 167);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 8;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(261, 220);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 29);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "Сохранить";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(saveBtn);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Location = new Point(14, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 452);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 553);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Split - Группы";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            groupsPage.ResumeLayout(false);
            friendsPage.ResumeLayout(false);
            accountPage.ResumeLayout(false);
            accountPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private PictureBox pictureBox1;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button saveBtn;
        private GroupBox groupBox1;
    }
}