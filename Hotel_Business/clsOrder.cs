using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsOrder
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enOrderType { RoomService = 0, Dining = 1 }

        public int? OrderID { get; set; }
        public int? BookingID { get; set; }
        public int? GuestID { get; set; }
        public int? RoomID { get; set; }
        public short? RoomServiceID { get; set; }
        public enOrderType OrderType { get; set; }
        public decimal Fees { get; set; }
        public DateTime OrderDate { get; set; }
        public int? PaymentID { get; set; }
        public int? CreatedByUserID { get; set; }

        public clsBooking BookingInfo { get; }
        public clsGuest GuestInfo { get; }
        public clsRoom RoomInfo { get; }
        public clsUser CreatedByUserInfo { get; }

        public string OrderTypeName => _GetOrderTypeName(this.OrderType);

        public clsOrder()
        {
            this.OrderID = null;
            this.BookingID = null;
            this.GuestID = null;
            this.RoomID = null;
            this.OrderType = 0;
            this.Fees = -1M;
            this.OrderDate = DateTime.Now;
            this.PaymentID = null;
            this.CreatedByUserID = null;

            Mode = enMode.AddNew;
        }

        private clsOrder(int? OrderID, int? BookingID, int? GuestID, int? RoomID, short? RoomServiceID,
            enOrderType OrderType, decimal Fees, DateTime OrderDate, int? PaymentID, int? CreatedByUserID)
        {
            this.OrderID = OrderID;
            this.BookingID = BookingID;
            this.GuestID = GuestID;
            this.RoomID = RoomID;
            this.RoomServiceID = RoomServiceID;
            this.OrderType = OrderType;
            this.Fees = Fees;
            this.OrderDate = OrderDate;
            this.PaymentID = PaymentID;
            this.CreatedByUserID = CreatedByUserID;

            this.BookingInfo = clsBooking.Find(BookingID);
            this.GuestInfo = clsGuest.FindByGuestID(GuestID);
            this.RoomInfo = clsRoom.FindByRoomID(RoomID);
            this.CreatedByUserInfo = clsUser.FindBy(CreatedByUserID, clsUser.enFindBy.UserID);

            Mode = enMode.Update;
        }

        private bool _AddNewOrder()
        {
            this.OrderID = clsOrderData.AddNewOrder(this.BookingID, this.GuestID,
                this.RoomID, this.RoomServiceID, (byte)this.OrderType, this.Fees,
                this.CreatedByUserID);

            return (this.OrderID.HasValue);
        }

        private bool _UpdateOrder()
        {
            return clsOrderData.UpdateOrder(this.OrderID, this.BookingID,
                this.GuestID, this.RoomID, this.RoomServiceID, (byte)this.OrderType,
                this.Fees, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateOrder();
            }

            return false;
        }

        public static clsOrder Find(int? OrderID)
        {
            int? BookingID = null;
            int? GuestID = null;
            int? RoomID = null;
            short? RoomServiceID = null;
            byte OrderType = 0;
            decimal Fees = -1M;
            DateTime OrderDate = DateTime.Now;
            int? PaymentID = null;
            int? CreatedByUserID = null;

            bool IsFound = clsOrderData.GetOrderInfoByID(OrderID, ref BookingID, ref GuestID, ref RoomID,
                           ref RoomServiceID, ref OrderType, ref Fees, ref OrderDate,
                           ref PaymentID, ref CreatedByUserID);

            return (IsFound) ? (new clsOrder(OrderID, BookingID, GuestID, RoomID, RoomServiceID,
                               (enOrderType)OrderType, Fees, OrderDate, PaymentID, CreatedByUserID))
                               : null;
        }

        public static bool DeleteOrder(int? OrderID)
        {
            return clsOrderData.DeleteOrder(OrderID);
        }

        public static bool DoesOrderExist(int? OrderID)
        {
            return clsOrderData.DoesOrderExist(OrderID);
        }

        public static DataTable GetAllOrders()
        {
            return clsOrderData.GetAllOrders();
        }

        private static string _GetOrderTypeName(enOrderType OrderType)
        {
            switch (OrderType)
            {
                case enOrderType.RoomService:
                    return "Room Service";

                case enOrderType.Dining:
                    return "Dining";

                default:
                    return "Unknown";
            }
        }

    }


}