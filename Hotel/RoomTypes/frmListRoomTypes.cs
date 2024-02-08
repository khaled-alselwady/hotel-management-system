using Guna.UI2.WinForms;
using Hotel_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Hotel.RoomTypes
{
    public partial class frmListRoomTypes : Form
    {
        private DataTable _dtRoom;

        public frmListRoomTypes()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Room Type ID":
                    return "RoomTypeID";

                case "Room Type Title":
                    return "RoomTypeTitle";

                case "Capacity":
                    return "Capacity";

                case "Price Per Night":
                    return "PricePerNight";

                default:
                    return "None";
            }
        }

        private void _RefreshRoomList()
        {
            _dtRoom = clsRoomType.GetAllRoomTypes();
            dgvRoomList.DataSource = _dtRoom;
            lblNumberOfRecords.Text = dgvRoomList.Rows.Count.ToString();

            if (dgvRoomList.Rows.Count > 0)
            {
                dgvRoomList.Columns[0].HeaderText = "Room Type ID";
                dgvRoomList.Columns[0].Width = 110;

                dgvRoomList.Columns[1].HeaderText = "Room Type Title";
                dgvRoomList.Columns[1].Width = 190;

                dgvRoomList.Columns[2].HeaderText = "Capacity";
                dgvRoomList.Columns[2].Width = 130;

                dgvRoomList.Columns[3].HeaderText = "Price Per Night";
                dgvRoomList.Columns[3].Width = 180;
            }
        }

        private byte? _GetRoomIDFromDGV()
        {
            return (byte?)(int?)dgvRoomList.CurrentRow.Cells["RoomTypeID"].Value;
        }

        private void frmListRoomTypes_Load(object sender, EventArgs e)
        {
            _RefreshRoomList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
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

            if (cbFilter.Text != "Room Type Title")
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
            if (cbFilter.Text != "Room Type Title")
            {
                char inputChar = e.KeyChar;

                // Allow digits, the decimal point, and the backspace.
                bool isDigit = Char.IsDigit(inputChar);
                bool isDecimalPoint = (inputChar == '.');
                bool isBackspace = (inputChar == '\b');

                // If the input character is not a digit, decimal point, or backspace, suppress it.
                if (!isDigit && !isDecimalPoint && !isBackspace)
                {
                    e.Handled = true;
                }

                // Make sure there is only one decimal point in the input.
                if (isDecimalPoint && ((sender as Guna2TextBox).Text.Contains(".") || (sender as Guna2TextBox).Text.Length == 0))
                {
                    e.Handled = true;
                }
            }
        }

        private void ShowRoomTypeDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowRoomTypeInfo ShowRoomTypeInfo = new frmShowRoomTypeInfo(_GetRoomIDFromDGV());
            ShowRoomTypeInfo.ShowDialog();
        }

        private void EditRoomTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditRoomType EditRoomType = new frmEditRoomType(_GetRoomIDFromDGV());
            EditRoomType.ShowDialog();

            _RefreshRoomList();
        }

        private void dgvRoomList_DoubleClick(object sender, EventArgs e)
        {
            frmShowRoomTypeInfo ShowRoomTypeInfo = new frmShowRoomTypeInfo(_GetRoomIDFromDGV());
            ShowRoomTypeInfo.ShowDialog();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = dgvRoomList.Rows.Count > 0;
        }
    }
}
