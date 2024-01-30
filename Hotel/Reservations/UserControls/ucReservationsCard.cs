using Hotel.GlobalClasses;
using Hotel.People;
using Hotel.Properties;
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

namespace Hotel.Reservations.UserControls
{
    public partial class ucReservationsCard : UserControl
    {
        private int? _ReservationID = null;
        private clsReservation _Reservation = null;

        public int? ReservationID => _ReservationID;
        public clsReservation ReservationInfo => _Reservation;

        public ucReservationsCard()
        {
            InitializeComponent();
        }

        private void _FillReservationData()
        {
            llShowPersonInfo.Enabled = true;
            llShowRoomInfo.Enabled = true;

            lblReservationID.Text = _Reservation.ReservationID.ToString();
            lblRoomType.Text = _Reservation.RoomInfo.RoomTypeName;
            lblRoomNumber.Text = _Reservation.RoomInfo.RoomNumber.ToString();
            lblReservationDate.Text = clsFormat.DateToShort(_Reservation.ReservedForDate);
            lblReservedBy.Text = _Reservation.GuestInfo.PersonInfo.FullName;
            lblNumberOfPeople.Text = _Reservation.NumberOfPeople.ToString();
            lblStatus.Text = _Reservation.ReservationStatusName;
            lblCreatedByUser.Text = _Reservation.CreatedByUserInfo.Username;
            lblCreatedDate.Text = clsFormat.DateToShort(_Reservation.CreatedDate);

            pbGendor.Image = (_Reservation.GuestInfo.PersonInfo.Gender == clsPerson.enGender.Male) ?
                              Resources.gender_male : Resources.gender_female;

        }

        public void Reset()
        {
            _ReservationID = null;
            _Reservation = null;

            llShowPersonInfo.Enabled = false;
            llShowRoomInfo.Enabled = false;

            lblReservationID.Text = "[????]";
            lblRoomType.Text = "[????]";
            lblRoomNumber.Text = "[????]";
            lblReservationDate.Text = "[????]";
            lblReservedBy.Text = "[????]";
            lblNumberOfPeople.Text = "[????]";
            lblStatus.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblCreatedDate.Text = "[????]";

            pbGendor.Image = Resources.gender_male;
        }

        public void LoadReservationInfo(int? ReservationID)
        {
            _ReservationID = ReservationID;

            if (!_ReservationID.HasValue)
            {
                MessageBox.Show("There is no reservationID!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Reservation = clsReservation.Find(_ReservationID);

            if (_Reservation == null)
            {
                MessageBox.Show($"There is no reservationID with ID = {_ReservationID} !",
                    "Missing Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillReservationData();
        }

        private void llShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo ShowPersonInfo = new frmShowPersonInfo(_Reservation.GuestInfo.PersonID);
            ShowPersonInfo.ShowDialog();

            // Refresh
            LoadReservationInfo(_ReservationID);
        }

        private void llShowRoomInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet!");
        }
    }
}
