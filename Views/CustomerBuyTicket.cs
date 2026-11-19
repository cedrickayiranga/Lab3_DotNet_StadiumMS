using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;
using StadiumMS.Models;

namespace StadiumMS.Views
{
    public partial class CustomerBuyTicket : Form
    {
        private Event _event;
        private List<EventSeat> _seats = new List<EventSeat>();

        public CustomerBuyTicket()
        {
            InitializeComponent();
        }

        public CustomerBuyTicket(Event selectedEvent) : this()
        {
            _event = selectedEvent;
        }

        private void CustomerBuyTicket_Load(object sender, EventArgs e)
        {
            if (_event == null) return;

            txtEvent.Text = _event.Title;
            txtDate.Text = _event.StartDatetime.ToString("dd/MM/yyyy HH:mm");
            LoadSeats();
        }

        private void LoadSeats()
        {
            try
            {
                _seats = SeatController.GetAvailable(_event.Id);

                cmbSeat.Items.Clear();
                cmbSeat.Items.Add("-- Select Seat --");
                foreach (EventSeat seat in _seats)
                {
                    cmbSeat.Items.Add(seat.SeatNumber);
                }
                cmbSeat.SelectedIndex = 0;

                if (_seats.Count == 0)
                    Msg.Warn("No seats available for this event!", "Sold Out");
            }
            catch (Exception ex)
            {
                Msg.Error("Error loading seats: " + ex.Message);
            }
        }

        private EventSeat SelectedSeat()
        {
            int index = cmbSeat.SelectedIndex;
            if (index <= 0 || index > _seats.Count) return null;
            return _seats[index - 1];
        }

        private void cmbSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventSeat seat = SelectedSeat();
            txtPrice.Text = seat == null ? "" : seat.Price.ToString("N2");
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                Msg.Error("Please login first!", "Not Logged In");
                Nav.Go(this, new LoginForm());
                return;
            }
            if (_event == null)
            {
                Msg.Error("No event selected!");
                return;
            }

            DateTime now = DateTime.Now;
            if (_event.StartDatetime <= now)
            {
                Msg.Warn("Ticket sales are closed: event has already started.", "Business Rule");
                return;
            }
            if (now > _event.EndDatetime)
            {
                Msg.Warn("Ticket sales are closed: event has ended.", "Business Rule");
                return;
            }

            EventSeat seat = SelectedSeat();
            if (seat == null)
            {
                Msg.Error("Please select a seat!", "Validation Error");
                return;
            }
            if (cmbPayment.SelectedIndex <= 0)
            {
                Msg.Error("Please select a payment method!", "Validation Error");
                return;
            }
            string paymentMethod = cmbPayment.SelectedItem.ToString();

            bool confirmed = Msg.Confirm(
                "Purchase ticket for:\n" +
                "Event: " + _event.Title + "\n" +
                "Seat: " + seat.SeatNumber + "\n" +
                "Price: " + seat.Price.ToString("N2") + " RWF\n" +
                "Payment: " + paymentMethod + "\n\n" +
                "Confirm purchase?", "Confirm Purchase");
            if (!confirmed) return;

            try
            {
                string error;
                bool success = TicketController.Buy(Session.CurrentUser.Id, _event.Id, seat.Id, paymentMethod, out error);
                if (success)
                {
                    Msg.Info("Ticket purchased successfully!", "Purchase Successful");
                    Nav.Go(this, new CustomerMyTickets());
                }
                else
                {
                    Msg.Error("Purchase failed! " + error);
                    LoadSeats();
                }
            }
            catch (Exception ex)
            {
                Msg.Error("Database error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Nav.Go(this, new CustomerViewEvents());
        }
    }
}
