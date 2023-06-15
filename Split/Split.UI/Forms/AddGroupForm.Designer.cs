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
            nameTb = new TextBox();
            descriptionLbl = new Label();
            membersLbl = new Label();
            descriptionRtb = new RichTextBox();
            groupBox1 = new GroupBox();
            addTb = new ComboBox();
            membersLb = new ListBox();
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
            // nameTb
            // 
            nameTb.Location = new Point(26, 54);
            nameTb.Name = "nameTb";
            nameTb.Size = new Size(261, 27);
            nameTb.TabIndex = 1;
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
            // descriptionRtb
            // 
            descriptionRtb.BorderStyle = BorderStyle.FixedSingle;
            descriptionRtb.Location = new Point(26, 121);
            descriptionRtb.Name = "descriptionRtb";
            descriptionRtb.Size = new Size(261, 66);
            descriptionRtb.TabIndex = 5;
            descriptionRtb.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(addTb);
            groupBox1.Controls.Add(membersLb);
            groupBox1.Controls.Add(addLinklbl);
            groupBox1.Controls.Add(nameLbl);
            groupBox1.Controls.Add(nameTb);
            groupBox1.Controls.Add(descriptionRtb);
            groupBox1.Controls.Add(descriptionLbl);
            groupBox1.Controls.Add(membersLbl);
            groupBox1.Location = new Point(26, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(311, 421);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавить";
            // 
            // addTb
            // 
            addTb.FormattingEnabled = true;
            addTb.Location = new Point(25, 361);
            addTb.Name = "addTb";
            addTb.Size = new Size(262, 28);
            addTb.TabIndex = 10;
            addTb.Enter += addTb_Enter;
            addTb.KeyPress += addTb_KeyPress;
            // 
            // membersLb
            // 
            membersLb.FormattingEnabled = true;
            membersLb.ItemHeight = 20;
            membersLb.Location = new Point(26, 230);
            membersLb.Name = "membersLb";
            membersLb.Size = new Size(261, 104);
            membersLb.TabIndex = 9;
            membersLb.KeyPress += listBox1_KeyPress;
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
        private TextBox nameTb;
        private Label descriptionLbl;
        private Label membersLbl;
        private RichTextBox descriptionRtb;
        private GroupBox groupBox1;
        private LinkLabel addLinklbl;
        private Button saveBtn;
        private ListBox membersLb;
        private Button cancelBtn;
        private ComboBox addTb;
    }
}