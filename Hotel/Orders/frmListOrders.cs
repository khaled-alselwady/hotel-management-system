using Hotel_Business;
using System.Data;
using System.Windows.Forms;

namespace Hotel.Orders
{
    public partial class frmListOrders : Form
    {
        private DataTable _dtOrders;

        public frmListOrders()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Order ID":
                    return "OrderID";

                case "Booking ID":
                    return "BookingID";

                case "Guest Name":
                    return "GuestName";

                case "Order Type":
                    return "OrderType";

                default:
                    return "None";
            }
        }

        private void _RefreshOrdersList()
        {
            _dtOrders = clsOrder.GetAllOrders();
            dgvOrdersList.DataSource = _dtOrders;
            lblNumberOfRecords.Text = dgvOrdersList.Rows.Count.ToString();

            if (dgvOrdersList.Rows.Count > 0)
            {
                dgvOrdersList.Columns[0].HeaderText = "Order ID";
                dgvOrdersList.Columns[0].Width = 120;

                dgvOrdersList.Columns[1].HeaderText = "Guest Name";
                dgvOrdersList.Columns[1].Width = 350;

                dgvOrdersList.Columns[2].HeaderText = "Booking ID";
                dgvOrdersList.Columns[2].Width = 160;

                dgvOrdersList.Columns[3].HeaderText = "Room Number";
                dgvOrdersList.Columns[3].Width = 180;

                dgvOrdersList.Columns[4].HeaderText = "Order Type";
                dgvOrdersList.Columns[4].Width = 150;

                dgvOrdersList.Columns[5].HeaderText = "Fees";
                dgvOrdersList.Columns[5].Width = 150;

                dgvOrdersList.Columns[6].HeaderText = "Order Date";
                dgvOrdersList.Columns[6].Width = 300;
            }
        }

        private int? _GetOrderIDFromDGV()
        {
            return (int?)dgvOrdersList.CurrentRow.Cells["OrderID"].Value;
        }

        private void frmListOrders_Load(object sender, System.EventArgs e)
        {
            _RefreshOrdersList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Order Type");

            cbOrderTypes.Visible = (cbFilter.Text == "Order Type");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbOrderTypes.Visible)
            {
                cbOrderTypes.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (_dtOrders.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtOrders.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvOrdersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text != "Guest Name")
            {
                // search with numbers
                _dtOrders.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtOrders.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvOrdersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text != "Guest Name")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbOrderTypes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_dtOrders.Rows.Count == 0)
                return;

            if (cbOrderTypes.Text == "All")
            {
                _dtOrders.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvOrdersList.Rows.Count.ToString();
                return;
            }

            _dtOrders.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "OrderType", cbOrderTypes.Text);

            lblNumberOfRecords.Text = dgvOrdersList.Rows.Count.ToString();
        }

        private void ShowOrderDetailsToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            frmShowOrderInfo ShowOrderInfo = new frmShowOrderInfo(_GetOrderIDFromDGV());
            ShowOrderInfo.ShowDialog();

            _RefreshOrdersList();
        }

        private void btnAddNewOrder_Click(object sender, System.EventArgs e)
        {
            frmAddNewOrder AddNewOrder = new frmAddNewOrder();
            AddNewOrder.ShowDialog();

            _RefreshOrdersList();
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmsEditProfile.Visible = (dgvOrdersList.Rows.Count > 0);
        }

        private void dgvOrdersList_DoubleClick(object sender, System.EventArgs e)
        {
            frmShowOrderInfo ShowOrderInfo = new frmShowOrderInfo(_GetOrderIDFromDGV());
            ShowOrderInfo.ShowDialog();

            _RefreshOrdersList();
        }
    }
}
