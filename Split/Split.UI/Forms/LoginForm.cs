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

            loginTb.Text = "Логни";//подсказка
            loginTb.ForeColor = Color.Gray;
            passwordTb.Text = "Пароль";//подсказка
            passwordTb.ForeColor = Color.Gray;

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
            passwordTb.PasswordChar = '*';

            loginBtn.Enabled = false;
            if (loginBtn.Text.Length < 3 || passwordTb.Text.Length < 5)
            {
                errorGB.Visible = true;
                errorLbl.Text = "Логин должен быть не менее 3-х символов\nпароль не менее 5";
                errorLbl.ForeColor = Color.Red;

                loginBtn.Enabled = true;
                return;
            }

            try
            {
                var result = await client.AuthorizeAsync(loginTb.Text, passwordTb.Text);
                var user = result.Response;
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден.\nПроверьте правильность написания логина и пароля");

                    loginBtn.Enabled = true;
                    return;
                }

                Data.Id = (int)user.Id;

                var form = new MainForm(client);

                context.MainForm = form;
                form.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                loginBtn.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new RegistrationForm(context, client);
            context.MainForm = form;
            form.Show();
            this.Hide();
        }

        private void loginTb_Enter(object sender, EventArgs e)
        {
            loginTb.Text = null;
            loginTb.ForeColor = Color.Black;
        }

        private void passwordTb_Enter(object sender, EventArgs e)
        {
            passwordTb.Text = null;
            passwordTb.ForeColor = Color.Black;
        }
    }
}