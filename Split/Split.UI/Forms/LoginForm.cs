using Split.UI.Forms;
using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI
{
    public partial class LoginForm : Form
    {
        private readonly SplitServiceApi client;
        private readonly ApplicationContext context;

        public LoginForm(SplitServiceApi client, ApplicationContext context)
        {
            InitializeComponent();
            //this.MinimumSize = new Size(427, 511);
            this.client = client;
            this.context = context;
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            Build();
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
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            loginTb.Text = "admin";
            passwordTb.Text = "admin";

            loginBtn.Enabled = false;
            if (loginBtn.Text.Length < 3 || passwordTb.Text.Length < 5)
            {
                errorGB.Visible = true;
                errorLbl.Text = "����� ������ ���� �� ����� 3-� ��������\n������ �� ����� 5";
                errorLbl.ForeColor = Color.Red;

                loginBtn.Enabled = true;
                return;
            }

            var user = await client.AuthorizeAsync(loginTb.Text, passwordTb.Text);
            if (user == null)
            {
                MessageBox.Show("������������ �� ������.\n��������� ������������ ��������� ������ � ������");

                loginBtn.Enabled = true;
                return;
            }

            Data.Id = (int)user.Id;
            var form = new MainForm(client);
            context.MainForm = form;
            form.Show();
            //TODO: null exception
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new RegistrationForm(context, client);
            context.MainForm = form;
            form.Show();
            this.Hide();
        }
    }
}