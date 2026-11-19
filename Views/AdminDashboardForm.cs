using System;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;

namespace StadiumMS.Views
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblEventsValue.Text = EventController.CountAll().ToString();
                lblTicketsValue.Text = TicketController.CountSold().ToString();
                lblRevenueValue.Text = TicketController.TotalRevenue().ToString("N0");
            }
            catch (Exception ex)
            {
                Msg.Error("Error loading stats: " + ex.Message);
            }
        }

        private void btnManageEvents_Click(object sender, EventArgs e)
        {
            Nav.Go(this, new EventForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Nav.Go(this, new LoginForm());
        }
    }
}
