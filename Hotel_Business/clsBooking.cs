using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsBooking : clsReservation
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enBookingStatus { Ongoing = 0, Completed = 1 }

        public int? BookingID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public enBookingStatus BookingStatus { get; set; }
        public override int? CreatedByUserID { get; set; }

        public clsBooking()
        {
            this.BookingID = null;
            this.CheckInDate = DateTime.Now;
            this.CheckOutDate = null;
            this.BookingStatus = enBookingStatus.Ongoing;
            this.CreatedByUserID = null;

            Mode = enMode.AddNew;
        }

        private clsBooking(int? BookingID, DateTime CheckInDate,
            DateTime? CheckOutDate, enBookingStatus BookingStatus, int? CreatedByUserIDForBooking,
            int? ReservationID, int? PersonID, int? RoomID, DateTime ReservedForDate,
             byte NumberOfPeople, enReservationStatus ReservationStatus, DateTime CreatedDate,
              int? CreatedByUserIDForReservation)

        {
            base.ReservationID = ReservationID;
            base.PersonID = PersonID;
            base.RoomID = RoomID;
            base.ReservedForDate = ReservedForDate;
            base.NumberOfPeople = NumberOfPeople;
            base.ReservationStatus = ReservationStatus;
            base.CreatedDate = CreatedDate;
            base.CreatedByUserID = CreatedByUserIDForReservation;

            this.BookingID = BookingID;
            this.CheckInDate = CheckInDate;
            this.CheckOutDate = CheckOutDate;
            this.BookingStatus = BookingStatus;
            this.CreatedByUserID = CreatedByUserIDForBooking;

            Mode = enMode.Update;
        }

        private bool _AddNewBooking()
        {
            this.BookingID = clsBookingData.AddNewBooking(this.ReservationID,
                this.CheckOutDate, this.CreatedByUserID);

            return (this.BookingID.HasValue);
        }

        private bool _UpdateBooking()
        {
            return clsBookingData.UpdateBooking(this.BookingID, this.ReservationID, this.CheckInDate,
                this.CheckOutDate, (byte)this.BookingStatus, this.CreatedByUserID);
        }

        public bool Save()
        {
            base.Mode = (clsReservation.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBooking())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBooking();
            }

            return false;
        }

        public static clsBooking Find(int? BookingID)
        {
            int? ReservationID = null;
            DateTime CheckInDate = DateTime.Now;
            DateTime? CheckOutDate = null;
            byte Status = 0;
            int? CreatedByUserID = null;

            bool IsFound = clsBookingData.GetBookingInfoByID(BookingID, ref ReservationID,
                ref CheckInDate, ref CheckOutDate, ref Status, ref CreatedByUserID);

            if (IsFound)
            {
                clsReservation CurrentReservation = clsReservation.Find(ReservationID);

                if (CurrentReservation == null)
                    return null;

                return new clsBooking(BookingID, CheckInDate, CheckOutDate, (enBookingStatus)Status,
                    CreatedByUserID, CurrentReservation.ReservationID, CurrentReservation.PersonID,
                    CurrentReservation.RoomID, CurrentReservation.ReservedForDate,
                    CurrentReservation.NumberOfPeople, CurrentReservation.ReservationStatus,
                    CurrentReservation.CreatedDate, CurrentReservation.CreatedByUserID);
            }
            else
                return null;
        }

        public static bool DeleteBooking(int? BookingID)
        {
            return clsBookingData.DeleteBooking(BookingID);
        }

        public static bool DoesBookingExist(int? BookingID)
        {
            return clsBookingData.DoesBookingExist(BookingID);
        }

        public static DataTable GetAllBookings()
        {
            return clsBookingData.GetAllBookings();
        }

        public static new int Count()
        {
            return clsBookingData.GetBookingsCount();
        }

        public static bool IsReservationChecked(int? ReservationID)
        {
            return clsBookingData.IsReservationChecked(ReservationID);
        }

        public bool CheckIn()
        {
            return _AddNewBooking();
        }
    }

}