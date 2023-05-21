namespace Split.UI.Forms
{
    partial class GroupForm
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
            accLbl = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            expenseTlp = new TableLayoutPanel();
            headerTlp = new TableLayoutPanel();
            groupNameLbl = new Label();
            addExpenseBtn = new Button();
            label1 = new Label();
            tabPage2 = new TabPage();
            membersTlp = new TableLayoutPanel();
            tabPage3 = new TabPage();
            label3 = new Label();
            groupBox1 = new GroupBox();
            resetBtn = new Button();
            saveBtn = new Button();
            label4 = new Label();
            descRtb = new RichTextBox();
            nameTb = new TextBox();
            label2 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            expenseTlp.SuspendLayout();
            headerTlp.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // accLbl
            // 
            accLbl.AutoSize = true;
            accLbl.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            accLbl.Location = new Point(35, 28);
            accLbl.Name = "accLbl";
            accLbl.Size = new Size(0, 37);
            accLbl.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Left;
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.ItemSize = new Size(30, 120);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1081, 505);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(expenseTlp);
            tabPage1.Location = new Point(124, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(953, 497);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Группа";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // expenseTlp
            // 
            expenseTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            expenseTlp.ColumnCount = 1;
            expenseTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            expenseTlp.Controls.Add(headerTlp, 0, 0);
            expenseTlp.Location = new Point(6, 6);
            expenseTlp.Name = "expenseTlp";
            expenseTlp.RowCount = 2;
            expenseTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            expenseTlp.RowStyles.Add(new RowStyle());
            expenseTlp.Size = new Size(941, 485);
            expenseTlp.TabIndex = 0;
            // 
            // headerTlp
            // 
            headerTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            headerTlp.ColumnCount = 3;
            headerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            headerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.9679146F));
            headerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.7700539F));
            headerTlp.Controls.Add(groupNameLbl, 0, 0);
            headerTlp.Controls.Add(addExpenseBtn, 2, 0);
            headerTlp.Controls.Add(label1, 1, 0);
            headerTlp.Location = new Point(3, 3);
            headerTlp.Name = "headerTlp";
            headerTlp.RowCount = 1;
            headerTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headerTlp.Size = new Size(935, 65);
            headerTlp.TabIndex = 0;
            // 
            // groupNameLbl
            // 
            groupNameLbl.Anchor = AnchorStyles.None;
            groupNameLbl.AutoSize = true;
            groupNameLbl.Location = new Point(108, 22);
            groupNameLbl.Name = "groupNameLbl";
            groupNameLbl.Size = new Size(94, 20);
            groupNameLbl.TabIndex = 0;
            groupNameLbl.Text = "Group Name";
            // 
            // addExpenseBtn
            // 
            addExpenseBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addExpenseBtn.Location = new Point(668, 3);
            addExpenseBtn.Name = "addExpenseBtn";
            addExpenseBtn.Size = new Size(264, 59);
            addExpenseBtn.TabIndex = 1;
            addExpenseBtn.Text = "Добавить расход";
            addExpenseBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(371, 22);
            label1.Name = "label1";
            label1.Size = new Size(233, 20);
            label1.TabIndex = 2;
            label1.Text = "Ты всего должен: сокато токато ";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(membersTlp);
            tabPage2.Location = new Point(124, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(953, 497);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Участники";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // membersTlp
            // 
            membersTlp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            membersTlp.ColumnCount = 1;
            membersTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            membersTlp.Location = new Point(6, 6);
            membersTlp.Name = "membersTlp";
            membersTlp.RowCount = 2;
            membersTlp.RowStyles.Add(new RowStyle());
            membersTlp.RowStyles.Add(new RowStyle());
            membersTlp.Size = new Size(941, 485);
            membersTlp.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Location = new Point(124, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(953, 497);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Настройки";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(230, 35);
            label3.TabIndex = 2;
            label3.Text = "Настройки группы";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(resetBtn);
            groupBox1.Controls.Add(saveBtn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(descRtb);
            groupBox1.Controls.Add(nameTb);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(13, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(345, 444);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // resetBtn
            // 
            resetBtn.Location = new Point(69, 263);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(94, 60);
            resetBtn.TabIndex = 6;
            resetBtn.Text = "Отмена";
            resetBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(169, 263);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(170, 60);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Сохранить";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 95);
            label4.Name = "label4";
            label4.Size = new Size(104, 28);
            label4.TabIndex = 4;
            label4.Text = "Описание";
            // 
            // descRtb
            // 
            descRtb.Location = new Point(6, 126);
            descRtb.Name = "descRtb";
            descRtb.Size = new Size(333, 131);
            descRtb.TabIndex = 3;
            descRtb.Text = "";
            // 
            // nameTb
            // 
            nameTb.Location = new Point(6, 54);
            nameTb.Name = "nameTb";
            nameTb.Size = new Size(333, 27);
            nameTb.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 23);
            label2.Name = "label2";
            label2.Size = new Size(173, 28);
            label2.TabIndex = 1;
            label2.Text = "Название группы";
            // 
            // GroupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 529);
            Controls.Add(tabControl1);
            Controls.Add(accLbl);
            Name = "GroupForm";
            Text = "GroupName - группа";
            Load += GroupForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            expenseTlp.ResumeLayout(false);
            headerTlp.ResumeLayout(false);
            headerTlp.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label accLbl;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TableLayoutPanel expenseTlp;
        private TableLayoutPanel headerTlp;
        private Label groupNameLbl;
        private Button addExpenseBtn;
        private Label label1;
        private TableLayoutPanel membersTlp;
        private Label label3;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox nameTb;
        private Label label4;
        private RichTextBox descRtb;
        private Button resetBtn;
        private Button saveBtn;
    }
}