using System;

namespace Split.UI.UserControls
{
    public partial class SumControl : UserControl
    {
        public bool Validated { get; set; }
        public string UserName { get; set; }
        public string Name { get => nameLbl.Text; set => nameLbl.Text = value; }
        public bool CheckBox { get => checkBox1.Checked; set => checkBox1.Checked = value; }
        public double Sum
        {
            get
            {
                if (textBox1.Text.Length == 0) return 0;
                return double.Parse(textBox1.Text);
            }
            set => textBox1.Text = value.ToString();
        }
        public SumControl(string name)
        {
            InitializeComponent();
            Name = name;
            UserName = name;
        }
        public string GetName() => Name;
        public void SetName(string name) => Name = name;
        public bool GetCheckBox() => CheckBox;
        public void SetCheckBox(bool value) => CheckBox = value;
        public double GetSum() => Sum;
        public void SetSum(double value) => Sum = value;

        private void SumControl1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Validated = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Validated = false;
        }

        //!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!WARNING!
        //TODO: ХАХАХАХАХ Я ЭТО ВТОРОЙ РАЗ ИСПОЛЬЗУЮ
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control || e.Alt || e.Shift || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left
        || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
                return;

            if (textBox1.Text == "" && e.KeyCode == Keys.Decimal)
                e.SuppressKeyPress = true;

            if (e.KeyCode != Keys.Decimal)
                if ((textBox1.Text == "" && e.KeyValue == 188) || (textBox1.Text == "" && e.KeyValue == 190) || !(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9
                  || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && e.KeyValue != 188 && e.KeyValue != 190)
                    e.SuppressKeyPress = true;

            char[] c = (textBox1.Text + e.KeyData).ToCharArray();
            for (int i = 0; i < c.Length; i++)
                if (c[i] == '.' || c[i] == ',')
                    if (e.KeyValue == 188 || e.KeyValue == 190 || e.KeyCode == Keys.Decimal || (textBox1.Text.Length - i) > 2)
                        e.SuppressKeyPress = true;
        }
    }
}
