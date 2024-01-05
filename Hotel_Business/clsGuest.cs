using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Business
{
    public class clsGuest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? GuestID { get; set; }
        public int? PersonID { get; set; }
        public clsPerson PersonInfo { get; }

        public clsGuest()
        {
            this.GuestID = null;
            this.PersonID = null;

            Mode = enMode.AddNew;
        }

        private clsGuest(int? GuestID, int? PersonID)
        {
            this.GuestID = GuestID;
            this.PersonID = PersonID;

            this.PersonInfo = clsPerson.Find(PersonID);

            Mode = enMode.Update;
        }

        private bool _AddNewGuest()
        {
            this.GuestID = clsGuestData.AddNewGuest(this.PersonID);

            return (this.GuestID.HasValue);
        }

        private bool _UpdateGuest()
        {
            return clsGuestData.UpdateGuest(this.GuestID, this.PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGuest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateGuest();
            }

            return false;
        }

        public static clsGuest FindByGuestID(int? GuestID)
        {
            int? PersonID = null;

            bool IsFound = clsGuestData.GetGuestInfoByGuestID(GuestID, ref PersonID);

            if (IsFound)
            {
                return new clsGuest(GuestID, PersonID);
            }
            else
            {
                return null;
            }
        }

        public static clsGuest FindByPersonID(int? PersonID)
        {
            int? GuestID = null;

            bool IsFound = clsGuestData.GetGuestInfoByPersonID(PersonID, ref GuestID);

            if (IsFound)
            {
                return new clsGuest(GuestID, PersonID);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteGuest(int? GuestID)
        {
            return clsGuestData.DeleteGuest(GuestID);
        }

        public static bool DoesGuestExist(int? GuestID)
        {
            return clsGuestData.DoesGuestExist(GuestID);
        }

        public static DataTable GetAllGuests()
        {
            return clsGuestData.GetAllGuests();
        }

        public static int Count()
        {
            return clsGuestData.GetGuestsCount();
        }
    }

}
