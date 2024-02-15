using Hotel.GlobalClasses;
using Hotel.Items;
using Hotel.Items.UserControls;
using Hotel_Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static Hotel.Bookings.UserControls.ucBookingAndReservationCardWithFilter;

namespace Hotel.Orders
{
    public partial class frmAddNewOrder : Form
    {
        private clsOrder _Order = new clsOrder();

        private int? _ItemID = null;

        private List<ucItemShortCardWithQuantity> _SelectedItemCards =
            new List<ucItemShortCardWithQuantity>();

        private Dictionary<int?, ucItemShortCardWithQuantity> _AllItemCards =
            new Dictionary<int?, ucItemShortCardWithQuantity>();

        public frmAddNewOrder()
        {
            InitializeComponent();

            rbDining.Checked = true;
        }

        private void _StoreAllItemsInDictionary()
        {
            _AllItemCards.Clear();

            DataTable dtItems = clsItem.GetAllItems();

            foreach (DataRow Item in dtItems.Rows)
            {
                ucItemShortCardWithQuantity ItemShortCard = new ucItemShortCardWithQuantity();
                ItemShortCard.ItemID = (int?)Item["ItemID"];
                ItemShortCard.ItemName = (string)Item["ItemName"];
                ItemShortCard.ItemPrice = Convert.ToSingle(Item["ItemPrice"]);
                ItemShortCard.ItemImagePath = (Item["ItemImagePath"] != DBNull.Value) ? (string)Item["ItemImagePath"] : null;

                _AllItemCards.Add(ItemShortCard.ItemID, ItemShortCard);
            }
        }

        private void _RefreshItemList()
        {
            dgvList.DataSource = clsItem.GetAllItems();

            if (dgvList.Rows.Count > 0)
            {
                dgvList.Columns[0].HeaderText = "Item ID";
                dgvList.Columns[0].Width = 184;

                dgvList.Columns[1].HeaderText = "Item Name";
                dgvList.Columns[1].Width = 220;

                dgvList.Columns[2].HeaderText = "Item Type";
                dgvList.Columns[2].Width = 220;

                dgvList.Columns[3].HeaderText = "Item Price";
                dgvList.Columns[3].Width = 220;
            }
        }

        private void _RefreshRoomServicesList()
        {
            dgvList.DataSource = clsRoomService.GetAllRoomServices();

            if (dgvList.Rows.Count > 0)
            {
                dgvList.Columns[0].HeaderText = "Room Service ID";
                dgvList.Columns[0].Width = 160;

                dgvList.Columns[1].HeaderText = "Room Service Title";
                dgvList.Columns[1].Width = 200;

                dgvList.Columns[2].HeaderText = "Fees";
                dgvList.Columns[2].Width = 130;

                dgvList.Columns[3].HeaderText = "Description";
                dgvList.Columns[3].Width = 600;
            }
        }

        private void _ShowServiceRoomList()
        {
            _RefreshRoomServicesList();

            flowLayoutPanel1.Controls.Clear();
            _SelectedItemCards.Clear();
            _AllItemCards.Clear();
            lblTitleOfList.Text = "Room Services:";
            btnSelectedItem.Visible = false;
            lblSelectedItemsText.Visible = false;
            flowLayoutPanel1.Visible = false;
            ShowItemDetailsToolStripMenuItem1.Visible = false;
        }

        private void _ShowDiningList()
        {
            _StoreAllItemsInDictionary();

            _RefreshItemList();

            flowLayoutPanel1.Controls.Clear();
            _SelectedItemCards.Clear();
            lblTitleOfList.Text = "Dining Menu Items:";
            btnSelectedItem.Visible = true;
            lblSelectedItemsText.Visible = true;
            flowLayoutPanel1.Visible = true;
            ShowItemDetailsToolStripMenuItem1.Visible = true;
        }

        private void _Reset()
        {
            btnSave.Enabled = false;
            btnSelectedItem.Enabled = false;
            gbOrderType.Enabled = false;
            ucBookingAndReservationCardWithFilter1.FilterEnabled = false;
        }

