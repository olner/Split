namespace Split.UI.UserControls
{
    partial class FriendControl
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
            pictureBox1 = new PictureBox();
            nameLbl = new Label();
            deleteBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.91129F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.94355F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.2459679F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(nameLbl, 1, 0);
            tableLayoutPanel1.Controls.Add(deleteBtn, 2, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(990, 98);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.MouseEnter += tableLayoutPanel1_MouseEnter;
            tableLayoutPanel1.MouseLeave += tableLayoutPanel1_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 92);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // nameLbl
            // 
            nameLbl.Anchor = AnchorStyles.Left;
            nameLbl.AutoSize = true;
            nameLbl.Location = new Point(140, 39);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(49, 20);
            nameLbl.TabIndex = 1;
            nameLbl.Text = "Name";
            // 
            // deleteBtn
            // 
            deleteBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deleteBtn.Location = new Point(811, 3);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(176, 92);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "Удалить";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // FriendControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "FriendControl";
            Size = new Size(996, 104);
            Load += FriendControl_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Label nameLbl;
        private Button deleteBtn;
    }
}
