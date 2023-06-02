namespace Split.UI.UserControls
{
    partial class GroupControl
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
            nameLbl = new Label();
            membersLb = new ListBox();
            descriptionTb = new RichTextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4834F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.6192827F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.39802F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(dateLbl, 0, 0);
            tableLayoutPanel1.Controls.Add(nameLbl, 1, 0);
            tableLayoutPanel1.Controls.Add(membersLb, 3, 0);
            tableLayoutPanel1.Controls.Add(descriptionTb, 2, 0);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(809, 97);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.MouseClick += tableLayoutPanel1_MouseClick;
            tableLayoutPanel1.MouseEnter += tableLayoutPanel1_MouseEnter;
            tableLayoutPanel1.MouseLeave += tableLayoutPanel1_MouseLeave;
            // 
            // dateLbl
            // 
            dateLbl.Anchor = AnchorStyles.None;
            dateLbl.AutoSize = true;
            dateLbl.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            dateLbl.Location = new Point(21, 33);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(58, 30);
            dateLbl.TabIndex = 0;
            dateLbl.Text = "Date";
            // 
            // nameLbl
            // 
            nameLbl.Anchor = AnchorStyles.None;
            nameLbl.AutoSize = true;
            nameLbl.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            nameLbl.Location = new Point(112, 33);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(71, 30);
            nameLbl.TabIndex = 1;
            nameLbl.Text = "Name";
            // 
            // membersLb
            // 
            membersLb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            membersLb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            membersLb.FormattingEnabled = true;
            membersLb.ItemHeight = 25;
            membersLb.Location = new Point(541, 3);
            membersLb.Name = "membersLb";
            membersLb.Size = new Size(265, 79);
            membersLb.TabIndex = 3;
            // 
            // descriptionTb
            // 
            descriptionTb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            descriptionTb.BorderStyle = BorderStyle.FixedSingle;
            descriptionTb.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            descriptionTb.Location = new Point(198, 3);
            descriptionTb.Name = "descriptionTb";
            descriptionTb.Size = new Size(337, 84);
            descriptionTb.TabIndex = 4;
            descriptionTb.Text = "";
            // 
            // GroupControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Name = "GroupControl";
            Size = new Size(815, 103);
            Load += GroupControl_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label dateLbl;
        private Label nameLbl;
        private ListBox membersLb;
        private RichTextBox descriptionTb;
    }
}
