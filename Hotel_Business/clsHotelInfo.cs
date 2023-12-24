using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsHotelInfo
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? HotelInfoID { get; set; }
        public string HotelName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public clsHotelInfo()
        {
            this.HotelInfoID = null;
            this.HotelName = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;
            Mode = enMode.AddNew;
        }

        private clsHotelInfo(int? HotelInfoID, string HotelName, string Phone, string Email, 
            string Address)
        {
            this.HotelInfoID = HotelInfoID;
            this.HotelName = HotelName;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            Mode = enMode.Update;
        }

        private bool _AddNewHotelInfo()
        {
            this.HotelInfoID = clsHotelInfoData.AddNewHotelInfo(this.HotelName, this.Phone, 
                this.Email, this.Address);

            return (this.HotelInfoID.HasValue);
        }

        private bool _UpdateHotelInfo()
        {
            return clsHotelInfoData.UpdateHotelInfo(this.HotelInfoID, this.HotelName, 
                this.Phone, this.Email, this.Address);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewHotelInfo())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateHotelInfo();
            }

            return false;
        }

        public static clsHotelInfo Find(int? HotelInfoID)
        {
            string HotelName = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            string Address = string.Empty;

            bool IsFound = clsHotelInfoData.GetHotelInfoInfoByID(HotelInfoID, ref HotelName, ref Phone, ref Email, ref Address);

            if (IsFound)
            {
                return new clsHotelInfo(HotelInfoID, HotelName, Phone, Email, Address);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteHotelInfo(int? HotelInfoID)
        {
            return clsHotelInfoData.DeleteHotelInfo(HotelInfoID);
        }

        public static bool DoesHotelInfoExist(int? HotelInfoID)
        {
            return clsHotelInfoData.DoesHotelInfoExist(HotelInfoID);
        }

        public static DataTable GetAllHotelInfo()
        {
            return clsHotelInfoData.GetAllHotelInfo();
        }

    }

}