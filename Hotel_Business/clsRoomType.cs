using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsRoomType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? RoomTypeID { get; set; }
        public string RoomTypeTitle { get; set; }
        public byte Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }

        public clsRoomType()
        {
            this.RoomTypeID = null;
            this.RoomTypeTitle = string.Empty;
            this.Capacity = 0;
            this.PricePerNight = -1M;
            this.Description = null;
            Mode = enMode.AddNew;
        }

        private clsRoomType(int? RoomTypeID, string RoomTypeTitle, byte Capacity, decimal PricePerNight, string Description)
        {
            this.RoomTypeID = RoomTypeID;
            this.RoomTypeTitle = RoomTypeTitle;
            this.Capacity = Capacity;
            this.PricePerNight = PricePerNight;
            this.Description = Description;
            Mode = enMode.Update;
        }

        private bool _AddNewRoomType()
        {
            this.RoomTypeID = clsRoomTypeData.AddNewRoomType(this.RoomTypeTitle, this.Capacity, this.PricePerNight, this.Description);

            return (this.RoomTypeID.HasValue);
        }

        private bool _UpdateRoomType()
        {
            return clsRoomTypeData.UpdateRoomType(this.RoomTypeID, this.RoomTypeTitle, this.Capacity, this.PricePerNight, this.Description);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoomType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateRoomType();
            }

            return false;
        }

        public static clsRoomType Find(int? RoomTypeID)
        {
            string RoomTypeTitle = string.Empty;
            byte Capacity = 0;
            decimal PricePerNight = -1M;
            string Description = null;

            bool IsFound = clsRoomTypeData.GetRoomTypeInfoByID(RoomTypeID, ref RoomTypeTitle, ref Capacity, ref PricePerNight, ref Description);

            return (IsFound) ? (new clsRoomType(RoomTypeID, RoomTypeTitle, Capacity, PricePerNight, Description)) : null;
        }

        public static bool DeleteRoomType(int? RoomTypeID)
        {
            return clsRoomTypeData.DeleteRoomType(RoomTypeID);
        }

        public static bool DoesRoomTypeExist(int? RoomTypeID)
        {
            return clsRoomTypeData.DoesRoomTypeExist(RoomTypeID);
        }

        public static DataTable GetAllRoomTypes()
        {
            return clsRoomTypeData.GetAllRoomTypes();
        }

    }

}