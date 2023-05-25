namespace Split.UI.UserControls
{
    partial class ExpenseControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            dateLbl = new Label();
            priceLbl = new Label();
            label1 = new Label();
            nameLbl = new Label();
            deleteBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.889793F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.6587334F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.1077F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34377F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(dateLbl, 0, 0);
            tableLayoutPanel1.Controls.Add(priceLbl, 2, 0);
            tableLayoutPanel1.Controls.Add(label1, 3, 0);
            tableLayoutPanel1.Controls.Add(nameLbl, 1, 0);
            tableLayoutPanel1.Controls.Add(deleteBtn, 4, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1065, 103);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dateLbl
            // 
            dateLbl.Anchor = AnchorStyles.None;
            dateLbl.AutoSize = true;
            dateLbl.Location = new Point(18, 41);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(41, 20);
            dateLbl.TabIndex = 0;
            dateLbl.Text = "Date";
            // 
            // priceLbl
            // 
            priceLbl.Anchor = AnchorStyles.None;
            priceLbl.AutoSize = true;
            priceLbl.Location = new Point(512, 41);
            priceLbl.Name = "priceLbl";
            priceLbl.Size = new Size(41, 20);
            priceLbl.TabIndex = 1;
            priceLbl.Text = "Price";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(741, 41);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 2;
            label1.Text = "Сколько ты должен";
            // 
            // nameLbl
            // 
            nameLbl.Anchor = AnchorStyles.Left;
            nameLbl.AutoSize = true;
            nameLbl.Location = new Point(80, 41);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(49, 20);
            nameLbl.TabIndex = 3;
            nameLbl.Text = "Name";
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(979, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(81, 97);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Удалить";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // ExpenseControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "ExpenseControl";
            Size = new Size(1069, 109);
            Load += ExpenseControl_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label dateLbl;
        private Label priceLbl;
        private Label label1;
        private Label nameLbl;
        private Button deleteBtn;
    }
}
