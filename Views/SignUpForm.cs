using System;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Views
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (fullName.Length == 0)
            {
                Msg.Error("Full name is required!", "Validation Error");
                return;
            }
            if (email.Length == 0)
            {
                Msg.Error("Email is required!", "Validation Error");
                return;
            }
            if (!Validator.IsValidEmail(email))
            {
                Msg.Error("Invalid email format!", "Validation Error");
                return;
            }
            if (password.Length == 0)
            {
                Msg.Error("Password is required!", "Validation Error");
                return;
            }

            try
            {
                if (UserController.FindByEmail(email) != null)
                {
                    Msg.Error("Email already registered!", "Sign Up Failed");
                    return;
                }

                User created = UserController.Register(fullName, email, password, false);
                if (created == null)
                {
                    Msg.Error("Registration failed!");
                    return;
                }

                Msg.Info("Account created successfully. Please login.");
                Nav.Go(this, new LoginForm());
            }
            catch (Exception ex)
            {
                Msg.Error("Database error: " + ex.Message);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Nav.Go(this, new LoginForm());
        }
    }
}
