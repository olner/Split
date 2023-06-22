using Split.UI.Tools;
using Split.WebClient;
using System.Windows.Forms;

namespace Split.UI.UserControls
{
    public partial class DebtControl : UserControl
    {
        private readonly SplitServiceApi client;
        private readonly GroupMember member;

        private List<double> Debts { get; set; }
        private List<double> Debtors { get; set; }

        private string UserName { get; set; }
        private double Debt { get; set; }

        public DebtControl(SplitServiceApi client)
        {
            Debts = new List<double>();
            Debtors = new List<double>();
            InitializeComponent();
            this.client = client;
        }

        public DebtControl(SplitServiceApi client, GroupMember member, double debt) : this(client)
        {
            this.member = member;
            Debt = debt;
            SetMemberData();
            timer1.Start();

        }

        public DebtControl(SplitServiceApi client, GroupMember member, double debt, bool? kostil) : this(client)
        {
            this.member = member;
            Debt = debt;
            SetDebtorData();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckMemberData();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            CheckDebtorsData();
        }

        private async void CheckMemberData()
        {
            var rawDebts = await client.GetUserGroupCustomDebtsAsync(member.GroupId, member.UserId, Data.Id);
            var debts = rawDebts.Response;

            if(debts == null)
            {
                timer1.Stop();
                return;
            }
            if(debts.Count != Debts.Count)
            {
                timer1.Stop();
                return;
            }

            var i = 0;
            foreach (var debt in debts)
            {
                if ((debt.Debt - debt.Paid) != Debts[i])
                {
                    listBox1.Items.Clear();
                    SetMemberData();
                    return;
                }
                i++;
            }
        }

        private async void CheckDebtorsData()
        {
            var rawDebts = await client.GetUserGroupCustomDebtsAsync(member.GroupId, Data.Id, member.UserId);
            var debts = rawDebts.Response;

            if(debts == null)
            {
                timer2.Stop();
                return;
            }

            if (debts.Count != Debtors.Count)
            {
                timer2.Stop();
                return;
            }

            var i = 0;
            foreach (var debt in debts)
            {
                if ((debt.Debt - debt.Paid) != Debtors[i])
                {
                    listBox1.Items.Clear();
                    SetDebtorData();
                    return;
                }

                i++;
            }
        }
        private void DebtControl_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.noImage;
        }
        private async void SetMemberData()
        {
            double sum = 0;
            Debts.Clear();

            var result = await client.GetUserByIdAsync((int)member.UserId);
            var user = result.Response;
            UserName = user.Login;
            

            var rawDebts = await client.GetUserGroupCustomDebtsAsync(member.GroupId, member.UserId, Data.Id);
            var debts = rawDebts.Response;

            foreach (var debt in debts)
            {
                var rawExpense = await client.GetExpenseAsync(debt.ExpenseId);
                var expense = rawExpense.Response;
                listBox1.Items.Add($"{expense.Name}: {debt.Debt - debt.Paid} рублей");

                Debts.Add((double)(debt.Debt - debt.Paid));

                sum += (double)(debt.Debt - debt.Paid);
            }
            nameLbl.Text = $"Вы должны {UserName}: {sum}";
        }

        //Для должников
        private async void SetDebtorData()
        {
            double sum = 0;
            Debtors.Clear();

            var result = await client.GetUserByIdAsync((int)member.UserId);
            var user = result.Response;
            UserName = user.Login;
            

            var rawDebts = await client.GetUserGroupCustomDebtsAsync(member.GroupId, Data.Id, member.UserId);
            var debts = rawDebts.Response;

            foreach (var debt in debts)
            {
                var rawExpense = await client.GetExpenseAsync(debt.ExpenseId);
                var expense = rawExpense.Response;
                listBox1.Items.Add($"{expense.Name}: {debt.Debt - debt.Paid} рублей");

                Debtors.Add((double)(debt.Debt - debt.Paid));

                sum += (double)(debt.Debt - debt.Paid);
            }
            nameLbl.Text = $"{UserName} вам должен: {sum}";
        }
    }
}