        private void _SaveOrder()
        {
            if (_Order == null)
                return;

            if (!_Order.Save())
            {
                MessageBox.Show("Order Saved Failed!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Order Saved Successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            _Reset();
        }

        private void _SaveOrderForRoomService()
        {
            _Order.RoomServiceID = (short?)(int)dgvList.CurrentRow.Cells["RoomServiceID"].Value;
            _Order.OrderType = clsOrder.enOrderType.RoomService;
            _Order.Fees = (decimal)dgvList.CurrentRow.Cells["Fees"].Value;
            _Order.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            _SaveOrder();
        }

        private float _CalculateTotalItemPrice()
        {
            float Total = 0;

            _SelectedItemCards.ForEach(Item => Total += Item.TotalItemPrice);

            return Total;
        }

        private void _SaveOrderForDining()
        {
            _Order.OrderType = clsOrder.enOrderType.Dining;
            _Order.Fees = (decimal)_CalculateTotalItemPrice();
            _Order.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            _SaveOrder();
            _SaveItemsInOrderItemsTable_AndDisableChangeQuantityInItemCard();
        }

        private void _SaveItemsInOrderItemsTable_AndDisableChangeQuantityInItemCard()
        {
            _SelectedItemCards.ForEach((Item) =>
            {
                clsOrderItem OrderItem = new clsOrderItem();
                OrderItem.OrderID = _Order.OrderID;
                OrderItem.ItemID = Item.ItemID;
                OrderItem.Quantity = Item.ItemQuantity;
                OrderItem.PricePerItem = (decimal)Item.ItemPrice;

                OrderItem.Save();

                Item.DisableChangeQuantity();
            });
        }

        private bool _IsItemAlreadySelected()
        {
            if (_SelectedItemCards.Count > 0)
            {
                ucItemShortCardWithQuantity FindItemShortCardInSelectedList = _SelectedItemCards.Find(Item => Item.ItemID == _ItemID);

                if (FindItemShortCardInSelectedList != null)
                {
                    // The item has already been selected, so I just update the quantity
                    FindItemShortCardInSelectedList.ItemQuantity++;
                    return true;
                }
            }

            return false;
        }

        private void ucBookingAndReservationCardWithFilter1_OnBookingAndReservationSelected(object sender, BookingAndReservationSelectedEventArgs e)
        {
            if (!e.BookingID.HasValue || !e.ReservationID.HasValue)
            {
                btnNext.Enabled = false;
                btnSave.Enabled = false;
                return;
            }

            if (clsBooking.IsBookingCompleted(e.BookingID))
            {
                MessageBox.Show("This Booking has been completed, so you cannot request an order for it",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnNext.Enabled = false;
                btnSave.Enabled = false;
                return;
            }

            _Order.BookingID = e.BookingID;
            _Order.GuestID = ucBookingAndReservationCardWithFilter1.ReservationInfo.GuestID;
            _Order.RoomID = ucBookingAndReservationCardWithFilter1.ReservationInfo.RoomID;

            btnNext.Enabled = true;
            btnSave.Enabled = true;
        }

        private void rbDining_CheckedChanged(object sender, System.EventArgs e)
        {
            _ShowDiningList();
        }

        private void rbRoomService_CheckedChanged(object sender, System.EventArgs e)
        {
            _ShowServiceRoomList();
        }

        private void dgvList_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvList.SelectedRows[0];
                _ItemID = (int?)selectedRow.Cells[0].Value;
            }
        }

        private void btnSelectedItem_Click(object sender, System.EventArgs e)
        {
            if (_ItemID == null)
                return;

            if (_AllItemCards.TryGetValue(_ItemID, out ucItemShortCardWithQuantity ItemShortCardWithQuantity))
            {
                if (_IsItemAlreadySelected())
                    return;

                flowLayoutPanel1.Controls.Add(ItemShortCardWithQuantity);
                _SelectedItemCards.Add(ItemShortCardWithQuantity);
            }
        }

        private void frmAddNewOrder_Activated(object sender, System.EventArgs e)
        {
            ucBookingAndReservationCardWithFilter1.FilterFocus();
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            tcAddNewOrder.SelectedTab = tcAddNewOrder.TabPages["tpOrderInfo"];
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if ((rbRoomService.Checked && dgvList.SelectedRows.Count <= 0) ||
                (rbDining.Checked && _SelectedItemCards.Count == 0))
            {
                MessageBox.Show("You have to select one element at least!", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (rbRoomService.Checked)
                _SaveOrderForRoomService();
            else
                _SaveOrderForDining();
        }

        private void ShowItemDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowItemInfo ShowItemInfo = new frmShowItemInfo(_ItemID, false);
            ShowItemInfo.ShowDialog();
        }
    }
}
