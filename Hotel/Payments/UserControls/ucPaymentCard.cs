using Hotel.GlobalClasses;
using Hotel_Business;
using System.Windows.Forms;

namespace Hotel.Payments.UserControls
{
    public partial class ucPaymentCard : UserControl
    {
        private int? _PaymentID = null;
        private clsPayment _Payment = null;

        public int? PaymentID => _PaymentID;
        public clsPayment PaymentInfo => _Payment;

        public ucPaymentCard()
        {
            InitializeComponent();
        }

        private bool _DoesPaymentExist(int? PaymentID)
        {
            if (!PaymentID.HasValue)
            {
                MessageBox.Show("There is no Payment!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return false;
            }

            _Payment = clsPayment.Find(PaymentID);

            if (_Payment == null)
            {
                MessageBox.Show($"There is no Payment with ID = {PaymentID} !",
                    "Missing Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return false;
            }

            return true;
        }

        private void _FillPaymentData()
        {
            lblPaymentID.Text = _Payment.PaymentID.ToString();
            lblGuestName.Text = _Payment.GuestInfo.PersonInfo.FullName;
            lblPhone.Text = _Payment.GuestInfo.PersonInfo.Phone;
            lblEmail.Text = _Payment.GuestInfo.PersonInfo.Email ?? "N/A";
            lblAddress.Text = _Payment.GuestInfo.PersonInfo.Address;
            lblBookingID.Text = _Payment.BookingID.ToString();

            lblPaymentDate.Text = clsFormat.DateToShort(_Payment.PaymentDate) +
                " (" + _Payment.PaymentDate.ToString("HH:mm:ss tt") + ")";

            lblPaidAmount.Text = _Payment.PaymentAmount.ToString("C");
        }

        public void Reset()
        {
            _PaymentID = null;
            _Payment = null;

            lblGuestName.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblPaymentID.Text = "[????]";
            lblBookingID.Text = "[????]";
            lblPaymentDate.Text = "[????]";
            lblPaidAmount.Text = "[????]";
        }

        public void LoadPaymentInfo(int? PaymentID)
        {
            _PaymentID = PaymentID;

            if (!_DoesPaymentExist(PaymentID))
                return;

            _FillPaymentData();
        }

    }
}
