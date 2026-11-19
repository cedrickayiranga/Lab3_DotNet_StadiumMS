using System;
using System.Windows.Forms;
using StadiumMS.Helpers;

namespace StadiumMS.Views
{
    public partial class CustomerDashboardForm : Form
    {
        public CustomerDashboardForm()
        {
            InitializeComponent();
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            if (Session.CurrentUser != null)
                lblWelcome.Text = "Welcome, " + Session.CurrentUser.FullName + "!";
        }

        private void btnViewEvents_Click(object sender, EventArgs e)
        {
            Nav.Go(this, new CustomerViewEvents());
        }

        private void btnMyTickets_Click(object sender, EventArgs e)
        {
            Nav.Go(this, new CustomerMyTickets());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Nav.Go(this, new LoginForm());
        }
    }
}
