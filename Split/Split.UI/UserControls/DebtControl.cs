using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI.UserControls
{
    public partial class DebtControl : UserControl
    {
        private readonly SplitServiceApi client;
        private readonly GroupMember member;

        private string UserName { get; set; }
        private double Debt { get; set; }

        public DebtControl(SplitServiceApi client)
        {
            InitializeComponent();
            this.client = client;
        }

        public DebtControl(SplitServiceApi client, GroupMember member, double debt) : this(client)
        {
            this.member = member;
            Debt = debt;
            SetMemberData();
        }

        public DebtControl(SplitServiceApi client, GroupMember member, double debt, bool? kostil) : this(client)
        {
            this.member = member;
            Debt = debt;
            SetDebtorData();
        }

        private void DebtControl_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.noImage;
        }
        private async void SetMemberData()
        {
            var result = await client.GetUserByIdAsync((int)member.UserId);
            var user = result.Response;
            UserName = user.Login;
            nameLbl.Text = $"Вы должны {UserName}: {Debt}";

            var rawDebts = await client.GetUserGroupCustomDebtsAsync(member.GroupId, member.UserId, Data.Id);
            var debts = rawDebts.Response;

            foreach (var debt in debts)
            {
                var rawExpense = await client.GetExpenseAsync(debt.ExpenseId);
                var expense = rawExpense.Response;
                listBox1.Items.Add($"{expense.Name}: {debt.Debt - debt.Paid} рублей");
            }
        }

        //Для должников
        private async void SetDebtorData()
        {
            var result = await client.GetUserByIdAsync((int)member.UserId);
            var user = result.Response;
            UserName = user.Login;
            nameLbl.Text = $"{UserName} вам должен: {Debt}";

            var rawDebts = await client.GetUserGroupCustomDebtsAsync(member.GroupId, Data.Id, member.UserId);
            var debts = rawDebts.Response;

            foreach (var debt in debts)
            {
                var rawExpense = await client.GetExpenseAsync(debt.ExpenseId);
                var expense = rawExpense.Response;
                listBox1.Items.Add($"{expense.Name}: {debt.Debt - debt.Paid} рублей");
            }
        }
    }
}
