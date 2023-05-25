using Split.UI.UserControls;
using Split.WebClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;

namespace Split.UI.Forms
{
    public partial class AddExpenseForm : Form
    {
        private readonly SplitServiceApi client;
        private readonly Guid groupId;

        public AddExpenseForm(SplitServiceApi client, Guid groupId)
        {
            InitializeComponent();
            this.client = client;
            this.groupId = groupId;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddExpenseForm_Load(object sender, EventArgs e)
        {
            SetPages();
            UpdateDebts();
            //Ибо нехуй
            sumTb.ShortcutsEnabled = false;
        }

        private async void SetPages()
        {
            var rawMembers = await client.GetGroupMembersAsync(groupId);
            var members = rawMembers.Response;

            var counter = 0;
            foreach (var member in members)
            {
                var rawName = await client.GetUserByIdAsync((int)member.UserId);
                var name = rawName.Response;

                checkedListBox1.Items.Add(name.Login);

                var amountControl = new SumControl(name.Login)
                {
                    //Name = $"amountControl{counter}",
                    Width = percentTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                amountTlp.Controls.Add(amountControl);

                var percentControl = new SumControl(name.Login)
                {
                    //Name = $"percentControl{counter}",
                    Width = percentTlp.Width,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
                };
                percentTlp.Controls.Add(percentControl);

                counter++;
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
        }

        private void UpdatePercentControls()
        {
            if (sumTb.Text.Length == 0) return;

            var sum = double.Parse(sumTb.Text);

            var controls = new List<SumControl>();
            foreach (SumControl control in percentTlp.Controls)
            {
                if (control.CheckBox == true)
                {
                    controls.Add(control);
                }
            }

            double percentCounter = 0;
            foreach (var control in controls)
            {
                if (control.Sum == 0) break;
                var debt = (sum / 100) * control.Sum;
                control.Name = $"{control.UserName} должен: {debt}";
                percentCounter += control.Sum;
            }
            percentLbl.Text = $"Процентов осталось: {100 - percentCounter}";
        }

        private void UpdateAmountControls()
        {
            if (sumTb.Text.Length == 0) return;

            var sum = double.Parse(sumTb.Text);

            var controls = new List<SumControl>();
            foreach (SumControl control in amountTlp.Controls)
            {
                if (control.CheckBox == true)
                {
                    controls.Add(control);
                }
            }

            double amountCounter = 0;
            foreach (var control in controls)
            {
                if (control.Sum == 0) break;
                control.Name = $"{control.UserName} должен: {control.Sum}";
                amountCounter += control.Sum;
            }

            percentLbl.Text = $"Осталось: {sum - amountCounter}";
        }

        private void UpdateDebts()
        {
            if (sumTb.Text.Length == 0)
            {
                equalLbl.Text = $"Каждый должен: 0";
                return;
            }
            if (checkedListBox1.CheckedItems.Count == 0) return;
            var sum = decimal.Parse(sumTb.Text);
            var debt = (sum / checkedListBox1.CheckedItems.Count);

            amountLbl.Text = $"Каждый должен: {debt}";
        }

        private void sumTb_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!
        //TODO: Сжеть в огне и сделать проверку потому что на ctrl+v не реагирует
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

        private void sumTb_TextChanged(object sender, EventArgs e)
        {
            UpdateDebts();
            UpdatePercentControls();
            UpdateAmountControls();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDebts();
        }
    }
}
