namespace Split.UI.Forms
{
    partial class AddExpenseForm
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
            groupBox1 = new GroupBox();
            sumTb = new TextBox();
            tabControl1 = new TabControl();
            equalTp = new TabPage();
            equalLbl = new Label();
            checkedListBox1 = new CheckedListBox();
            tabPage2 = new TabPage();
            amountLbl = new Label();
            amountTlp = new TableLayoutPanel();
            tabPage3 = new TabPage();
            percentLbl = new Label();
            percentTlp = new TableLayoutPanel();
            cancelBtn = new Button();
            saveBtn = new Button();
            dateTimePicker1 = new DateTimePicker();
            sumLbl = new Label();
            nameLbl = new Label();
            nameTb = new TextBox();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            equalTp.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(sumTb);
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Controls.Add(cancelBtn);
            groupBox1.Controls.Add(saveBtn);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(sumLbl);
            groupBox1.Controls.Add(nameLbl);
            groupBox1.Controls.Add(nameTb);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(379, 567);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавить";
            // 
            // sumTb
            // 
            sumTb.Location = new Point(29, 139);
            sumTb.Name = "sumTb";
            sumTb.Size = new Size(340, 27);
            sumTb.TabIndex = 8;
            sumTb.TextChanged += sumTb_TextChanged;
            sumTb.KeyDown += sumTb_KeyDown;
            sumTb.KeyPress += sumTb_KeyPress;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(equalTp);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(29, 242);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(344, 253);
            tabControl1.TabIndex = 7;
            // 
            // equalTp
            // 
            equalTp.Controls.Add(equalLbl);
            equalTp.Controls.Add(checkedListBox1);
            equalTp.Location = new Point(4, 29);
            equalTp.Name = "equalTp";
            equalTp.Padding = new Padding(3);
            equalTp.Size = new Size(336, 220);
            equalTp.TabIndex = 0;
            equalTp.Text = "Поровну";
            equalTp.UseVisualStyleBackColor = true;
            // 
            // equalLbl
            // 
            equalLbl.AutoSize = true;
            equalLbl.Location = new Point(3, 14);
            equalLbl.Name = "equalLbl";
            equalLbl.Size = new Size(125, 20);
            equalLbl.TabIndex = 1;
            equalLbl.Text = "Каждый должен:";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(3, 37);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(330, 180);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(amountLbl);
            tabPage2.Controls.Add(amountTlp);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(336, 220);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Точно";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // amountLbl
            // 
            amountLbl.AutoSize = true;
            amountLbl.Location = new Point(6, 14);
            amountLbl.Name = "amountLbl";
            amountLbl.Size = new Size(88, 20);
            amountLbl.TabIndex = 1;
            amountLbl.Text = "Осталось: 0";
            // 
            // amountTlp
            // 
            amountTlp.ColumnCount = 1;
            amountTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            amountTlp.Location = new Point(3, 37);
            amountTlp.Name = "amountTlp";
            amountTlp.RowCount = 2;
            amountTlp.RowStyles.Add(new RowStyle());
            amountTlp.RowStyles.Add(new RowStyle());
            amountTlp.Size = new Size(330, 180);
            amountTlp.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(percentLbl);
            tabPage3.Controls.Add(percentTlp);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(336, 220);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Процентно";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // percentLbl
            // 
            percentLbl.AutoSize = true;
            percentLbl.Location = new Point(3, 14);
            percentLbl.Name = "percentLbl";
            percentLbl.Size = new Size(156, 20);
            percentLbl.TabIndex = 1;
            percentLbl.Text = "Процентов осталось:";
            // 
            // percentTlp
            // 
            percentTlp.ColumnCount = 1;
            percentTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            percentTlp.Location = new Point(3, 37);
            percentTlp.Name = "percentTlp";
            percentTlp.RowCount = 2;
            percentTlp.RowStyles.Add(new RowStyle());
            percentTlp.RowStyles.Add(new RowStyle());
            percentTlp.Size = new Size(330, 180);
            percentTlp.TabIndex = 0;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(144, 501);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(123, 51);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Отмена";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(273, 501);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(96, 51);
            saveBtn.TabIndex = 5;
            saveBtn.Text = "Сохранить";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(29, 197);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(340, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // sumLbl
            // 
            sumLbl.AutoSize = true;
            sumLbl.Location = new Point(29, 116);
            sumLbl.Name = "sumLbl";
            sumLbl.Size = new Size(55, 20);
            sumLbl.TabIndex = 2;
            sumLbl.Text = "Сумма";
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Location = new Point(29, 39);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(77, 20);
            nameLbl.TabIndex = 1;
            nameLbl.Text = "Название";
            // 
            // nameTb
            // 
            nameTb.Location = new Point(29, 62);
            nameTb.Name = "nameTb";
            nameTb.Size = new Size(340, 27);
            nameTb.TabIndex = 0;
            // 
            // AddExpenseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 591);
            Controls.Add(groupBox1);
            Name = "AddExpenseForm";
            Text = "Добавить трату";
            Load += AddExpenseForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            equalTp.ResumeLayout(false);
            equalTp.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox nameTb;
        private Label nameLbl;
        private Label sumLbl;
        private DateTimePicker dateTimePicker1;
        private Button cancelBtn;
        private Button saveBtn;
        private TabControl tabControl1;
        private TabPage equalTp;
        private TabPage tabPage2;
        private CheckedListBox checkedListBox1;
        private TabPage tabPage3;
        private Label equalLbl;
        private TextBox sumTb;
        private TableLayoutPanel percentTlp;
        private TableLayoutPanel amountTlp;
        private Label amountLbl;
        private Label percentLbl;
    }
}