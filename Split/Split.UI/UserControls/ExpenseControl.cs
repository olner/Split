using Split.UI.Forms;
using Split.UI.Tools;
using Split.WebClient;
using System.Drawing.Text;

namespace Split.UI.UserControls
{
    public partial class ExpenseControl : UserControl
    {
        private readonly SplitServiceApi client;
        private readonly Expense expense;

        private double Debt { get; set; }

        public ExpenseControl()
        {
            InitializeComponent();
        }

        public ExpenseControl(SplitServiceApi client, Expense expense)
        {
            InitializeComponent();
            this.client = client;
            this.expense = expense;
            SetData();
            updateTimer.Start();
        }

        private void ExpenseControl_Load(object sender, EventArgs e)
        {

        }

        private async void SetData()
        {
            var date = expense.Date.Value.Date.ToString("M");
            dateLbl.Text = MyExtensions.SetDataFormat(date);
            nameLbl.Text = expense.Name;
            priceLbl.Text = "₽" + expense.Sum.ToString();

            var rawDebts = await client.GetUserDebtsAsync(Data.Id);
            var debts = rawDebts.Response;
            if (debts == null) return;

            var debt = debts.Where(x => x.ExpenseId == expense.Id).FirstOrDefault();

            if (debt == null || debts == null || expense.UserId == Data.Id || debt.Debt == debt.Paid)
            {
                label1.Text = "Вы ничего не должны";
                Debt = 0;
                if (expense.UserId != Data.Id) SetNotCeratorData();
                return;
            }
            var rawUser = await client.GetUserByIdAsync((int)expense.UserId);
            var user = rawUser.Response;
            if (user == null) return;

            label1.Text = $"Вы должны {user.Login} {debt.Debt - debt.Paid}₽";

            Debt = (double)(debt.Debt - debt.Paid);

            if (expense.UserId != Data.Id) SetNotCeratorData();
        }

        private void SetNotCeratorData()
        {

            deleteBtn.Text = "Оплата";
            deleteBtn.Name = $"{expense.Id}";

            //disabled btn fix
            deleteBtn.Enabled = true;
            if (Debt == 0) deleteBtn.Enabled = false;

            //TODO: Бесконечное добавление click, сделать нормальный фикс
            deleteBtn.Click -= deleteBtn_Click;
            deleteBtn.Click -= payBtn_Click;
            deleteBtn.Click += payBtn_Click;
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            new PayForm(expense, client).ShowDialog();
        }

        public void RemoveDeleteBtn()
        {
            tableLayoutPanel1.Controls.Remove(deleteBtn);
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var rawDebts = await client.GetExpenseDebtsAsync(expense.Id);
            var debts = rawDebts.Response;
            if (debts == null) return;

            var unpaid = false;
            foreach (var debt in debts)
            {
                if ((debt.Debt - debt.Paid) > 0 && debt.UserId != Data.Id) unpaid = true;
            }

            if (unpaid)
            {
                var result = MessageBox.Show("По этой покупке остались неоплаченные долги. Вы точно хотите удалить эту покупку?",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    foreach (var debt in debts)
                    {
                        await client.DeleteDebtAsync(debt.Id);
                    }

                    await client.DeleteExpenseAsync(expense.Id);

                    //this.Dispose();
                    return;
                }
            }
            else
            {
                var result = MessageBox.Show("Вы точно хотите удалить эту покупку?",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    foreach (var debt in debts)
                    {
                        await client.DeleteDebtAsync(debt.Id);
                    }

                    await client.DeleteExpenseAsync(expense.Id);

                    //this.Dispose();
                    return;
                }
            }

        }
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            CheckDebt();
        }

        private async void CheckDebt()
        {
            double tmpDebt;

            var rawDebts = await client.GetUserDebtsAsync(Data.Id);
            var debts = rawDebts.Response;
            if (debts == null) return;

            var debt = debts.Where(x => x.ExpenseId == expense.Id).FirstOrDefault();

            if (debt == null || debts == null || expense.UserId == Data.Id || debt.Debt == debt.Paid)
            {
                tmpDebt = 0;
            }
            else
            {
                tmpDebt = (double)(debt.Debt - debt.Paid);
            }
            
            if(Debt != tmpDebt)
            {
                SetData();
            }
        }
    }
}
