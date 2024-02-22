using Guna.UI2.WinForms;
using Hotel.RoomServices;
using Hotel_Business;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Hotel.Payments
{
    public partial class frmListPayments : Form
    {
        private DataTable _dtPayments;

        public frmListPayments()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Payment ID":
                    return "PaymentID";

                case "Booking ID":
                    return "BookingID";

                case "Guest Name":
                    return "GuestName";

                default:
                    return "None";
            }
        }

        private void _RefreshPaymentsList()
        {
            _dtPayments = clsPayment.GetAllPayments();
            dgvPaymentsList.DataSource = _dtPayments;
            lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();

            if (dgvPaymentsList.Rows.Count > 0)
            {
                dgvPaymentsList.Columns[0].HeaderText = "Payment ID";
                dgvPaymentsList.Columns[0].Width = 120;

                dgvPaymentsList.Columns[1].HeaderText = "Guest Name";
                dgvPaymentsList.Columns[1].Width = 350;

                dgvPaymentsList.Columns[2].HeaderText = "Booking ID";
                dgvPaymentsList.Columns[2].Width = 160;

                dgvPaymentsList.Columns[3].HeaderText = "Payment Date";
                dgvPaymentsList.Columns[3].Width = 180;

                dgvPaymentsList.Columns[4].HeaderText = "Amount";
                dgvPaymentsList.Columns[4].Width = 150;
            }
        }

        private int? _GetPaymentIDFromDGV()
        {
            return (int?)dgvPaymentsList.CurrentRow.Cells["PaymentID"].Value;
        }

        private void frmListPayments_Load(object sender, System.EventArgs e)
        {
            _RefreshPaymentsList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (_dtPayments.Rows.Count == 0)
                return;

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None")
            {
                _dtPayments.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text != "Guest Name")
            {
                // search with numbers
                _dtPayments.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtPayments.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text != "Guest Name")
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmsEditProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _UpdateContextMenu();
        }

        private void PrintInvoiceToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            if (PrintInvoiceToolStripMenuItem1.Text == "Print Invoice")
                _PrintInvoice();
            else
                _ShowInvoice();
        }

        private bool _AddNewInvoice(out int? InvoiceID)
        {
            InvoiceID = null;

            clsInvoice Invoice = new clsInvoice();
            Invoice.PaymentID = _GetPaymentIDFromDGV();

            if (!Invoice.Save())
                return false;

            InvoiceID = Invoice.InvoiceID;
            return true;
        }

        private void _PrintInvoice()
        {
            if (_AddNewInvoice(out int? NewInvoiceID))
            {
                _OpenPaymentInvoiceForm(_GetPaymentIDFromDGV(), NewInvoiceID);
            }
            else
            {
                MessageBox.Show("Cannot create an invoice! Please try again later.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _OpenPaymentInvoiceForm(int? PaymentID, int? NewInvoiceID)
        {
            frmPaymentInvoice PaymentInvoice = new frmPaymentInvoice(PaymentID, NewInvoiceID);
            PaymentInvoice.ShowDialog();
        }

        private void _ShowInvoice()
        {
            clsInvoice Invoice = clsInvoice.FindByPaymentID(_GetPaymentIDFromDGV());

            if (Invoice == null)
            {
                MessageBox.Show("Cannot show the invoice! Please try again later.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _OpenPaymentInvoiceForm(Invoice.PaymentID, Invoice.InvoiceID);
        }

        private void _UpdateContextMenu()
        {
            if (dgvPaymentsList.RowCount <= 0)
            {
                cmsEditProfile.Enabled = false;
                return;
            }

            PrintInvoiceToolStripMenuItem1.Text =
                (clsInvoice.DoesPaymentHaveAnInvoice(_GetPaymentIDFromDGV())) ?
                               "Show Invoice" : "Print Invoice";
        }
      
    }
}
