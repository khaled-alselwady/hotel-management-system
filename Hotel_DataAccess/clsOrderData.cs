using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsOrderData
{
public static bool GetOrderInfoByID(int? OrderID, ref int BookingID, ref int PersonID, ref int RoomID, ref byte OrderType, ref decimal Fees, ref DateTime OrderDate, ref int CreatedByUserID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from Orders where OrderID = @OrderID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

BookingID = (int)reader["BookingID"];
PersonID = (int)reader["PersonID"];
RoomID = (int)reader["RoomID"];
OrderType = (byte)reader["OrderType"];
Fees = (decimal)reader["Fees"];
OrderDate = (DateTime)reader["OrderDate"];
CreatedByUserID = (int)reader["CreatedByUserID"];
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

public static int? AddNewOrder(int BookingID, int PersonID, int RoomID, byte OrderType, decimal Fees, DateTime OrderDate, int CreatedByUserID)
{
// This function will return the new person id if succeeded and null if not
    int? OrderID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into Orders (BookingID, PersonID, RoomID, OrderType, Fees, OrderDate, CreatedByUserID)
values (@BookingID, @PersonID, @RoomID, @OrderType, @Fees, @OrderDate, @CreatedByUserID)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@BookingID", BookingID);
command.Parameters.AddWithValue("@PersonID", PersonID);
command.Parameters.AddWithValue("@RoomID", RoomID);
command.Parameters.AddWithValue("@OrderType", OrderType);
command.Parameters.AddWithValue("@Fees", Fees);
command.Parameters.AddWithValue("@OrderDate", OrderDate);
command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    OrderID = InsertID;
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

    return OrderID;
}

public static bool UpdateOrder(int? OrderID, int BookingID, int PersonID, int RoomID, byte OrderType, decimal Fees, DateTime OrderDate, int CreatedByUserID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update Orders
set BookingID = @BookingID,
PersonID = @PersonID,
RoomID = @RoomID,
OrderType = @OrderType,
Fees = @Fees,
OrderDate = @OrderDate,
CreatedByUserID = @CreatedByUserID
where OrderID = @OrderID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);
command.Parameters.AddWithValue("@BookingID", BookingID);
command.Parameters.AddWithValue("@PersonID", PersonID);
command.Parameters.AddWithValue("@RoomID", RoomID);
command.Parameters.AddWithValue("@OrderType", OrderType);
command.Parameters.AddWithValue("@Fees", Fees);
command.Parameters.AddWithValue("@OrderDate", OrderDate);
command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

public static bool DeleteOrder(int? OrderID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete Orders where OrderID = @OrderID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);

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

public static bool DoesOrderExist(int? OrderID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from Orders where OrderID = @OrderID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);

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

public static DataTable GetAllOrders()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from Orders";

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