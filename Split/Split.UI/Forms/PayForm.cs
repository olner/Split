﻿using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI.Forms
{
    public partial class PayForm : Form
    {
        private readonly Expense expense;
        private readonly SplitServiceApi client;
        private DebtModel Debt { get; set; }

        public PayForm(Expense expense, SplitServiceApi client)
        {
            InitializeComponent();
            this.expense = expense;
            this.client = client;
            SetData();
        }

        private async void SetData()
        {
            var rawDebts = await client.GetExpenseDebtsAsync(expense.Id);
            var debts = rawDebts.Response;

            foreach (var debt in debts)
            {
                if (debt.UserId == Data.Id) Debt = debt;
            }

            var rawUser = await client.GetUserByIdAsync((int)expense.UserId);
            var user = rawUser.Response;
            if (user == null) return;

            label2.Text = $"Вы должны {user.Login} {Debt.Debt - Debt.Paid}₽ за {expense.Name}";
        }

        private async void payBtn_Click(object sender, EventArgs e)
        {
            if (sumTb.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле суммы");
                return;
            }

            var debt = Debt.Debt - Debt.Paid;

            if (double.Parse(sumTb.Text) > debt)
            {
                MessageBox.Show("Введенная сумма больше суммы долга");
                return;
            }

            await client.PayDebtAsync(Debt.Id, double.Parse(sumTb.Text));
            this.Close();
            //MessageBox.Show("Сумма занесена");
        }

        private void sumTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control || e.Alt || e.Shift || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left
        || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
                return;

            if (sumTb.Text == "" && e.KeyCode == Keys.Decimal)
                e.SuppressKeyPress = true;

            if (e.KeyCode != Keys.Decimal)
                if ((sumTb.Text == "" && e.KeyValue == 188) || (sumTb.Text == "" && e.KeyValue == 190) || !(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9
                  || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && e.KeyValue != 188 && e.KeyValue != 190)
                    e.SuppressKeyPress = true;

            char[] c = (sumTb.Text + e.KeyData).ToCharArray();
            for (int i = 0; i < c.Length; i++)
                if (c[i] == '.' || c[i] == ',')
                    if (e.KeyValue == 188 || e.KeyValue == 190 || e.KeyCode == Keys.Decimal || (sumTb.Text.Length - i) > 2)
                        e.SuppressKeyPress = true;
        }
    }
}
