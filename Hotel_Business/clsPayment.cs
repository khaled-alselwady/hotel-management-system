using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsPayment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public int? GuestID { get; }
        public int? BookingID { get; }

        public clsGuest GuestInfo { get; }
        public clsBooking BookingInfo { get; }

        public clsPayment()
        {
            this.PaymentID = null;
            this.BookingID = null;
            this.GuestID = null;
            this.PaymentDate = DateTime.Now;
            this.PaymentAmount = -1M;
            this.Mode = enMode.AddNew;
        }

        private clsPayment(int? PaymentID,DateTime PaymentDate,
             decimal PaymentAmount, int? GuestID, int? BookingID)
        {
            this.PaymentID = PaymentID;
            this.PaymentDate = PaymentDate;
            this.PaymentAmount = PaymentAmount;
            this.GuestID = GuestID;
            this.BookingID = BookingID;

            this.GuestInfo = clsGuest.FindByGuestID(GuestID);
            this.BookingInfo = clsBooking.Find(BookingID);

            this.Mode = enMode.Update;
        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(this.PaymentAmount);

            return (this.PaymentID.HasValue);
        }

        private bool _UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(this.PaymentID, this.PaymentAmount);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePayment();
            }

            return false;
        }

        public static clsPayment Find(int? PaymentID)
        {
            DateTime PaymentDate = DateTime.Now;
            decimal PaymentAmount = -1M;
            int? GuestID = null;
            int? BookingID = null;

            bool IsFoundPaymentID = clsPaymentData.GetPaymentInfoByID(PaymentID,
                ref PaymentDate, ref PaymentAmount);

            bool IsFoundGuestIDAndBookingID = clsPaymentData.GetGuestIDAndBookingIDByPaymentID(PaymentID,
                ref GuestID, ref BookingID);

            return IsFoundPaymentID && IsFoundGuestIDAndBookingID ?
                   new clsPayment(PaymentID, PaymentDate, PaymentAmount, GuestID, BookingID) :
                   null;
        }

        public static bool DeletePayment(int? PaymentID)
        {
            return clsPaymentData.DeletePayment(PaymentID);
        }

        public static bool DoesPaymentExist(int? PaymentID)
        {
            return clsPaymentData.DoesPaymentExist(PaymentID);
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentData.GetAllPayments();
        }

        public static int Count()
        {
            return clsPaymentData.GetPaymentsCount();
        }

        public static bool GetGuestIDAndBookingIDByPaymentID(int? PaymentID, ref int? GuestID, ref int? BookingID)
        {
            return clsPaymentData.GetGuestIDAndBookingIDByPaymentID(PaymentID, ref GuestID, ref BookingID);
        }
    }

}