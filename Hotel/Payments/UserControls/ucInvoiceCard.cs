using Hotel.GlobalClasses;
using Hotel_Business;
using System.Windows.Forms;

namespace Hotel.Payments.UserControls
{
    public partial class ucInvoiceCard : UserControl
    {
        private int? _InvoiceID = null;
        private clsInvoice _Invoice = null;

        public int? InvoiceID => _InvoiceID;
        public clsInvoice InvoiceInfo => _Invoice;

        public ucInvoiceCard()
        {
            InitializeComponent();
        }

        private bool _DoesInvoiceExist(int? InvoiceID)
        {
            if (!InvoiceID.HasValue)
            {
                MessageBox.Show("There is no Invoice!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return false;
            }

            _Invoice = clsInvoice.FindByInvoiceID(InvoiceID);

            if (_Invoice == null)
            {
                MessageBox.Show($"There is no Invoice with ID = {InvoiceID} !",
                    "Missing Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return false;
            }

            return true;
        }

        private void _FillInvoiceData()
        {
            lblInvoiceID.Text = _Invoice.InvoiceID.ToString();

            lblInvoiceDate.Text = clsFormat.DateToShort(_Invoice.InvoiceDate) + " (" 
                + _Invoice.InvoiceDate.ToString("HH:mm:ss tt") + ")";
        }

        public void Reset()
        {
            _InvoiceID = null;
            _Invoice = null;
            
            lblInvoiceID.Text = "[????]";
            lblInvoiceDate.Text = "[????]";
        }

        public void LoadInvoiceInfo(int? InvoiceID)
        {
            _InvoiceID = InvoiceID;

            if (!_DoesInvoiceExist(InvoiceID))
                return;

            _FillInvoiceData();
        }

    }
}
