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
        public int? PersonID { get; set; }
        public int? GuestID { get; set; }

        public clsPerson PersonInfo { get; }
        public clsGuest GuestInfo { get; }

        public clsGuestCompanion()
        {
            this.GuestCompanionID = null;
            this.PersonID = null;
            this.GuestID = null;

            Mode = enMode.AddNew;
        }

        private clsGuestCompanion(int? GuestCompanionID, int? PersonID, int? GuestID)
        {
            this.GuestCompanionID = GuestCompanionID;
            this.PersonID = PersonID;
            this.GuestID = GuestID;

            this.PersonInfo = clsPerson.Find(PersonID);
            this.GuestInfo = clsGuest.FindByGuestID(GuestID);

            Mode = enMode.Update;
        }

        private bool _AddNewGuestCompanion()
        {
            this.GuestCompanionID = clsGuestCompanionData.AddNewGuestCompanion(this.PersonID, this.GuestID);

            return (this.GuestCompanionID.HasValue);
        }

        private bool _UpdateGuestCompanion()
        {
            return clsGuestCompanionData.UpdateGuestCompanion(this.GuestCompanionID, this.PersonID, this.GuestID);
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
            int? PersonID = null;
            int? GuestID = null;

            bool IsFound = clsGuestCompanionData.GetGuestCompanionInfoByID(GuestCompanionID, ref PersonID, ref GuestID);

            return (IsFound) ? (new clsGuestCompanion(GuestCompanionID, PersonID, GuestID)) : null;
        }

        public static bool DeleteGuestCompanion(int? GuestCompanionID)
        {
            return clsGuestCompanionData.DeleteGuestCompanion(GuestCompanionID);
        }

        public static bool DoesGuestCompanionExistByGuestCompanionID(int? GuestCompanionID)
        {
            return clsGuestCompanionData.DoesGuestCompanionExistByGuestCompanionID(GuestCompanionID);
        }

        public static bool DoesGuestCompanionExistByPersonID(int? PersonID)
        {
            return clsGuestCompanionData.DoesGuestCompanionExistByPersonID(PersonID);
        }

        public static DataTable GetAllGuestCompanions()
        {
            return clsGuestCompanionData.GetAllGuestCompanions();
        }

        public static DataTable GetAllGuestCompanionsForGuest(int? GuestID)
        {
            return clsGuestCompanionData.GetAllGuestCompanionsForGuest(GuestID);
        }

        public static int GetAllGuestCompanionsForGuestCount(int? GuestID)
        {
            return clsGuestCompanionData.GetAllGuestCompanionsForGuestCount(GuestID);
        }

    }
}
