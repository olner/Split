using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI.UserControls
{
    public partial class ExpenseControl : UserControl
    {
        private readonly SplitServiceApi client;
        private readonly Expense expense;

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
        }

        private void ExpenseControl_Load(object sender, EventArgs e)
        {

        }

        private async void SetData()
        {
            dateLbl.Text = expense.Date.Value.Date.ToShortDateString();
            nameLbl.Text = expense.Name;
            priceLbl.Text = "₽" + expense.Sum.ToString();

            var rawDebts = await client.GetUserDebtsAsync(Data.Id);
            var debts = rawDebts.Response;
            if (debts == null) return;

            var debt = debts.Where(x => x.ExpenseId == expense.Id).FirstOrDefault();

            if (debt == null || debts == null)
            {
                label1.Text = "Вы ничего не должны";
                return;
            }
            var rawUser = await client.GetUserByIdAsync((int)expense.UserId);
            var user = rawUser.Response;
            if (user == null) return;   

            label1.Text = $"Вы должны {user.Login} {debt.Debt - debt.Paid}₽";
        }

        public void RemoveDeleteBtn()
        {
            tableLayoutPanel1.Controls.Remove(deleteBtn);
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var rawDebts = await client.GetExpenseDebtsAsync(expense.Id);
            var debts = rawDebts.Response;

            foreach(var debt in debts)
            {
                await client.DeleteDebtAsync(debt.Id);
            }

            await client.DeleteExpenseAsync(expense.Id);

            this.Dispose();
        }
    }
}
