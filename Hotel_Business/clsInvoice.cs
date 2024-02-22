using Hotel_DataAccess;
using System;
using System.Data;

namespace Hotel_Business
{
    public class clsInvoice
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? InvoiceID { get; set; }
        public int? PaymentID { get; set; }
        public DateTime InvoiceDate { get; set; }

        public clsPayment PaymentInfo { get; }

        public clsInvoice()
        {
            this.InvoiceID = null;
            this.PaymentID = null;
            this.InvoiceDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        private clsInvoice(int? InvoiceID, int? PaymentID, DateTime InvoiceDate)
        {
            this.InvoiceID = InvoiceID;
            this.PaymentID = PaymentID;
            this.InvoiceDate = InvoiceDate;

            this.PaymentInfo = clsPayment.Find(PaymentID);

            this.Mode = enMode.Update;
        }

        private bool _AddNewInvoice()
        {
            this.InvoiceID = clsInvoiceData.AddNewInvoice(this.PaymentID);

            return (this.InvoiceID.HasValue);
        }

        private bool _UpdateInvoice()
        {
            return clsInvoiceData.UpdateInvoice(this.InvoiceID, this.PaymentID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInvoice())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateInvoice();
            }

            return false;
        }

        public static clsInvoice FindByInvoiceID(int? InvoiceID)
        {
            int? PaymentID = null;
            DateTime InvoiceDate = DateTime.Now;

            bool IsFound = clsInvoiceData.GetInvoiceInfoByInvoiceID(InvoiceID, ref PaymentID, ref InvoiceDate);

            return IsFound ? new clsInvoice(InvoiceID, PaymentID, InvoiceDate) : null;
        }

        public static clsInvoice FindByPaymentID(int? PaymentID)
        {
            int? InvoiceID = null;
            DateTime InvoiceDate = DateTime.Now;

            bool IsFound = clsInvoiceData.GetInvoiceInfoByPaymentID(PaymentID, ref InvoiceID, ref InvoiceDate);

            return IsFound ? new clsInvoice(InvoiceID, PaymentID, InvoiceDate) : null;
        }

        public static bool DeleteInvoice(int? InvoiceID)
        {
            return clsInvoiceData.DeleteInvoice(InvoiceID);
        }

        public static bool DoesInvoiceExist(int? InvoiceID)
        {
            return clsInvoiceData.DoesInvoiceExist(InvoiceID);
        }

        public static DataTable GetAllInvoices()
        {
            return clsInvoiceData.GetAllInvoices();
        }

        public static bool DoesPaymentHaveAnInvoice(int? PaymentID)
        {
            return clsInvoiceData.DoesPaymentHaveAnInvoice(PaymentID);
        }
    }

}