using Hotel.GlobalClasses;
using Hotel.GuestCompanions;
using Hotel_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel.Bookings
{
    public partial class frmListBookings : Form
    {
        private DataTable _dtBooking;

        public frmListBookings()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Booking ID":
                    return "BookingID";

                case "Reservation ID":
                    return "ReservationID";

                case "Guest":
                    return "FullName";

                case "Room Number":
                    return "RoomNumber";

                case "Status":
                    return "Status";

                default:
                    return "None";
            }
        }

        private void _RefreshBookingList()
        {
            _dtBooking = clsBooking.GetAllBookings();
            dgvBookingList.DataSource = _dtBooking;
            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

            if (dgvBookingList.Rows.Count > 0)
            {
                dgvBookingList.Columns[0].HeaderText = "Booking ID";
                dgvBookingList.Columns[0].Width = 130;

                dgvBookingList.Columns[1].HeaderText = "Reservation ID";
                dgvBookingList.Columns[1].Width = 160;

                dgvBookingList.Columns[2].HeaderText = "Guest";
                dgvBookingList.Columns[2].Width = 280;

                dgvBookingList.Columns[3].HeaderText = "Room Number";
                dgvBookingList.Columns[3].Width = 150;

                dgvBookingList.Columns[4].HeaderText = "Check In Date";
                dgvBookingList.Columns[4].Width = 190;

                dgvBookingList.Columns[5].HeaderText = "Check Out Date";
                dgvBookingList.Columns[5].Width = 190;

                dgvBookingList.Columns[6].HeaderText = "Number Of People";
                dgvBookingList.Columns[6].Width = 180;

                dgvBookingList.Columns[7].HeaderText = "Status";
                dgvBookingList.Columns[7].Width = 130;
            }
        }

        private int? _GetBookingIDFromDGV()
        {
            return (int?)dgvBookingList.CurrentRow.Cells["BookingID"].Value;
        }

        private void frmListBookings_Load(object sender, EventArgs e)
        {
            _RefreshBookingList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Status");

            cbBookingStatus.Visible = (cbFilter.Text == "Status");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbBookingStatus.Visible)
            {
                cbBookingStatus.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtBooking.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Reservation ID" ||
                cbFilter.Text == "Booking ID" ||
                cbFilter.Text == "Room Number")
            {
                // search with numbers
                _dtBooking.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtBooking.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Reservation ID" ||
                cbFilter.Text == "Booking ID" ||
                cbFilter.Text == "Room Number")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbBookingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtBooking.Rows.Count == 0)
                return;

            if (cbBookingStatus.Text == "All")
            {
                _dtBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
                return;
            }

            _dtBooking.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Status", cbBookingStatus.Text);

            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingInfo ShowBookingInfo = new frmShowBookingInfo(_GetBookingIDFromDGV());
            ShowBookingInfo.ShowDialog();
        }

        private void dgvBookingList_DoubleClick(object sender, EventArgs e)
        {
            frmShowBookingInfo ShowBookingInfo = new frmShowBookingInfo(_GetBookingIDFromDGV());
            ShowBookingInfo.ShowDialog();
        }

        private void ShowGuestCompanionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBooking Booking = clsBooking.Find(_GetBookingIDFromDGV());

            if (Booking == null)
                return;

            frmShowAllGuestCompanionsForGuest ShowAllGuestCompanionsForGuest = new frmShowAllGuestCompanionsForGuest(Booking.GuestID);
            ShowAllGuestCompanionsForGuest.ShowDialog();

            _RefreshBookingList();
        }

        private void CheckOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to check-out this reservation?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsBooking.CheckOut(_GetBookingIDFromDGV()))
                {
                    MessageBox.Show("Check-out completed successfully!", "Check-out Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshBookingList();
                }
                else
                {
                    MessageBox.Show("Check-out failed!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CheckOutToolStripMenuItem.Enabled = dgvBookingList.CurrentRow.Cells["CheckOutDate"].Value == DBNull.Value;
        }
    }
}
