using System;

namespace Split.UI.UserControls
{
    public partial class SumControl : UserControl
    {
        public string UserName { get; set; }
        public string Name { get => nameLbl.Text; set => nameLbl.Text = value; }
        public bool CheckBox { get => checkBox1.Checked; set => checkBox1.Checked = value; }
        public double Sum { get => double.Parse(textBox1.Text); set => textBox1.Text = value.ToString(); }
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
    }
}
