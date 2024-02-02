using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsRoom
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enRoomStatus
        {
            Available = 0,
            Booked = 1,
            UnderMaintenance = 2
        }

        public enum enRoomTypes
        {
            Single = 1,
            Double = 2,
            DeluxeSuite = 3,
            FamilyRoom = 4
        }

        public int? RoomID { get; set; }
        public enRoomTypes RoomTypeID { get; set; }
        public int RoomNumber { get; set; }
        public byte FloorNumber { get; set; }
        public decimal Size { get; set; }
        public enRoomStatus RoomStatus { get; set; }
        public bool IsSmokingAllowed { get; set; }
        public bool IsPetFriendly { get; set; }
        public string Notes { get; set; }

        public string RoomTypeName => _RoomTypeName(this.RoomTypeID);
        public string RoomStatusName => _RoomStatusName(this.RoomStatus);

        public clsRoom()
        {
            this.RoomID = null;
            this.RoomTypeID = enRoomTypes.Single;
            this.RoomNumber = -1;
            this.FloorNumber = 0;
            this.Size = -1M;
            this.RoomStatus = enRoomStatus.Available;
            this.IsSmokingAllowed = false;
            this.IsPetFriendly = false;
            this.Notes = null;
            Mode = enMode.AddNew;
        }

        private clsRoom(int? RoomID, enRoomTypes RoomTypeID, int RoomNumber,
            byte FloorNumber, decimal Size, enRoomStatus Status, bool IsSmokingAllowed,
            bool IsPetFriendly, string Notes)
        {
            this.RoomID = RoomID;
            this.RoomTypeID = RoomTypeID;
            this.RoomNumber = RoomNumber;
            this.FloorNumber = FloorNumber;
            this.Size = Size;
            this.RoomStatus = Status;
            this.IsSmokingAllowed = IsSmokingAllowed;
            this.IsPetFriendly = IsPetFriendly;
            this.Notes = Notes;
            Mode = enMode.Update;
        }

        private bool _AddNewRoom()
        {
            this.RoomID = clsRoomData.AddNewRoom((byte)this.RoomTypeID, this.RoomNumber,
                this.FloorNumber, this.Size, (byte)this.RoomStatus, this.IsSmokingAllowed,
                this.IsPetFriendly, this.Notes);

            return (this.RoomID.HasValue);
        }

        private bool _UpdateRoom()
        {
            return clsRoomData.UpdateRoom(this.RoomID, (byte)this.RoomTypeID, this.RoomNumber,
                this.FloorNumber, this.Size, (byte)this.RoomStatus, this.IsSmokingAllowed,
                this.IsPetFriendly, this.Notes);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRoom())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateRoom();
            }

            return false;
        }

        public static clsRoom FindByRoomID(int? RoomID)
        {
            byte? RoomTypeID = 0;
            int RoomNumber = -1;
            byte FloorNumber = 0;
            decimal Size = -1M;
            byte Status = 0;
            bool IsSmokingAllowed = false;
            bool IsPetFriendly = false;
            string Notes = null;

            bool IsFound = clsRoomData.GetRoomInfoByID(RoomID, ref RoomTypeID, ref RoomNumber,
                ref FloorNumber, ref Size, ref Status, ref IsSmokingAllowed,
                 ref IsPetFriendly, ref Notes);

            return IsFound
                ? new clsRoom(RoomID, (enRoomTypes)RoomTypeID, RoomNumber, FloorNumber, Size,
                    (enRoomStatus)Status, IsSmokingAllowed, IsPetFriendly, Notes)
                : null;
        }

        public static clsRoom FindByRoomNumber(int RoomNumber)
        {
            int? RoomID = null;
            byte? RoomTypeID = null;
            byte FloorNumber = 0;
            decimal Size = -1M;
            byte Status = 0;
            bool IsSmokingAllowed = false;
            bool IsPetFriendly = false;
            string Notes = null;

            bool IsFound = clsRoomData.GetRoomInfoByRoomNumber(RoomNumber, ref RoomID, ref RoomTypeID,
                ref FloorNumber, ref Size, ref Status, ref IsSmokingAllowed,
                 ref IsPetFriendly, ref Notes);

            return IsFound
                ? new clsRoom(RoomID, (enRoomTypes)RoomTypeID, RoomNumber, FloorNumber, Size,
                    (enRoomStatus)Status, IsSmokingAllowed, IsPetFriendly, Notes)
                : null;
        }

        public static bool DeleteRoom(int? RoomID)
        {
            return clsRoomData.DeleteRoom(RoomID);
        }

        public static bool DoesRoomExist(int? RoomID)
        {
            return clsRoomData.DoesRoomExist(RoomID);
        }

        public static DataTable GetAllRooms()
        {
            return clsRoomData.GetAllRooms();
        }

        public static int Count()
        {
            return clsRoomData.GetRoomsCount();
        }

        public static DataTable GetAllAvailableRoomsBySpecificRoomType(enRoomTypes RoomTypeID)
        {
            return clsRoomData.GetAllAvailableRoomsBySpecificRoomType((byte?)RoomTypeID);
        }

        public static int GetAvailableRoomsCount()
        {
            return clsRoomData.GetAvailableRoomsCount();
        }

        public static int GetBookedRoomsCount()
        {
            return clsRoomData.GetBookedRoomsCount();
        }

        public static int GetUnderMaintenanceRoomsCount()
        {
            return clsRoomData.GetUnderMaintenanceRoomsCount();
        }

        private string _RoomTypeName(enRoomTypes RoomType)
        {
            switch (RoomType)
            {
                case enRoomTypes.Single:
                    return "Single";

                case enRoomTypes.Double:
                    return "Double";

                case enRoomTypes.DeluxeSuite:
                    return "Deluxe Suite";

                case enRoomTypes.FamilyRoom:
                    return "Family Room";

                default:
                    return "Unknown";
            }

        }

        private string _RoomStatusName(enRoomStatus RoomStatus)
        {
            switch (RoomStatus)
            {
                case enRoomStatus.Available:
                    return "Available";

                case enRoomStatus.Booked:
                    return "Booked";

                case enRoomStatus.UnderMaintenance:
                    return "Under Maintenance";

                default:
                    return "Unknown";
            }
        }

        public static bool ChangeRoomStatus(int? RoomID, enRoomStatus NewStatus)
        {
            return clsRoomData.ChangeRoomStatus(RoomID, (byte)NewStatus);
        }

        public bool ChangeRoomStatus(enRoomStatus NewStatus)
        {
            return ChangeRoomStatus(this.RoomID, NewStatus);
        }
    }

}