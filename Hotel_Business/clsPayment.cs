using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
public class clsPayment
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? PaymentID { get; set; }
public int BookingID { get; set; }
public int PersonID { get; set; }
public DateTime PaymentDate { get; set; }
public decimal PaymentAmount { get; set; }

public clsPayment()
{
    this.PaymentID = null;
    this.BookingID = -1;
    this.PersonID = -1;
    this.PaymentDate = DateTime.Now;
    this.PaymentAmount = -1M;
    Mode = enMode.AddNew;
}

private clsPayment(int? PaymentID, int BookingID, int PersonID, DateTime PaymentDate, decimal PaymentAmount)
{
    this.PaymentID = PaymentID;
    this.BookingID = BookingID;
    this.PersonID = PersonID;
    this.PaymentDate = PaymentDate;
    this.PaymentAmount = PaymentAmount;
    Mode = enMode.Update;
}

private bool _AddNewPayment()
{
    this.PaymentID = clsPaymentData.AddNewPayment(this.BookingID, this.PersonID, this.PaymentDate, this.PaymentAmount);

    return (this.PaymentID.HasValue);
}

private bool _UpdatePayment()
{
return clsPaymentData.UpdatePayment(this.PaymentID, this.BookingID, this.PersonID, this.PaymentDate, this.PaymentAmount);
}

public bool Save()
{
switch (Mode)
{
case enMode.AddNew:
if (_AddNewPayment())
{
Mode = enMode.Update;
return true;
}
else
{
return false;
}

case enMode.Update:
return _UpdatePayment();
}

return false;
}

public static clsPayment Find(int? PaymentID)
{
int BookingID = -1;
int PersonID = -1;
DateTime PaymentDate = DateTime.Now;
decimal PaymentAmount = -1M;

bool IsFound = clsPaymentData.GetPaymentInfoByID(PaymentID, ref BookingID, ref PersonID, ref PaymentDate, ref PaymentAmount);

if (IsFound)
{
return new clsPayment(PaymentID, BookingID, PersonID, PaymentDate, PaymentAmount);
}
else
{
return null;
}
}

public static bool DeletePayment(int? PaymentID)
{
return clsPaymentData.DeletePayment(PaymentID);
}

public static bool DoesPaymentExist(int? PaymentID)
{
return clsPaymentData.DoesPaymentExist(PaymentID);
}

public static DataTable GetAllPayments()
{
return clsPaymentData.GetAllPayments();
}

}

}