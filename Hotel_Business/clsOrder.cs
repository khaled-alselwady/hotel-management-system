using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
public class clsOrder
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? OrderID { get; set; }
public int BookingID { get; set; }
public int PersonID { get; set; }
public int RoomID { get; set; }
public byte OrderType { get; set; }
public decimal Fees { get; set; }
public DateTime OrderDate { get; set; }
public int CreatedByUserID { get; set; }

public clsOrder()
{
    this.OrderID = null;
    this.BookingID = -1;
    this.PersonID = -1;
    this.RoomID = -1;
    this.OrderType = 0;
    this.Fees = -1M;
    this.OrderDate = DateTime.Now;
    this.CreatedByUserID = -1;
    Mode = enMode.AddNew;
}

private clsOrder(int? OrderID, int BookingID, int PersonID, int RoomID, byte OrderType, decimal Fees, DateTime OrderDate, int CreatedByUserID)
{
    this.OrderID = OrderID;
    this.BookingID = BookingID;
    this.PersonID = PersonID;
    this.RoomID = RoomID;
    this.OrderType = OrderType;
    this.Fees = Fees;
    this.OrderDate = OrderDate;
    this.CreatedByUserID = CreatedByUserID;
    Mode = enMode.Update;
}

private bool _AddNewOrder()
{
    this.OrderID = clsOrderData.AddNewOrder(this.BookingID, this.PersonID, this.RoomID, this.OrderType, this.Fees, this.OrderDate, this.CreatedByUserID);

    return (this.OrderID.HasValue);
}

private bool _UpdateOrder()
{
return clsOrderData.UpdateOrder(this.OrderID, this.BookingID, this.PersonID, this.RoomID, this.OrderType, this.Fees, this.OrderDate, this.CreatedByUserID);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewOrder())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdateOrder();
}

return false;
}

public static clsOrder Find(int? OrderID)
{
int BookingID = -1;
int PersonID = -1;
int RoomID = -1;
byte OrderType = 0;
decimal Fees = -1M;
DateTime OrderDate = DateTime.Now;
int CreatedByUserID = -1;

bool IsFound = clsOrderData.GetOrderInfoByID(OrderID, ref BookingID, ref PersonID, ref RoomID, ref OrderType, ref Fees, ref OrderDate, ref CreatedByUserID);

if (IsFound)
{
return new clsOrder(OrderID, BookingID, PersonID, RoomID, OrderType, Fees, OrderDate, CreatedByUserID);
}
else
{
return null;
}
}

public static bool DeleteOrder(int? OrderID)
{
return clsOrderData.DeleteOrder(OrderID);
}

public static bool DoesOrderExist(int? OrderID)
{
return clsOrderData.DoesOrderExist(OrderID);
}

public static DataTable GetAllOrders()
{
return clsOrderData.GetAllOrders();
}

}

}