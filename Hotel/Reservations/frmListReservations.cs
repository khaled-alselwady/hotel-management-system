using Hotel.GlobalClasses;
using Hotel.OrderItems;
using Hotel_Business;
using System.Data;
using System.Windows.Forms;
using static Hotel_Business.clsReservation;

namespace Hotel.Reservations
{
    public partial class frmListReservations : Form
    {
        private DataTable _dtReservation;

        public frmListReservations()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Reservation ID":
                    return "ReservationID";

                case "Reserved By":
                    return "ReservedBy";

                case "Room Number":
                    return "RoomNumber";

                case "Status":
                    return "Status";

                default:
                    return "None";
            }
        }

        private void _RefreshReservationList()
        {
            _dtReservation = clsReservation.GetAllReservations();
            dgvReservationList.DataSource = _dtReservation;
            lblNumberOfRecords.Text = dgvReservationList.Rows.Count.ToString();

            if (dgvReservationList.Rows.Count > 0)
            {
                dgvReservationList.Columns[0].HeaderText = "Reservation ID";
                dgvReservationList.Columns[0].Width = 110;

                dgvReservationList.Columns[1].HeaderText = "Reserved By";
                dgvReservationList.Columns[1].Width = 190;

                dgvReservationList.Columns[2].HeaderText = "Room Number";
                dgvReservationList.Columns[2].Width = 130;

                dgvReservationList.Columns[3].HeaderText = "Reservation Date";
                dgvReservationList.Columns[3].Width = 130;

                dgvReservationList.Columns[4].HeaderText = "Number Of People";
                dgvReservationList.Columns[4].Width = 100;

                dgvReservationList.Columns[5].HeaderText = "Status";
                dgvReservationList.Columns[5].Width = 130;
            }
        }

        private int? _GetReservationIDFromDGV()
        {
            return (int?)dgvReservationList.CurrentRow.Cells["ReservationID"].Value;
        }

        private byte? _GetNumberOfPeopleFromDGV()
        {
            return (byte?)dgvReservationList.CurrentRow.Cells["NumberOfPeople"].Value;
        }

        private int? _GetGuestIDFromReservationID()
        {
            clsReservation Reservation = clsReservation.Find(_GetReservationIDFromDGV());

            if (Reservation == null)
                return null;

            return Reservation.GuestID;
        }

        private void frmListReservations_Load(object sender, System.EventArgs e)
        {
            _RefreshReservationList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Status");

            cbReservationStatus.Visible = (cbFilter.Text == "Status");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbReservationStatus.Visible)
            {
                cbReservationStatus.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (_dtReservation.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtReservation.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvReservationList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Reservation ID" || cbFilter.Text == "Room Number")
            {
                // search with numbers
                _dtReservation.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtReservation.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvReservationList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Reservation ID" || cbFilter.Text == "Room Number")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbReservationStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_dtReservation.Rows.Count == 0)
                return;

            if (cbReservationStatus.Text == "All")
            {
                _dtReservation.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvReservationList.Rows.Count.ToString();
                return;
            }

            _dtReservation.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Status", cbReservationStatus.Text);

            lblNumberOfRecords.Text = dgvReservationList.Rows.Count.ToString();
        }

        private void btnAddNewReservation_Click(object sender, System.EventArgs e)
        {
            frmAddEditReservation AddReservation = new frmAddEditReservation();
            AddReservation.ShowDialog();

            _RefreshReservationList();
        }

        private void ShowReservationDetailsToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            frmShowReservationInfo ShowReservationInfo = new frmShowReservationInfo(_GetReservationIDFromDGV());
            ShowReservationInfo.ShowDialog();

            _RefreshReservationList();
        }

        private void EditReservationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            frmAddEditReservation EditReservation = new frmAddEditReservation(_GetReservationIDFromDGV());
            EditReservation.ShowDialog();

            _RefreshReservationList();
        }

        private void dgvGuestsList_DoubleClick(object sender, System.EventArgs e)
        {
            frmShowReservationInfo ShowReservationInfo = new frmShowReservationInfo(_GetReservationIDFromDGV());
            ShowReservationInfo.ShowDialog();

            _RefreshReservationList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Enabled = dgvReservationList.Rows.Count > 0;

            string Status = (string)dgvReservationList.CurrentRow.Cells["Status"].Value;
            int? ReservationID = _GetReservationIDFromDGV();

            EditReservationToolStripMenuItem.Enabled =
            ConfirmReservationToolStripMenuItem1.Enabled =
            (Status == enReservationStatus.Pending.ToString());

            CancelReservationToolStripMenuItem.Enabled =
            DeleteReservationToolStripMenuItem.Enabled =
            (Status == enReservationStatus.Pending.ToString()) ||
            (Status == enReservationStatus.Invalid.ToString());

            CheckInToolStripMenuItem.Enabled =
            (Status == enReservationStatus.Confirmed.ToString()) &&
            !(clsReservation.IsReservationChecked(ReservationID));

            AddGuestCompanionToolStripMenuItem.Enabled =
            (Status == enReservationStatus.Confirmed.ToString()) &&
            (clsReservation.IsReservationChecked(ReservationID)) &&
            (clsGuestCompanion.GetAllGuestCompanionsForGuestCount(_GetGuestIDFromReservationID()) < _GetNumberOfPeopleFromDGV()) &&
            !(clsBooking.IsBookingCompleted(clsReservation.GetBookingIDByReservationID(ReservationID)));
        }

        private void ConfirmReservationToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to confirm this reservation?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsReservation.SetStatus(_GetReservationIDFromDGV(), clsReservation.enReservationStatus.Confirmed))
                {
                    MessageBox.Show("Reservation confirmed successfully! You can now proceed " +
                        "with the check-in process", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshReservationList();
                }
                else
                {
                    MessageBox.Show("Reservation confirmed failed!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void CancelReservationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this reservation?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsReservation.SetStatus(_GetReservationIDFromDGV(), clsReservation.enReservationStatus.Canceled))
                {
                    MessageBox.Show("Reservation canceled successfully!", "Confirmed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshReservationList();
                }
                else
                {
                    MessageBox.Show("Reservation canceled failed!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteReservationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsReservation.DeleteReservation(_GetReservationIDFromDGV()))
                {
                    MessageBox.Show("Reservation deleted successfully!", "Confirmed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshReservationList();
                }
                else
                {
                    MessageBox.Show("Reservation deleted failed!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CheckInToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to check-in this reservation?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsReservation.CheckIn(_GetReservationIDFromDGV(), clsGlobal.CurrentUser.UserID))
                {
                    MessageBox.Show("Check-in completed successfully!", "Check-in Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Check-in failed!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddGuestCompanionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int? BookingID = clsBooking.GetBookingIDByReservationID(_GetReservationIDFromDGV());

            frmAddEditOrderItems AddOrderItems = new frmAddEditOrderItems(BookingID);
            AddOrderItems.ShowDialog();

            _RefreshReservationList();
        }
    }
}
