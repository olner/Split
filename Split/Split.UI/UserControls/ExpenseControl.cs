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
        public ExpenseControl()
        {
            InitializeComponent();
        }

        private void ExpenseControl_Load(object sender, EventArgs e)
        {
            dateLbl.AutoSize = true;
            dateLbl.Text = "Май\n 20";
            
        }
    }
}
