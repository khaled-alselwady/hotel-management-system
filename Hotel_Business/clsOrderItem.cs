using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsOrderItem
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? OrderItemID { get; set; }
        public int? OrderID { get; set; }
        public int? ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }
        public decimal TotalItemsPrice { get; set; }

        public clsOrder OrderInfo { get; }
        public clsItem ItemInfo { get; }

        public clsOrderItem()
        {
            this.OrderItemID = null;
            this.OrderID = null;
            this.ItemID = null;
            this.Quantity = -1;
            this.PricePerItem = -1M;
            this.TotalItemsPrice = -1M;

            Mode = enMode.AddNew;
        }

        private clsOrderItem(int? OrderItemID, int? OrderID, int? ItemID, int Quantity,
            decimal PricePerItem, decimal TotalItemsPrice)
        {
            this.OrderItemID = OrderItemID;
            this.OrderID = OrderID;
            this.ItemID = ItemID;
            this.Quantity = Quantity;
            this.PricePerItem = PricePerItem;
            this.TotalItemsPrice = TotalItemsPrice;

            this.OrderInfo = clsOrder.Find(OrderID);
            this.ItemInfo = clsItem.Find(ItemID);

            Mode = enMode.Update;
        }

        private bool _AddNewOrderItem()
        {
            this.OrderItemID = clsOrderItemData.AddNewOrderItem(this.OrderID, this.ItemID,
                this.Quantity, this.PricePerItem);

            return (this.OrderItemID.HasValue);
        }

        private bool _UpdateOrderItem()
        {
            return clsOrderItemData.UpdateOrderItem(this.OrderItemID, this.OrderID, this.ItemID,
                this.Quantity, this.PricePerItem);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrderItem())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateOrderItem();
            }

            return false;
        }

        public static clsOrderItem Find(int? OrderItemID)
        {
            int? OrderID = null;
            int? ItemID = null;
            int Quantity = -1;
            decimal PricePerItem = -1M;
            decimal TotalItemsPrice = -1M;

            bool IsFound = clsOrderItemData.GetOrderItemInfoByID(OrderItemID, ref OrderID, ref ItemID, ref Quantity, ref PricePerItem, ref TotalItemsPrice);

            return IsFound ? new clsOrderItem(OrderItemID, OrderID, ItemID, Quantity, PricePerItem, TotalItemsPrice) : null;
        }

        public static bool DeleteOrderItem(int? OrderItemID)
        {
            return clsOrderItemData.DeleteOrderItem(OrderItemID);
        }

        public static bool DoesOrderItemExist(int? OrderItemID)
        {
            return clsOrderItemData.DoesOrderItemExist(OrderItemID);
        }

        public static DataTable GetAllOrderItems()
        {
            return clsOrderItemData.GetAllOrderItems();
        }

        public static DataTable GetAllOrderItemsByOrderID(int? OrderID)
        {
            return clsOrderItemData.GetAllOrderItemsByOrderID(OrderID);
        }

    }

}