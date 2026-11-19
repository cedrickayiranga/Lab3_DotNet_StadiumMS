using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Views
{
    public partial class CustomerMyTickets : Form
    {
        public CustomerMyTickets()
        {
            InitializeComponent();
        }

        private void CustomerMyTickets_Load(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null) return;

            try
            {
                List<Ticket> tickets = TicketController.GetByUser(Session.CurrentUser.Id);
                grid.Rows.Clear();
                foreach (Ticket t in tickets)
                {
                    grid.Rows.Add(
                        t.Id,
                        t.EventTitle,
                        t.SeatNumber,
                        t.Price.ToString("N2"),
                        t.PaymentMethod,
                        t.Status,
                        t.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
                }
                grid.ClearSelection();
            }
            catch (Exception ex)
            {
                Msg.Error("Error loading tickets: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Nav.Go(this, new CustomerDashboardForm());
        }
    }
}
