using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Views
{
    public partial class EventForm : Form
    {
        private int _selectedEventId = -1;

        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            ClearFields();
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
                        ev.EndDatetime.ToString("dd/MM/yyyy HH:mm"),
                        ev.MaxTickets,
                        ev.Price.ToString("N2"));
                    grid.Rows[row].Tag = ev;
                }
                grid.ClearSelection();

                if (searching && events.Count == 0)
                    Msg.Info("No events found matching '" + keyword + "'");
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

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Event ev = grid.Rows[e.RowIndex].Tag as Event;
            if (ev == null) return;

            _selectedEventId = ev.Id;
            txtTitle.Text = ev.Title;
            txtDescription.Text = ev.Description;
            dtpStart.Value = ev.StartDatetime;
            dtpEnd.Value = ev.EndDatetime;
            txtMaxTickets.Text = ev.MaxTickets.ToString();
            txtPrice.Text = ev.Price.ToString("0.##");
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Event ev;
            decimal price;
            if (!ReadInput(out ev, out price)) return;

            try
            {
                EventController.Add(ev, price);
                Msg.Info("Event created successfully.");
                ClearFields();
                LoadEvents(null);
            }
            catch (Exception ex)
            {
                Msg.Error("Failed to create event: " + ex.Message);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == -1)
            {
                Msg.Warn("Select an event first!");
                return;
            }

            Event ev;
            decimal price;
            if (!ReadInput(out ev, out price)) return;
            ev.Id = _selectedEventId;

            try
            {
                string error;
                if (EventController.Update(ev, price, out error))
                {
                    Msg.Info("Event updated successfully!");
                    ClearFields();
                    LoadEvents(null);
                }
                else
                {
                    Msg.Error(error, "Update failed");
                }
            }
            catch (Exception ex)
            {
                Msg.Error("Update failed: " + ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == -1)
            {
                Msg.Warn("Select an event first!");
                return;
            }
            if (!Msg.Confirm("Delete this event?")) return;

            try
            {
                string error;
                if (EventController.Delete(_selectedEventId, out error))
                {
                    Msg.Info("Event deleted!");
                    ClearFields();
                    LoadEvents(null);
                }
                else
                {
                    Msg.Error(error, "Delete failed");
                }
            }
            catch (Exception ex)
            {
                Msg.Error("Delete failed: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Nav.Go(this, new AdminDashboardForm());
        }


        private void ClearFields()
        {
            _selectedEventId = -1;
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtMaxTickets.Text = "";
            txtPrice.Text = "";

            DateTime tomorrow = DateTime.Now.AddDays(1);
            dtpStart.Value = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 18, 0, 0);
            dtpEnd.Value = dtpStart.Value.AddHours(3);
            grid.ClearSelection();
        }

        private bool ReadInput(out Event ev, out decimal price)
        {
            ev = null;
            price = 0m;

            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string maxText = txtMaxTickets.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (title.Length == 0 || description.Length == 0 || maxText.Length == 0 || priceText.Length == 0)
            {
                Msg.Error("All fields are required!", "Validation Error");
                return false;
            }

            int maxTickets;
            if (!int.TryParse(maxText, out maxTickets) || maxTickets <= 0)
            {
                Msg.Error("Max tickets must be a whole number greater than 0!", "Validation Error");
                return false;
            }
            if (maxTickets > 100000)
            {
                Msg.Error("Max tickets is too large (maximum 100000).", "Validation Error");
                return false;
            }
            if (!decimal.TryParse(priceText, out price) || price <= 0)
            {
                Msg.Error("Ticket price must be a number greater than 0!", "Validation Error");
                return false;
            }
            if (title.Length > 100)
            {
                Msg.Error("Title is too long (max 100 characters).", "Validation Error");
                return false;
            }
            if (description.Length > 1000)
            {
                Msg.Error("Description is too long (max 1000 characters).", "Validation Error");
                return false;
            }

            DateTime start = WithoutSeconds(dtpStart.Value);
            DateTime end = WithoutSeconds(dtpEnd.Value);
            if (start <= DateTime.Now)
            {
                Msg.Error("Start time must be in the future.", "Validation Error");
                return false;
            }
            if (end <= start)
            {
                Msg.Error("End time must be after the start time.", "Validation Error");
                return false;
            }

            ev = new Event();
            ev.Title = title;
            ev.Description = description;
            ev.MaxTickets = maxTickets;
            ev.StartDatetime = start;
            ev.EndDatetime = end;
            return true;
        }

        private static DateTime WithoutSeconds(DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
        }
    }
}
