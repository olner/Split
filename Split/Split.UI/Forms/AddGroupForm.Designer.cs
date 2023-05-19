namespace Split.UI.Forms
{
    partial class AddGroupForm
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
            nameLbl = new Label();
            textBox1 = new TextBox();
            descriptionLbl = new Label();
            membersLbl = new Label();
            richTextBox1 = new RichTextBox();
            groupBox1 = new GroupBox();
            listBox1 = new ListBox();
            addTb = new TextBox();
            addLinklbl = new LinkLabel();
            saveBtn = new Button();
            cancelBtn = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nameLbl.Location = new Point(26, 23);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(173, 28);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "Название группы";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(261, 27);
            textBox1.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            descriptionLbl.AutoSize = true;
            descriptionLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionLbl.Location = new Point(25, 90);
            descriptionLbl.Name = "descriptionLbl";
            descriptionLbl.Size = new Size(177, 28);
            descriptionLbl.TabIndex = 2;
            descriptionLbl.Text = "Описание группы";
            // 
            // membersLbl
            // 
            membersLbl.AutoSize = true;
            membersLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            membersLbl.Location = new Point(26, 199);
            membersLbl.Name = "membersLbl";
            membersLbl.Size = new Size(107, 28);
            membersLbl.TabIndex = 4;
            membersLbl.Text = "Участники";
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Location = new Point(26, 121);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(261, 66);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(addTb);
            groupBox1.Controls.Add(addLinklbl);
            groupBox1.Controls.Add(nameLbl);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Controls.Add(descriptionLbl);
            groupBox1.Controls.Add(membersLbl);
            groupBox1.Location = new Point(26, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(311, 421);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавить";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(26, 230);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(261, 104);
            listBox1.TabIndex = 9;
            listBox1.KeyPress += listBox1_KeyPress;
            // 
            // addTb
            // 
            addTb.Location = new Point(26, 366);
            addTb.Name = "addTb";
            addTb.Size = new Size(261, 27);
            addTb.TabIndex = 8;
            addTb.Visible = false;
            addTb.Enter += addTb_Enter;
            addTb.KeyPress += addTb_KeyPress;
            // 
            // addLinklbl
            // 
            addLinklbl.AutoSize = true;
            addLinklbl.LinkBehavior = LinkBehavior.HoverUnderline;
            addLinklbl.Location = new Point(26, 338);
            addLinklbl.Name = "addLinklbl";
            addLinklbl.Size = new Size(163, 20);
            addLinklbl.TabIndex = 7;
            addLinklbl.TabStop = true;
            addLinklbl.Text = "+ Добавить участника";
            addLinklbl.LinkClicked += addLinklbl_LinkClicked;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(26, 453);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(114, 39);
            saveBtn.TabIndex = 8;
            saveBtn.Text = "Сохранить";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(223, 453);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(114, 39);
            cancelBtn.TabIndex = 9;
            cancelBtn.Text = "Назад";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // AddGroupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 504);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(groupBox1);
            Name = "AddGroupForm";
            Text = "Добавить группу";
            Load += AddGroupForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label nameLbl;
        private TextBox textBox1;
        private Label descriptionLbl;
        private Label membersLbl;
        private RichTextBox richTextBox1;
        private GroupBox groupBox1;
        private LinkLabel addLinklbl;
        private TextBox addTb;
        private Button saveBtn;
        private ListBox listBox1;
        private Button cancelBtn;
    }
}