using Hotel.GlobalClasses;
using Hotel.OrderItems;
using Hotel.Properties;
using Hotel.RoomServices;
using Hotel_Business;
using System.Windows.Forms;

namespace Hotel.Orders.UserControls
{
    public partial class ucOrderCard : UserControl
    {
        private int? _OrderID = null;
        private clsOrder _Order = null;

        public int? OrderID => _OrderID;
        public clsOrder OrderInfo => _Order;

        public ucOrderCard()
        {
            InitializeComponent();
        }

        private void _FillOrderData()
        {
            llShowRoomServiceInfo.Visible = (_Order.OrderType == clsOrder.enOrderType.RoomService);
            llShowOrderItemsInfo.Visible = (_Order.OrderType == clsOrder.enOrderType.Dining);

            lblOrderID.Text = _Order.OrderID.ToString();
            lblOrderedBy.Text = _Order.GuestInfo.PersonInfo.FullName;
            lblRoomNumber.Text = _Order.RoomInfo.RoomNumber.ToString();
            lblOrderDate.Text = clsFormat.DateToShort(_Order.OrderDate);
            lblOrderType.Text = _Order.OrderTypeName;
            lblBookingID.Text = _Order.BookingID.ToString();
            lblPaymentID.Text = _Order.PaymentID.ToString();
            lblAmountPaid.Text = _Order.Fees.ToString("C");
            lblCreatedByUser.Text = _Order.CreatedByUserInfo.Username;

            pbGender.Image = (_Order.GuestInfo.PersonInfo.Gender == clsPerson.enGender.Male) ?
                              Resources.gender_male : Resources.gender_female;
        }

        public void Reset()
        {
            _OrderID = null;
            _Order = null;

            llShowOrderItemsInfo.Visible = false;
            llShowRoomServiceInfo.Visible = false;

            lblOrderID.Text = "[????]";
            lblRoomNumber.Text = "[????]";
            lblOrderType.Text = "[????]";
            lblOrderDate.Text = "[????]";
            lblOrderedBy.Text = "[????]";
            lblBookingID.Text = "[????]";
            lblPaymentID.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblAmountPaid.Text = "[????]";

            pbGender.Image = Resources.gender_male;
        }

        public void LoadOrderInfo(int? OrderID)
        {
            _OrderID = OrderID;

            if (!_OrderID.HasValue)
            {
                MessageBox.Show("There is no Order!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Order = clsOrder.Find(_OrderID);

            if (_Order == null)
            {
                MessageBox.Show($"There is no Order with ID = {_OrderID} !",
                    "Missing Order", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillOrderData();
        }

        private void llShowRoomServiceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowRoomServiceInfo ShowRoomServiceInfo = new frmShowRoomServiceInfo(_Order.RoomServiceID);
            ShowRoomServiceInfo.ShowDialog();
        }

        private void llShowOrderItemsInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowOrderItemsInfo ShowOrderItemsInfo = new frmShowOrderItemsInfo(_Order.OrderID);
            ShowOrderItemsInfo.ShowDialog();
        }
    }
}
