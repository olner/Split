using Split.WebClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            /*dateLbl.AutoSize = true;
            dateLbl.Text = "Май\n 20";*/
        }

        private void SetData()
        {
            dateLbl.Text = expense.Date.Value.Date.ToShortDateString();
            nameLbl.Text = expense.Name;
            priceLbl.Text = "₽" + expense.Sum.ToString();
            label1.Text = "Ты ничего не должен";
        }
    }
}
