using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsRoomTypeData
{
public static bool GetRoomTypeInfoByID(int? RoomTypeID, ref string RoomTypeTitle, ref byte Capacity, ref decimal PricePerNight, ref string Description)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from RoomTypes where RoomTypeID = @RoomTypeID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomTypeID", (object)RoomTypeID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

RoomTypeTitle = (string)reader["RoomTypeTitle"];
Capacity = (byte)reader["Capacity"];
PricePerNight = (decimal)reader["PricePerNight"];
Description = (reader["Description"] != DBNull.Value) ? (string)reader["Description"] : null;
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

public static int? AddNewRoomType(string RoomTypeTitle, byte Capacity, decimal PricePerNight, string Description)
{
// This function will return the new person id if succeeded and null if not
    int? RoomTypeID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into RoomTypes (RoomTypeTitle, Capacity, PricePerNight, Description)
values (@RoomTypeTitle, @Capacity, @PricePerNight, @Description)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@RoomTypeTitle", RoomTypeTitle);
command.Parameters.AddWithValue("@Capacity", Capacity);
command.Parameters.AddWithValue("@PricePerNight", PricePerNight);
command.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    RoomTypeID = InsertID;
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

    return RoomTypeID;
}

public static bool UpdateRoomType(int? RoomTypeID, string RoomTypeTitle, byte Capacity, decimal PricePerNight, string Description)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update RoomTypes
set RoomTypeTitle = @RoomTypeTitle,
Capacity = @Capacity,
PricePerNight = @PricePerNight,
Description = @Description
where RoomTypeID = @RoomTypeID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomTypeID", (object)RoomTypeID ?? DBNull.Value);
command.Parameters.AddWithValue("@RoomTypeTitle", RoomTypeTitle);
command.Parameters.AddWithValue("@Capacity", Capacity);
command.Parameters.AddWithValue("@PricePerNight", PricePerNight);
command.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);

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

public static bool DeleteRoomType(int? RoomTypeID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete RoomTypes where RoomTypeID = @RoomTypeID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomTypeID", (object)RoomTypeID ?? DBNull.Value);

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

public static bool DoesRoomTypeExist(int? RoomTypeID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from RoomTypes where RoomTypeID = @RoomTypeID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomTypeID", (object)RoomTypeID ?? DBNull.Value);

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

public static DataTable GetAllRoomTypes()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from RoomTypes";

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