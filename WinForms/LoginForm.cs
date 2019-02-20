using System;
using System.Windows.Forms;
using Library.Classes;
using Library.Mapping;

namespace WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var user = new UsersMapper().SelectToLogin(textBoxLogin.Text, textBoxPassword.Text);
            if (user == null)
            {
                labelError.Text = @"Chybné přihlášení";
            }
            else
            {
                Logged.CurrentUser = new UserInfo(user.Id, user.Type);
                Properties.Settings.Default.Save();
                Hide();
                var mainForm = new MainForm();
                mainForm.Show();
            }
        }
    }
}
