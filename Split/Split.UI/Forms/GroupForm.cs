using Split.UI.Tools;
using Split.UI.UserControls;
using Split.WebClient;
using System.Xml.Serialization;

namespace Split.UI.Forms
{
    public partial class GroupForm : Form
    {
        private readonly SplitServiceApi client;
        private readonly Guid groupId;
        private string GroupName { get; set; }
        private string Description { get; set; }
        private int Expenses { get; set; }
        private int Members { get; set; }

        private int Debts { get; set; }

        public GroupForm(SplitServiceApi client, Guid groupId)
        {
            InitializeComponent();
            this.client = client;
            this.groupId = groupId;
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            SetData();
            updateTimer.Start();

            addExpenseBtn.BackColor = Color.FromArgb(91, 197, 167);
            addExpenseBtn.ForeColor = Color.White;
            addExpenseBtn.FlatStyle = FlatStyle.Flat;
            addExpenseBtn.FlatAppearance.BorderSize = 0;
        }

        public void SetData()
        {
            tableLayoutPanel1.Controls.Add(groupNameLbl);
            tableLayoutPanel1.Controls.Add(label1);
            tableLayoutPanel1.Controls.Add(addExpenseBtn);
            SetDebt();
            SetGroup();
            SetExpenses();
            SetMembers();
            SetDebts();
        }
        private async void SetDebt()
        {
            var rawDebts = await client.GetUserGroupDebtsAsync(groupId, Data.Id);
            var debts = rawDebts.Response;

            if (debts == null)
            {
                label1.Text = $"Вы ничего не должны";
                return;
            }

            double total = 0;
            foreach (var debt in debts)
            {
                total += (double)debt.Debt - (double)debt.Paid;
            }
            label1.Text = $"Вы всего должны {total}₽";
        }
        private async void SetGroup()
        {
            var result = await client.GetGroupAsync(groupId);
            var group = result.Response;

            GroupName = group.Name;
            groupNameLbl.Text = GroupName;
            nameTb.Text = GroupName;
            this.Text = GroupName + " - группы";
        }
        private async void SetExpenses()
        {

            var rawResult = await client.GetGroupExpensesAsync(groupId);
            var expenses = rawResult.Response;
            if (expenses == null) return;

            var i = 0;
            foreach (var item in expenses)
            {
                var control = new ExpenseControl(client, item)
                {
                    Name = $"expensseControl{i}",
                    Width = expenseTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                expenseTlp.Controls.Add(control);
                i++;
            }

            Expenses = i;
        }

        private async void SetMembers()
        {
            var addMember = new FriendControl(client, groupId)
            {
                Width = expenseTlp.Width,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            addMember.NewMember();
            membersTlp.Controls.Add(addMember);

            var rawMembers = await client.GetGroupMembersAsync(groupId);
            var members = rawMembers.Response;
            if (members == null) return;

            var i = 0;
            foreach (var item in members)
            {
                var control = new FriendControl(client, item)
                {
                    Name = $"friednControl{i}",
                    Width = membersTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                membersTlp.Controls.Add(control);
                i++;
            }

            Members = i;
        }

        private async void SetDebts()
        {
            var rawMembers = await client.GetGroupMembersAsync(groupId);
            var members = rawMembers.Response;
            if (members == null) return;

            var i = 0;
            foreach (var member in members)
            {
                if (member.UserId != Data.Id)
                {

                    double sum = 0;
                    var rawDebts = await client.GetUserGroupCustomDebtsAsync(groupId, member.UserId, Data.Id);
                    var debts = rawDebts.Response;
                    if (debts != null)
                    {
                        //if (debts.Count == 0) break;

                        foreach (var debt in debts)
                        {
                            sum += (double)debt.Debt - (double)debt.Paid;
                        }

                        var control = new DebtControl(client, member, sum)
                        {
                            Name = $"debtControl{i}",
                            Width = debtTlp.Width,
                            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                        };
                        debtTlp.Controls.Add(control);
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g;
            string sText;
            int iX;
            float iY;

            SizeF sizeText;
            TabControl ctlTab;

            ctlTab = (TabControl)sender;

            g = e.Graphics;

            sText = ctlTab.TabPages[e.Index].Text;
            sizeText = g.MeasureString(sText, ctlTab.Font);
            iX = e.Bounds.Left + 6;
            iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;
            g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = GroupName + " - " + tabControl1.SelectedTab.Text;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            nameTb.Text = GroupName;
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            var result = await client.UpdateNameAsync(groupId, nameTb.Text);
            var group = result.Response;
            GroupName = group.Name;
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            await client.DeleteGroupAsync(groupId);
        }

        private async void updateTimer_Tick(object sender, EventArgs e)
        {
            CheckExpenses();
            CheckMembers();
            CheckGroup();
        }
        private async void CheckExpenses()
        {
            var rawExpenses = await client.GetGroupExpensesAsync(groupId);
            var expenses = rawExpenses.Response;
            if (expenses == null) return;

            if (expenses.Count != Expenses)
            {
                //expenseTlp.Controls.Clear();
                ClearExpense();
                SetExpenses();
                SetDebt();

                debtTlp.Controls.Clear();
                SetDebts();
            }
        }
        private void ClearExpense()
        {
            var additions = new ControlsAdditions();

            var controls = additions.GetAll(expenseTlp, typeof(ExpenseControl)).ToList();

            for (int i = 0; i < controls.Count; i++)
            {
                expenseTlp.Controls.Remove(controls[i]);
            }
        }

        private async void CheckMembers()
        {
            var rawMembers = await client.GetGroupMembersAsync(groupId);
            var members = rawMembers.Response;
            if (members == null) return;

            if (members.Count != Members)
            {
                membersTlp.Controls.Clear();
                SetMembers();
            }
        }
        private async void CheckGroup()
        {
            var rawGroup = await client.GetGroupAsync(groupId);
            var group = rawGroup.Response;

            if (group == null)
            {
                updateTimer.Stop();

                MessageBox.Show(
                    $"Группа была удалена администратором",
                    "Группа удалена",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.Dispose();
            }
        }

        private void addExpenseBtn_Click(object sender, EventArgs e)
        {
            new AddExpenseForm(client, groupId).ShowDialog(this);
        }
    }
}
