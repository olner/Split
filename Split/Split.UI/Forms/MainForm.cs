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

namespace Split.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SplitServiceApi client;

        public MainForm(SplitServiceApi client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
