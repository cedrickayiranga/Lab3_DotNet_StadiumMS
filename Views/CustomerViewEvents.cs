using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Views
{
    public partial class CustomerViewEvents : Form
    {
        public CustomerViewEvents()
        {
            InitializeComponent();
        }

        private void CustomerViewEvents_Load(object sender, EventArgs e)
        {
            LoadEvents(null);
        }

        private void LoadEvents(string keyword)
        {
            try
            {
                bool searching = !string.IsNullOrEmpty(keyword);
                List<Event> events = searching ? EventController.Search(keyword) : EventController.GetAll();

                grid.Rows.Clear();
                foreach (Event ev in events)
                {
                    int row = grid.Rows.Add(
                        ev.Id,
                        ev.Title,
                        ev.Description,
                        ev.StartDatetime.ToString("dd/MM/yyyy HH:mm"),
                        ev.Price.ToString("N2") + " RWF",
                        ev.AvailableSeats + "/" + ev.MaxTickets);
                    grid.Rows[row].Tag = ev;
                }
                grid.ClearSelection();

                if (searching && events.Count == 0)
                    Msg.Info("No events found matching '" + keyword + "'", "No Results");
            }
            catch (Exception ex)
            {
                Msg.Error("Error loading events: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEvents(txtSearch.Text.Trim());
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 0)
            {
                Msg.Warn("Please select an event from the table first!", "No Selection");
                return;
            }

            Event ev = grid.SelectedRows[0].Tag as Event;
            if (ev == null) return;

            if (ev.AvailableSeats == 0)
            {
                Msg.Info("No seats are currently available for this event.", "Sold Out");
                return;
            }

            Nav.Go(this, new CustomerBuyTicket(ev));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Nav.Go(this, new CustomerDashboardForm());
        }
    }
}
