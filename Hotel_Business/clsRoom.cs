using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
public class clsRoom
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? RoomID { get; set; }
public int RoomTypeID { get; set; }
public int RoomNumber { get; set; }
public byte FloorNumber { get; set; }
public decimal Size { get; set; }
public byte Status { get; set; }
public bool IsSmokingAllowed { get; set; }
public bool IsPetFriendly { get; set; }
public string Notes { get; set; }

public clsRoom()
{
    this.RoomID = null;
    this.RoomTypeID = -1;
    this.RoomNumber = -1;
    this.FloorNumber = 0;
    this.Size = -1M;
    this.Status = 0;
    this.IsSmokingAllowed = false;
    this.IsPetFriendly = false;
    this.Notes = null;
    Mode = enMode.AddNew;
}

private clsRoom(int? RoomID, int RoomTypeID, int RoomNumber, byte FloorNumber, decimal Size, byte Status, bool IsSmokingAllowed, bool IsPetFriendly, string Notes)
{
    this.RoomID = RoomID;
    this.RoomTypeID = RoomTypeID;
    this.RoomNumber = RoomNumber;
    this.FloorNumber = FloorNumber;
    this.Size = Size;
    this.Status = Status;
    this.IsSmokingAllowed = IsSmokingAllowed;
    this.IsPetFriendly = IsPetFriendly;
    this.Notes = Notes;
    Mode = enMode.Update;
}

private bool _AddNewRoom()
{
    this.RoomID = clsRoomData.AddNewRoom(this.RoomTypeID, this.RoomNumber, this.FloorNumber, this.Size, this.Status, this.IsSmokingAllowed, this.IsPetFriendly, this.Notes);

    return (this.RoomID.HasValue);
}

private bool _UpdateRoom()
{
return clsRoomData.UpdateRoom(this.RoomID, this.RoomTypeID, this.RoomNumber, this.FloorNumber, this.Size, this.Status, this.IsSmokingAllowed, this.IsPetFriendly, this.Notes);
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

public static clsRoom Find(int? RoomID)
{
int RoomTypeID = -1;
int RoomNumber = -1;
byte FloorNumber = 0;
decimal Size = -1M;
byte Status = 0;
bool IsSmokingAllowed = false;
bool IsPetFriendly = false;
string Notes = null;

bool IsFound = clsRoomData.GetRoomInfoByID(RoomID, ref RoomTypeID, ref RoomNumber, ref FloorNumber, ref Size, ref Status, ref IsSmokingAllowed, ref IsPetFriendly, ref Notes);

if (IsFound)
{
return new clsRoom(RoomID, RoomTypeID, RoomNumber, FloorNumber, Size, Status, IsSmokingAllowed, IsPetFriendly, Notes);
}
else
{
return null;
}
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

}

}