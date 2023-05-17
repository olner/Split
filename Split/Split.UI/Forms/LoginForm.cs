using Split.UI.Tools.CustomControls;
using Split.WebClient;

namespace Split.UI
{
    public partial class LoginForm : Form
    {
        private readonly SplitServiceApi client;
        public LoginForm(SplitServiceApi client)
        {
            InitializeComponent();
            Build();
            //this.MinimumSize = new Size(427, 511);
            this.client = client;
        }
        private void Build()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            loginBtn.BackColor = Color.FromArgb(24, 165, 130);
            loginBtn.BackColor2 = Color.FromArgb(28, 172, 120);
            loginBtn.ForeColor = Color.White;

            loginBtn.ButtonHighlightColor = Color.FromArgb(31, 209, 165);
            loginBtn.ButtonHighlightColor2 = Color.FromArgb(64, 227, 186);

            loginBtn.ButtonPressedColor = Color.FromArgb(31, 209, 165);
            loginBtn.ButtonPressedColor2 = Color.FromArgb(64, 227, 186);

            //loginTb.MaximumSize = new Size(500, 500);
            //loginTb.Height = 300;
        }

    }
}