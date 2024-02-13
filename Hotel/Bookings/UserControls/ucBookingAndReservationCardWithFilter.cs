using Hotel.People.UserControls;
using Hotel.Reservations.UserControls;
using Hotel_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Bookings.UserControls
{
    public partial class ucBookingAndReservationCardWithFilter : UserControl
    {
        #region Declare Event
        public class BookingAndReservationSelectedEventArgs : EventArgs
        {
            public int? BookingID { get; }
            public int? ReservationID { get; }

            public BookingAndReservationSelectedEventArgs(int? BookingID, int? ReservationID)
            {
                this.BookingID = BookingID;
                this.ReservationID = ReservationID;
            }
        }

        public event EventHandler<BookingAndReservationSelectedEventArgs> OnBookingAndReservationSelected;

        public void RaiseOnBookingAndReservationSelected(int? BookingID, int? ReservationID)
        {
            RaiseOnBookingAndReservationSelected(new BookingAndReservationSelectedEventArgs(BookingID, ReservationID));
        }

        protected void RaiseOnBookingAndReservationSelected(BookingAndReservationSelectedEventArgs e)
        {
            OnBookingAndReservationSelected?.Invoke(this, e);
        }
        #endregion

        private bool _FilterEnable = true;
        public bool FilterEnabled
        {
            get => _FilterEnable;
            set => gbFilter.Enabled = _FilterEnable = value;
        }

        public int? BookingID => ucBookingCard1.BookingID;
        public clsBooking BookingInfo => ucBookingCard1.BookingInfo;

        public int? ReservationID => ucReservationsCard1.ReservationID;
        public clsReservation ReservationInfo => ucReservationsCard1.ReservationInfo;

        public ucBookingAndReservationCardWithFilter()
        {
            InitializeComponent();
        }

        private void _Find()
        {
            switch (cbFindBy.Text)
            {
                case "Booking ID":
                    LoadBookingInfo(int.Parse(txtSearch.Text.Trim())); break;

                case "Reservation ID":
                    LoadReservationsInfo(int.Parse(txtSearch.Text.Trim())); break;

                case "Room Number":
                    LoadInfoByRoomNumber(int.Parse(txtSearch.Text.Trim())); break;
            }
        }

        public void LoadBookingInfo(int? BookingID)
        {
            txtSearch.Text = BookingID.ToString();
            ucBookingCard1.LoadBookingInfo(BookingID);

            if (ucBookingCard1.BookingInfo == null)
            {
                ucReservationsCard1.Reset();

                if (OnBookingAndReservationSelected != null)
                    RaiseOnBookingAndReservationSelected(null, null);

                return;
            }

            ucReservationsCard1.LoadReservationInfo(ucBookingCard1.BookingInfo?.ReservationID);

            if (OnBookingAndReservationSelected != null)
                RaiseOnBookingAndReservationSelected(ucBookingCard1.BookingID,
                                                     ucReservationsCard1.ReservationID);
        }

        public void LoadReservationsInfo(int? ReservationID)
        {
            txtSearch.Text = ReservationID.ToString();
            ucReservationsCard1.LoadReservationInfo(ReservationID);

            if (ucReservationsCard1.ReservationInfo == null)
            {
                ucBookingCard1.Reset();

                if (OnBookingAndReservationSelected != null)
                    RaiseOnBookingAndReservationSelected(null, null);

                return;
            }

            if (!clsReservation.IsReservationChecked(ReservationID))
            {
                MessageBox.Show("This reservation has not yet been checked-in, so you cannot request an order for it", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear();

                if (OnBookingAndReservationSelected != null)
                    RaiseOnBookingAndReservationSelected(null, null);

                return;
            }

            ucBookingCard1.LoadBookingInfo(clsReservation.GetBookingIDByReservationID(ReservationID));

            if (OnBookingAndReservationSelected != null)
                RaiseOnBookingAndReservationSelected(ucBookingCard1.BookingID,
                                                     ucReservationsCard1.ReservationID);
        }

        public void LoadInfoByRoomNumber(int RoomNumber)
        {
            clsRoom Room = clsRoom.FindByRoomNumber(RoomNumber);

            if (Room == null)
            {
                MessageBox.Show($"There is no room with number = {RoomNumber} !", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear();

                if (OnBookingAndReservationSelected != null)
                    RaiseOnBookingAndReservationSelected(null, null);

                return;
            }

            if (!Room.IsRoomBooked())
            {
                MessageBox.Show("This room has not been booked, so you cannot request an order for it", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Clear();

                if (OnBookingAndReservationSelected != null)
                    RaiseOnBookingAndReservationSelected(null, null);

                return;
            }

            txtSearch.Text = RoomNumber.ToString();
            ucBookingCard1.LoadBookingInfo(clsBooking.GetBookingIDByRoomID(Room.RoomID));
            ucReservationsCard1.LoadReservationInfo(ucBookingCard1.BookingInfo?.ReservationID);

            if (OnBookingAndReservationSelected != null)
                RaiseOnBookingAndReservationSelected(ucBookingCard1.BookingID,
                                                     ucReservationsCard1.ReservationID);
        }

        public void FilterFocus()
        {
            txtSearch.Focus();
        }

        public void Clear()
        {
            ucBookingCard1.Reset();
            ucReservationsCard1.Reset();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSearch, "This field cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtSearch, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Find();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            // to make sure that the user can enter only numbers
            if (cbFindBy.Text == "Booking ID" || cbFindBy.Text == "Reservation ID" || cbFindBy.Text == "Room Number")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ucBookingAndReservationCardWithFilter_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }
    }
}
