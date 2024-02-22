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

namespace Hotel.RoomServices
{
    public partial class frmListRoomServices : Form
    {
        private DataTable _dtRoomServices;

        public frmListRoomServices()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Room Service ID":
                    return "RoomServiceID";

                case "Room Service Title":
                    return "RoomServiceTitle";

                case "Fees":
                    return "Fees";

                case "Description":
                    return "Description";

                default:
                    return "None";
            }
        }

        private void _RefreshRoomServicesList()
        {
            _dtRoomServices = clsRoomService.GetAllRoomServices();
            dgvRoomServiceList.DataSource = _dtRoomServices;
            lblNumberOfRecords.Text = dgvRoomServiceList.Rows.Count.ToString();

            if (dgvRoomServiceList.Rows.Count > 0)
            {
                dgvRoomServiceList.Columns[0].HeaderText = "Room Service ID";
                dgvRoomServiceList.Columns[0].Width = 160;

                dgvRoomServiceList.Columns[1].HeaderText = "Room Service Title";
                dgvRoomServiceList.Columns[1].Width = 200;

                dgvRoomServiceList.Columns[2].HeaderText = "Fees";
                dgvRoomServiceList.Columns[2].Width = 130;

                dgvRoomServiceList.Columns[3].HeaderText = "Description";
                dgvRoomServiceList.Columns[3].Width = 826;
            }
        }

        private byte? _GetRoomServicesIDFromDGV()
        {
            return (byte?)(int?)dgvRoomServiceList.CurrentRow.Cells["RoomServiceID"].Value;
        }

        private void frmListRoomServices_Load(object sender, EventArgs e)
        {
            _RefreshRoomServicesList();
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
            if (_dtRoomServices.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtRoomServices.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvRoomServiceList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Room Service ID")
            {
                // search with numbers
                _dtRoomServices.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtRoomServices.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvRoomServiceList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Room Service ID")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void EditRoomServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditRoomServices EditRoomServices = new frmAddEditRoomServices(_GetRoomServicesIDFromDGV());
            EditRoomServices.ShowDialog();

            _RefreshRoomServicesList();
        }

        private void btnAddNewRoomService_Click(object sender, EventArgs e)
        {
            frmAddEditRoomServices AddRoomServices = new frmAddEditRoomServices();
            AddRoomServices.ShowDialog();

            _RefreshRoomServicesList();
        }

        private void DeleteRoomServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this service?", "Confirm",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsRoomService.DeleteRoomService(_GetRoomServicesIDFromDGV()))
                {
                    MessageBox.Show("Room Service deleted successfully!", "Confirmed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshRoomServicesList();
                }
                else
                {
                    MessageBox.Show("Room Service deleted failed!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowRoomServiceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowRoomServiceInfo ShowRoomServiceInfo = new frmShowRoomServiceInfo(_GetRoomServicesIDFromDGV());
            ShowRoomServiceInfo.ShowDialog();
        }
    }
}
