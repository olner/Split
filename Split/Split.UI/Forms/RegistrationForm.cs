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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            registartionBtn.BackColor = Color.FromArgb(24, 165, 130);
            registartionBtn.BackColor2 = Color.FromArgb(28, 172, 120);
            registartionBtn.ForeColor = Color.White;

            registartionBtn.ButtonHighlightColor = Color.FromArgb(31, 209, 165);
            registartionBtn.ButtonHighlightColor2 = Color.FromArgb(64, 227, 186);

            registartionBtn.ButtonPressedColor = Color.FromArgb(31, 209, 165);
            registartionBtn.ButtonPressedColor2 = Color.FromArgb(64, 227, 186);
        }

        private void registartionBtn_Click(object sender, EventArgs e)
        {
            //if (loginTb.Text.Length < 4 || passwordTb.Text.Length < 6 || emailTb.Text.Length < 6) return;
            var a = client.RegisterAsync(loginTb.Text, passwordTb.Text, emailTb.Text);

            if (a == null)
            {
                MessageBox.Show("Такой пользователь уже есть");
                return;
            }

            var form = new MainForm(client);
            context.MainForm = form;
            form.Show();
            //TODO: null exception
            this.Hide();
        }
    }
}
