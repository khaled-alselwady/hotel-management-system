using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsReservation
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enReservationStatus
        {
            Pending = 0,
            Confirmed = 1,
            Canceled = 2,
            Invalid = 3
        }

        public int? ReservationID { get; set; }
        public int? PersonID { get; set; }
        public int? RoomID { get; set; }
        public DateTime ReservedForDate { get; set; }
        public byte NumberOfPeople { get; set; }
        public enReservationStatus ReservationStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual int? CreatedByUserID { get; set; }

        public string ReservationStatusName => _ReservationStatusName(this.ReservationStatus);
        public bool IsCheckIn => IsReservationChecked(this.ReservationID);

        public clsPerson PersonInfo { get; }
        public clsRoom RoomInfo { get; }
        public clsUser CreatedByUserInfo { get; }

        public clsReservation()
        {
            this.ReservationID = null;
            this.PersonID = null;
            this.RoomID = null;
            this.ReservedForDate = DateTime.Now;
            this.NumberOfPeople = 0;
            this.ReservationStatus = enReservationStatus.Pending;
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = null;

            this.Mode = enMode.AddNew;
        }

        private clsReservation(int? ReservationID, int? PersonID, int? RoomID,
            DateTime ReservedForDate, byte NumberOfPeople, enReservationStatus Status,
            DateTime CreatedDate, int? CreatedByUserID)
        {
            this.ReservationID = ReservationID;
            this.PersonID = PersonID;
            this.RoomID = RoomID;
            this.ReservedForDate = ReservedForDate;
            this.NumberOfPeople = NumberOfPeople;
            this.ReservationStatus = Status;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;

            this.PersonInfo = clsPerson.Find(PersonID);
            this.RoomInfo = clsRoom.FindByRoomID(RoomID);
            this.CreatedByUserInfo = clsUser.FindBy(CreatedByUserID, clsUser.enFindBy.UserID);

            this.Mode = enMode.Update;
        }

        private bool _AddNewReservation()
        {
            this.ReservationID = clsReservationData.AddNewReservation(this.PersonID,
                this.RoomID, this.ReservedForDate, this.NumberOfPeople, this.CreatedByUserID);


            return (this.ReservationID.HasValue);
        }

        private bool _UpdateReservation()
        {
            return clsReservationData.UpdateReservation(this.ReservationID,
                this.PersonID, this.RoomID, this.ReservedForDate, this.NumberOfPeople,
                this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReservation())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateReservation();
            }

            return false;
        }

        public static clsReservation Find(int? ReservationID)
        {
            int? PersonID = null;
            int? RoomID = null;
            DateTime ReservedForDate = DateTime.Now;
            byte NumberOfPeople = 0;
            byte Status = 0;
            DateTime CreatedDate = DateTime.Now;
            int? CreatedByUserID = null;

            bool IsFound = clsReservationData.GetReservationInfoByID(ReservationID,
                ref PersonID, ref RoomID, ref ReservedForDate, ref NumberOfPeople,
                ref Status, ref CreatedDate, ref CreatedByUserID);

            return IsFound ?
                 new clsReservation(ReservationID, PersonID, RoomID,
                ReservedForDate, NumberOfPeople, (enReservationStatus)Status,
                CreatedDate, CreatedByUserID)
                 :
                 null;
        }

        public static bool DeleteReservation(int? ReservationID)
        {
            return clsReservationData.DeleteReservation(ReservationID);
        }

        public static bool DoesReservationExist(int? ReservationID)
        {
            return clsReservationData.DoesReservationExist(ReservationID);
        }

        public static DataTable GetAllReservations()
        {
            return clsReservationData.GetAllReservations();
        }

        public static int Count()
        {
            return clsReservationData.GetReservationsCount();
        }

        private string _ReservationStatusName(enReservationStatus ReservationStatus)
        {
            switch (ReservationStatus)
            {
                case enReservationStatus.Pending:
                    return "Pending";

                case enReservationStatus.Confirmed:
                    return "Confirmed";

                case enReservationStatus.Canceled:
                    return "Canceled";

                case enReservationStatus.Invalid:
                    return "Invalid";

                default:
                    return "Unknown";
            }
        }

        public static bool IsRoomReserved(int? RoomNumber, DateTime ReservedDate)
        {
            return clsReservationData.IsRoomReserved(RoomNumber, ReservedDate);
        }

        public static bool IsReservationChecked(int? ReservationID)
        {
            return clsBooking.IsReservationChecked(ReservationID);
        }

        public static bool SetStatus(int? ReservationID, enReservationStatus NewStatus)
        {
            return clsReservationData.SetStatus(ReservationID, (byte)NewStatus);
        }

        public bool SetStatus(enReservationStatus NewStatus)
        {
            return SetStatus(this.ReservationID, NewStatus);
        }

        public static bool CheckIn(int? ReservationID, int? CreatedByUserIDForBooking)
        {
            clsBooking Booking = new clsBooking();

            Booking.ReservationID = ReservationID;
            Booking.CreatedByUserID = CreatedByUserIDForBooking;

            return Booking.CheckIn();
        }
    }

}