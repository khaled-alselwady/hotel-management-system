using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsPaymentData
{
public static bool GetPaymentInfoByID(int? PaymentID, ref int BookingID, ref int PersonID, ref DateTime PaymentDate, ref decimal PaymentAmount)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from Payments where PaymentID = @PaymentID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

BookingID = (int)reader["BookingID"];
PersonID = (int)reader["PersonID"];
PaymentDate = (DateTime)reader["PaymentDate"];
PaymentAmount = (decimal)reader["PaymentAmount"];
                    }
                    else
                    {
                        // The record was not found
                        IsFound = false;
                    }
                }
            }
        }
    }
catch (SqlException ex)
{
    IsFound = false;

    clsLogError.LogError("Database Exception", ex);
}
catch (Exception ex)
{
    IsFound = false;

    clsLogError.LogError("General Exception", ex);
}

    return IsFound;
}

public static int? AddNewPayment(int BookingID, int PersonID, DateTime PaymentDate, decimal PaymentAmount)
{
// This function will return the new person id if succeeded and null if not
    int? PaymentID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into Payments (BookingID, PersonID, PaymentDate, PaymentAmount)
values (@BookingID, @PersonID, @PaymentDate, @PaymentAmount)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@BookingID", BookingID);
command.Parameters.AddWithValue("@PersonID", PersonID);
command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
command.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PaymentID = InsertID;
                }
            }
        }
    }
catch (SqlException ex)
{
    clsLogError.LogError("Database Exception", ex);
}
catch (Exception ex)
{
    clsLogError.LogError("General Exception", ex);
}

    return PaymentID;
}

public static bool UpdatePayment(int? PaymentID, int BookingID, int PersonID, DateTime PaymentDate, decimal PaymentAmount)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update Payments
set BookingID = @BookingID,
PersonID = @PersonID,
PaymentDate = @PaymentDate,
PaymentAmount = @PaymentAmount
where PaymentID = @PaymentID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
command.Parameters.AddWithValue("@BookingID", BookingID);
command.Parameters.AddWithValue("@PersonID", PersonID);
command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
command.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);

                RowAffected = command.ExecuteNonQuery();
            }
        }
    }
catch (SqlException ex)
{
    clsLogError.LogError("Database Exception", ex);
}
catch (Exception ex)
{
    clsLogError.LogError("General Exception", ex);
}

    return (RowAffected > 0);
}

public static bool DeletePayment(int? PaymentID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete Payments where PaymentID = @PaymentID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                RowAffected = command.ExecuteNonQuery();
            }
        }
    }
catch (SqlException ex)
{
    clsLogError.LogError("Database Exception", ex);
}
catch (Exception ex)
{
    clsLogError.LogError("General Exception", ex);
}

    return (RowAffected > 0);
}

public static bool DoesPaymentExist(int? PaymentID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from Payments where PaymentID = @PaymentID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                IsFound = (command.ExecuteScalar() != null);
            }
        }
    }
catch (SqlException ex)
{
    IsFound = false;

    clsLogError.LogError("Database Exception", ex);
}
catch (Exception ex)
{
    IsFound = false;

    clsLogError.LogError("General Exception", ex);
}

    return IsFound;
}

public static DataTable GetAllPayments()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from Payments";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }
        }
    }
catch (SqlException ex)
{
    clsLogError.LogError("Database Exception", ex);
}
catch (Exception ex)
{
    clsLogError.LogError("General Exception", ex);
}

    return dt;
}
}
}