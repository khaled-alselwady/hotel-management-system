using Hotel_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel.Rooms
{
    public partial class frmListRooms : Form
    {
        private DataTable _dtRoom;

        public frmListRooms()
        {
            InitializeComponent();
        }

        private void _FillComboBoxWithRoomTypeTitles()
        {
            cbRoomTypes.Items.Add("All");

            DataTable dtRoomTypesTitle = clsRoomType.GetAllRoomTypesTitle();

            foreach (DataRow drTitle in dtRoomTypesTitle.Rows)
            {
                cbRoomTypes.Items.Add(drTitle["RoomTypeTitle"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Room ID":
                    return "RoomID";

                case "Room Type":
                    return "RoomTypeTitle";

                case "Room Number":
                    return "RoomNumber";

                case "Floor Number":
                    return "FloorNumber";

                case "Size":
                    return "Size";

                case "Status":
                    return "Status";

                case "Is Smoking Allowed":
                    return "IsSmokingAllowed";

                case "Is Pet Friendly":
                    return "IsPetFriendly";

                default:
                    return "None";
            }
        }

        private void _RefreshRoomList()
        {
            _dtRoom = clsRoom.GetAllRooms();
            dgvRoomList.DataSource = _dtRoom;
            lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();

            if (dgvRoomList.Rows.Count > 0)
            {
                dgvRoomList.Columns[0].HeaderText = "Room ID";
                dgvRoomList.Columns[0].Width = 110;

                dgvRoomList.Columns[1].HeaderText = "Room Type";
                dgvRoomList.Columns[1].Width = 190;

                dgvRoomList.Columns[2].HeaderText = "Room Number";
                dgvRoomList.Columns[2].Width = 130;

                dgvRoomList.Columns[3].HeaderText = "Floor Number";
                dgvRoomList.Columns[3].Width = 130;

                dgvRoomList.Columns[4].HeaderText = "Size";
                dgvRoomList.Columns[4].Width = 100;

                dgvRoomList.Columns[5].HeaderText = "Status";
                dgvRoomList.Columns[5].Width = 130;

                dgvRoomList.Columns[6].HeaderText = "Is Smoking Allowed";
                dgvRoomList.Columns[6].Width = 130;

                dgvRoomList.Columns[7].HeaderText = "Is Pet Friendly";
                dgvRoomList.Columns[7].Width = 130;
            }
        }

        private int? _GetRoomIDFromDGV()
        {
            return (int?)dgvRoomList.CurrentRow.Cells["RoomID"].Value;
        }

        private void frmListRooms_Load(object sender, EventArgs e)
        {
            _RefreshRoomList();
            _FillComboBoxWithRoomTypeTitles();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Status") && (cbFilter.Text != "Room Type");

            cbRoomStatus.Visible = (cbFilter.Text == "Status");
            cbRoomTypes.Visible = (cbFilter.Text == "Room Type");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbRoomStatus.Visible)
            {
                cbRoomStatus.SelectedIndex = 0;
            }

            if (cbRoomTypes.Visible)
            {
                cbRoomTypes.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtRoom.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtRoom.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Room ID" || cbFilter.Text == "Room Number" || cbFilter.Text == "Floor Number")
            {
                // search with numbers
                _dtRoom.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtRoom.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Room ID" || cbFilter.Text == "Room Number" || cbFilter.Text == "Floor Number")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbRoomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtRoom.Rows.Count == 0)
                return;

            if (cbRoomStatus.Text == "All")
            {
                _dtRoom.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();
                return;
            }

            _dtRoom.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Status", cbRoomStatus.Text);

            lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();
        }

        private void cbRoomTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtRoom.Rows.Count == 0)
                return;

            if (cbRoomTypes.Text == "All")
            {
                _dtRoom.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();
                return;
            }

            _dtRoom.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "RoomTypeTitle", cbRoomTypes.Text);

            lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();
        }

        private void ShowRoomDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowRoomInfo ShowRoomInfo = new frmShowRoomInfo(_GetRoomIDFromDGV());
            ShowRoomInfo.ShowDialog();

            _RefreshRoomList();
        }

        private void EditRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditRoom EditRoom = new frmAddEditRoom(_GetRoomIDFromDGV());
            EditRoom.ShowDialog();

            _RefreshRoomList();
        }

        private void DeleteRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsRoom.DeleteRoom(_GetRoomIDFromDGV()))
                {
                    MessageBox.Show("Room deleted successfully!", "Confirmed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshRoomList();
                }
                else
                {
                    MessageBox.Show("Room deleted failed!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNewRoom_Click(object sender, EventArgs e)
        {
            frmAddEditRoom EditRoom = new frmAddEditRoom();
            EditRoom.ShowDialog();

            _RefreshRoomList();
        }

        private void dgvRoomList_DoubleClick(object sender, EventArgs e)
        {
            frmShowRoomInfo ShowRoomInfo = new frmShowRoomInfo(_GetRoomIDFromDGV());
            ShowRoomInfo.ShowDialog();

            _RefreshRoomList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string Status = (string)dgvRoomList.CurrentRow.Cells["Status"].Value;

            if (Status == "Booked")
            {
                PutUnderMaintenanceToolStripMenuItem1.Enabled =
                   ReleaseFromMaintenanceToolStripMenuItem.Enabled = false;

                return;
            }

            PutUnderMaintenanceToolStripMenuItem1.Enabled = (Status == "Available");

            ReleaseFromMaintenanceToolStripMenuItem.Enabled = !PutUnderMaintenanceToolStripMenuItem1.Enabled;
        }

        private void PutUnderMaintenanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int? RoomID = _GetRoomIDFromDGV();

            if (MessageBox.Show($"Are you sure you want to put this room with ID = {RoomID} under" +
                $" maintenance?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.No)
                return;

            if (clsRoom.ChangeRoomStatus(_GetRoomIDFromDGV(), clsRoom.enRoomStatus.UnderMaintenance))
            {
                MessageBox.Show($"The room with ID = {RoomID} has been successfully put under " +
                    $"maintenance.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _RefreshRoomList();
            }
            else
            {
                MessageBox.Show($"Failed to put the room with ID = {RoomID} under maintenance.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReleaseFromMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? RoomID = _GetRoomIDFromDGV();

            if (MessageBox.Show($"Are you sure you want to release this room with ID = {RoomID} from" +
                $" maintenance?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.No)
                return;

            if (clsRoom.ChangeRoomStatus(_GetRoomIDFromDGV(), clsRoom.enRoomStatus.Available))
            {
                MessageBox.Show($"The room with ID = {RoomID} has been successfully released from" +
                    $" maintenance.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _RefreshRoomList();
            }
            else
            {
                MessageBox.Show($"Failed to release the room with ID = {RoomID} from maintenance.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
