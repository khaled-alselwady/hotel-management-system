using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
public class clsBooking
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? BookingID { get; set; }
public int ReservationID { get; set; }
public DateTime CheckInDate { get; set; }
public DateTime? CheckOutDate { get; set; }
public byte Status { get; set; }
public int CreatedByUserID { get; set; }

public clsBooking()
{
    this.BookingID = null;
    this.ReservationID = -1;
    this.CheckInDate = DateTime.Now;
    this.CheckOutDate = null;
    this.Status = 0;
    this.CreatedByUserID = -1;
    Mode = enMode.AddNew;
}

private clsBooking(int? BookingID, int ReservationID, DateTime CheckInDate, DateTime? CheckOutDate, byte Status, int CreatedByUserID)
{
    this.BookingID = BookingID;
    this.ReservationID = ReservationID;
    this.CheckInDate = CheckInDate;
    this.CheckOutDate = CheckOutDate;
    this.Status = Status;
    this.CreatedByUserID = CreatedByUserID;
    Mode = enMode.Update;
}

private bool _AddNewBooking()
{
    this.BookingID = clsBookingData.AddNewBooking(this.ReservationID, this.CheckInDate, this.CheckOutDate, this.Status, this.CreatedByUserID);

    return (this.BookingID.HasValue);
}

private bool _UpdateBooking()
{
return clsBookingData.UpdateBooking(this.BookingID, this.ReservationID, this.CheckInDate, this.CheckOutDate, this.Status, this.CreatedByUserID);
}

public bool Save()
{
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
int ReservationID = -1;
DateTime CheckInDate = DateTime.Now;
DateTime? CheckOutDate = null;
byte Status = 0;
int CreatedByUserID = -1;

bool IsFound = clsBookingData.GetBookingInfoByID(BookingID, ref ReservationID, ref CheckInDate, ref CheckOutDate, ref Status, ref CreatedByUserID);

if (IsFound)
{
return new clsBooking(BookingID, ReservationID, CheckInDate, CheckOutDate, Status, CreatedByUserID);
}
else
{
return null;
}
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

}

}