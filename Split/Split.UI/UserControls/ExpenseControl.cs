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

            if (debt == null || debts == null || expense.UserId == Data.Id)
            {
                label1.Text = "Вы ничего не должны";
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

            if(Debt == 0) deleteBtn.Enabled = false;

            deleteBtn.Click -= deleteBtn_Click;
            deleteBtn.Click += payBtn_Click;
        }

        private void payBtn_Click(object sender, EventArgs e)
        {
            new PayForm(expense).ShowDialog();
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

            foreach (var debt in debts)
            {
                await client.DeleteDebtAsync(debt.Id);
            }

            await client.DeleteExpenseAsync(expense.Id);

            this.Dispose();
        }
    }
}
