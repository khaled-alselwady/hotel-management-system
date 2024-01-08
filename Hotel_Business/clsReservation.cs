using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsReservation
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ReservationID { get; set; }
        public int PersonID { get; set; }
        public int RoomID { get; set; }
        public DateTime ReservedForDate { get; set; }
        public byte NumberOfPeople { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }

        public clsReservation()
        {
            this.ReservationID = null;
            this.PersonID = -1;
            this.RoomID = -1;
            this.ReservedForDate = DateTime.Now;
            this.NumberOfPeople = 0;
            this.Status = 0;
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private clsReservation(int? ReservationID, int PersonID, int RoomID, DateTime ReservedForDate, byte NumberOfPeople, byte Status, DateTime CreatedDate, int CreatedByUserID)
        {
            this.ReservationID = ReservationID;
            this.PersonID = PersonID;
            this.RoomID = RoomID;
            this.ReservedForDate = ReservedForDate;
            this.NumberOfPeople = NumberOfPeople;
            this.Status = Status;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }

        private bool _AddNewReservation()
        {
            this.ReservationID = clsReservationData.AddNewReservation(this.PersonID, this.RoomID, this.ReservedForDate, this.NumberOfPeople, this.Status, this.CreatedDate, this.CreatedByUserID);

            return (this.ReservationID.HasValue);
        }

        private bool _UpdateReservation()
        {
            return clsReservationData.UpdateReservation(this.ReservationID, this.PersonID, this.RoomID, this.ReservedForDate, this.NumberOfPeople, this.Status, this.CreatedDate, this.CreatedByUserID);
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
            int PersonID = -1;
            int RoomID = -1;
            DateTime ReservedForDate = DateTime.Now;
            byte NumberOfPeople = 0;
            byte Status = 0;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = -1;

            bool IsFound = clsReservationData.GetReservationInfoByID(ReservationID, ref PersonID, ref RoomID, ref ReservedForDate, ref NumberOfPeople, ref Status, ref CreatedDate, ref CreatedByUserID);

            return IsFound
                ? new clsReservation(ReservationID, PersonID, RoomID, ReservedForDate, NumberOfPeople, Status, CreatedDate, CreatedByUserID)
                : null;
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
    }

}