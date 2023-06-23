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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            dateLbl = new Label();
            priceLbl = new Label();
            label1 = new Label();
            nameLbl = new Label();
            deleteBtn = new Button();
            updateTimer = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 99F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.6492F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.5125256F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.83827F));
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
            dateLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateLbl.Location = new Point(23, 37);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(53, 28);
            dateLbl.TabIndex = 0;
            dateLbl.Text = "Date";
            // 
            // priceLbl
            // 
            priceLbl.Anchor = AnchorStyles.None;
            priceLbl.AutoSize = true;
            priceLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            priceLbl.Location = new Point(491, 37);
            priceLbl.Name = "priceLbl";
            priceLbl.Size = new Size(54, 28);
            priceLbl.TabIndex = 1;
            priceLbl.Text = "Price";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(701, 37);
            label1.Name = "label1";
            label1.Size = new Size(192, 28);
            label1.TabIndex = 2;
            label1.Text = "Сколько ты должен";
            // 
            // nameLbl
            // 
            nameLbl.Anchor = AnchorStyles.Left;
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nameLbl.Location = new Point(102, 37);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(64, 28);
            nameLbl.TabIndex = 3;
            nameLbl.Text = "Name";
            // 
            // deleteBtn
            // 
            deleteBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deleteBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            deleteBtn.Location = new Point(969, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(93, 97);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Удалить";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // updateTimer
            // 
            updateTimer.Interval = 1000;
            updateTimer.Tick += updateTimer_Tick;
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
        private System.Windows.Forms.Timer updateTimer;
    }
}
