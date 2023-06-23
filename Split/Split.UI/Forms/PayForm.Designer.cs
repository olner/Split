namespace Split.UI.Forms
{
    partial class PayForm
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
            label1 = new Label();
            sumTb = new TextBox();
            payBtn = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 58);
            label1.Name = "label1";
            label1.Size = new Size(62, 23);
            label1.TabIndex = 0;
            label1.Text = "Сумма";
            // 
            // sumTb
            // 
            sumTb.Location = new Point(14, 84);
            sumTb.Name = "sumTb";
            sumTb.Size = new Size(264, 27);
            sumTb.TabIndex = 1;
            sumTb.KeyDown += sumTb_KeyDown;
            // 
            // payBtn
            // 
            payBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            payBtn.Location = new Point(300, 70);
            payBtn.Name = "payBtn";
            payBtn.Size = new Size(123, 55);
            payBtn.TabIndex = 2;
            payBtn.Text = "Оплатить";
            payBtn.UseVisualStyleBackColor = true;
            payBtn.Click += payBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(14, 9);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 3;
            label2.Text = "Вы должны";
            // 
            // PayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 137);
            Controls.Add(label2);
            Controls.Add(payBtn);
            Controls.Add(sumTb);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "PayForm";
            Text = "Учет оплаты";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox sumTb;
        private Button payBtn;
        private Label label2;
    }
}