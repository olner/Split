using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI.Forms
{
    public partial class RegistrationForm : Form
    {
        private readonly SplitServiceApi client;
        private readonly ApplicationContext context;
        public RegistrationForm(ApplicationContext context, SplitServiceApi client)
        {
            InitializeComponent();
            this.context = context;
            this.client = client;
        }
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            warningLbl.Text = "";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            registartionBtn.BackColor = Color.FromArgb(24, 165, 130);
            registartionBtn.BackColor2 = Color.FromArgb(28, 172, 120);
            registartionBtn.ForeColor = Color.White;

            registartionBtn.ButtonHighlightColor = Color.FromArgb(31, 209, 165);
            registartionBtn.ButtonHighlightColor2 = Color.FromArgb(64, 227, 186);

            registartionBtn.ButtonPressedColor = Color.FromArgb(31, 209, 165);
            registartionBtn.ButtonPressedColor2 = Color.FromArgb(64, 227, 186);
        }

        private async void registartionBtn_Click(object sender, EventArgs e)
        {
            if (loginTb.Text.Length < 4 || passwordTb.Text.Length < 6 || emailTb.Text.Length < 6)
            {
                warningLbl.Text = "Логин должен быть не менее 4-х символоы\nПароль не менее 6 символов\nEmail не менее 6 символов";
                warningLbl.ForeColor = Color.Red;
                return;
            }

            try
            {
                User? user = await client.RegisterAsync(loginTb.Text, passwordTb.Text, emailTb.Text);

                if (user == null)
                {
                    MessageBox.Show("Такой пользователь уже есть");
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
        }
    }
}
