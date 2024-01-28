using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Business
{
    public class clsGuestCompanion
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? GuestCompanionID { get; set; }
        public int PersonID { get; set; }
        public int BookingID { get; set; }

        public clsGuestCompanion()
        {
            this.GuestCompanionID = null;
            this.PersonID = -1;
            this.BookingID = -1;

            Mode = enMode.AddNew;
        }

        private clsGuestCompanion(int? GuestCompanionID, int PersonID, int BookingID)
        {
            this.GuestCompanionID = GuestCompanionID;
            this.PersonID = PersonID;
            this.BookingID = BookingID;

            Mode = enMode.Update;
        }

        private bool _AddNewGuestCompanion()
        {
            this.GuestCompanionID = clsGuestCompanionData.AddNewGuestCompanion(this.PersonID, this.BookingID);

            return (this.GuestCompanionID.HasValue);
        }

        private bool _UpdateGuestCompanion()
        {
            return clsGuestCompanionData.UpdateGuestCompanion(this.GuestCompanionID, this.PersonID, this.BookingID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGuestCompanion())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateGuestCompanion();
            }

            return false;
        }

        public static clsGuestCompanion Find(int? GuestCompanionID)
        {
            int PersonID = -1;
            int BookingID = -1;

            bool IsFound = clsGuestCompanionData.GetGuestCompanionInfoByID(GuestCompanionID, ref PersonID, ref BookingID);

            return (IsFound) ? (new clsGuestCompanion(GuestCompanionID, PersonID, BookingID)) : null;
        }

        public static bool DeleteGuestCompanion(int? GuestCompanionID)
        {
            return clsGuestCompanionData.DeleteGuestCompanion(GuestCompanionID);
        }

        public static bool DoesGuestCompanionExist(int? GuestCompanionID)
        {
            return clsGuestCompanionData.DoesGuestCompanionExist(GuestCompanionID);
        }

        public static DataTable GetAllGuestCompanions()
        {
            return clsGuestCompanionData.GetAllGuestCompanions();
        }

    }
}
