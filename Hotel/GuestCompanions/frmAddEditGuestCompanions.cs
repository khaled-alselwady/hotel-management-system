using Hotel_Business;
using System.Windows.Forms;
using static Hotel.People.UserControls.ucPersonCardWithFilter;

namespace Hotel.GuestCompanions
{
    public partial class frmAddEditGuestCompanions : Form
    {
        private enum _enMode { AddNew, Update };
        private _enMode _Mode = _enMode.AddNew;

        private int? _GuestCompanionID = null;
        private clsGuestCompanion _GuestCompanion = null;

        private int? _BookingID = null;
        private clsBooking _Booking = null;

        private int? _SelectedPersonID = null;

        public frmAddEditGuestCompanions(int? BookingID)
        {
            InitializeComponent();

            _BookingID = BookingID;
            _Mode = _enMode.AddNew;
        }

        public frmAddEditGuestCompanions(int? BookingID, int? GuestCompanionID)
        {
            InitializeComponent();

            _BookingID = BookingID;
            _GuestCompanionID = GuestCompanionID;
            _Mode = _enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == _enMode.AddNew)
            {
                lblTitle.Text = "Add New Guest Companion";
                _GuestCompanion = new clsGuestCompanion();

                ucPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update Guest Companion";
            }

            this.Text = lblTitle.Text;

            _Booking = clsBooking.Find(_BookingID);

            if (_Booking == null)
            {
                MessageBox.Show("No Booking with ID = " + _BookingID, "Booking Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }

            ucBookingCard1.LoadBookingInfo(_Booking.BookingID);
            ucReservationsCard1.LoadReservationInfo(_Booking.ReservationID);
            ucPersonCard1.LoadPersonInfo(_Booking.GuestInfo.PersonID);
        }

        private void _LoadData()
        {
            _GuestCompanion = clsGuestCompanion.Find(_GuestCompanionID);
            ucPersonCardWithFilter1.FilterEnabled = false;

            if (_GuestCompanion == null)
            {
                MessageBox.Show("No Guest Companion with ID = " + _GuestCompanionID, "Guest Companion Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }           
        }

        private void _SaveGuestCompanion()
        {
            _GuestCompanion.PersonID = _SelectedPersonID;
            _GuestCompanion.GuestID = _BookingID;

            if (!_GuestCompanion.Save())
            {
                MessageBox.Show("Guest Companion Saved Failed!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Guest Companion Saved Successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblGuestCompanionID.Text = _GuestCompanion.GuestCompanionID.ToString();

            _Mode = _enMode.Update;

            lblTitle.Text = "Update Guest Companion";
            this.Text = lblTitle.Text;
        }

        private void ucPersonCardWithFilter1_OnPersonSelected(object sender, PersonSelectedEventArgs e)
        {
            if (!e.PersonID.HasValue)
            {
                btnSave.Enabled = false;
                return;
            }

            if (clsGuest.IsPersonAGuest(e.PersonID))
            {
                MessageBox.Show("This person is a guest, so cannot be a guest companion!",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnSave.Enabled = false;
                return;
            }

            if (clsGuestCompanion.DoesGuestCompanionExistByPersonID(e.PersonID))
            {
                MessageBox.Show("This person is a Guest Companion, so cannot be a guest companion again!",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnSave.Enabled = false;
                return;
            }

            _SelectedPersonID = e.PersonID;
            btnSave.Enabled = true;
        }

        private void frmAddEditGuestCompanions_Load(object sender, System.EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!_SelectedPersonID.HasValue)
            {
                MessageBox.Show("You have to select or add the Guest Companion first!",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _SaveGuestCompanion();
        }
    }
}
