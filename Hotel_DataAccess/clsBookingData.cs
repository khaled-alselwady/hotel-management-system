using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsBookingData
{
public static bool GetBookingInfoByID(int? BookingID, ref int ReservationID, ref DateTime CheckInDate, ref DateTime? CheckOutDate, ref byte Status, ref int CreatedByUserID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from Bookings where BookingID = @BookingID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

ReservationID = (int)reader["ReservationID"];
CheckInDate = (DateTime)reader["CheckInDate"];
CheckOutDate = (reader["CheckOutDate"] != DBNull.Value) ? (DateTime?)reader["CheckOutDate"] : null;
Status = (byte)reader["Status"];
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

public static int? AddNewBooking(int ReservationID, DateTime CheckInDate, DateTime? CheckOutDate, byte Status, int CreatedByUserID)
{
// This function will return the new person id if succeeded and null if not
    int? BookingID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into Bookings (ReservationID, CheckInDate, CheckOutDate, Status, CreatedByUserID)
values (@ReservationID, @CheckInDate, @CheckOutDate, @Status, @CreatedByUserID)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@ReservationID", ReservationID);
command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
command.Parameters.AddWithValue("@CheckOutDate", (object)CheckOutDate ?? DBNull.Value);
command.Parameters.AddWithValue("@Status", Status);
command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    BookingID = InsertID;
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

    return BookingID;
}

public static bool UpdateBooking(int? BookingID, int ReservationID, DateTime CheckInDate, DateTime? CheckOutDate, byte Status, int CreatedByUserID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update Bookings
set ReservationID = @ReservationID,
CheckInDate = @CheckInDate,
CheckOutDate = @CheckOutDate,
Status = @Status,
CreatedByUserID = @CreatedByUserID
where BookingID = @BookingID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);
command.Parameters.AddWithValue("@ReservationID", ReservationID);
command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
command.Parameters.AddWithValue("@CheckOutDate", (object)CheckOutDate ?? DBNull.Value);
command.Parameters.AddWithValue("@Status", Status);
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

public static bool DeleteBooking(int? BookingID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete Bookings where BookingID = @BookingID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

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

public static bool DoesBookingExist(int? BookingID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from Bookings where BookingID = @BookingID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

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

public static DataTable GetAllBookings()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from Bookings";

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