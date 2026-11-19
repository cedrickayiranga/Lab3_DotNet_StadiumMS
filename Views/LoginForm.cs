using System;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (email.Length == 0)
            {
                Msg.Error("Email is required!", "Validation Error");
                return;
            }
            if (password.Length == 0)
            {
                Msg.Error("Password is required!", "Validation Error");
                return;
            }
            if (!Validator.IsValidEmail(email))
            {
                Msg.Error("Invalid email format!", "Validation Error");
                return;
            }

            try
            {
                User user = UserController.FindByEmail(email);
                if (user == null)
                {
                    Msg.Error("User not found!", "Login Failed");
                    return;
                }
                if (!PasswordHasher.Verify(password, user.PasswordHash))
                {
                    Msg.Error("Incorrect password!", "Login Failed");
                    return;
                }

                Session.CurrentUser = user;

                if (user.IsAdmin)
                    Nav.Go(this, new AdminDashboardForm());
                else
                    Nav.Go(this, new CustomerDashboardForm());
            }
            catch (Exception ex)
            {
                Msg.Error("Database error: " + ex.Message);
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Nav.Go(this, new SignUpForm());
        }
    }
}
