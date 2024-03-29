﻿using Split.UI.Tools;
using Split.WebClient;
using System.Text.RegularExpressions;

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

            loginTb.Text = "Логин";//подсказка
            loginTb.ForeColor = Color.Gray;

            passwordTb.Text = "Пароль";//подсказка
            passwordTb.ForeColor = Color.Gray;

            emailTb.Text = "Email";//подсказка
            emailTb.ForeColor = Color.Gray;


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
            var regex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";
            if (!Regex.IsMatch(emailTb.Text, regex))
            {
                warningLbl.Text = "Проверьте корректность email";
                warningLbl.ForeColor = Color.Red;
                return;
            }

            try
            {
                var result = await client.RegisterAsync(loginTb.Text, passwordTb.Text, emailTb.Text);
                var user = result.Response;

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

        private void loginTb_Enter(object sender, EventArgs e)
        {
            loginTb.Text = null;
            loginTb.ForeColor = Color.Black;
        }

        private void passwordTb_Enter(object sender, EventArgs e)
        {
            passwordTb.PasswordChar = '*';
            passwordTb.Text = null;
            passwordTb.ForeColor = Color.Black;

        }

        private void emailTb_Enter(object sender, EventArgs e)
        {
            emailTb.Text = null;
            emailTb.ForeColor = Color.Black;
        }
    }
}
