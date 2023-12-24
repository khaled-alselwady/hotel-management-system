using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsRoomData
{
public static bool GetRoomInfoByID(int? RoomID, ref int RoomTypeID, ref int RoomNumber, ref byte FloorNumber, ref decimal Size, ref byte Status, ref bool IsSmokingAllowed, ref bool IsPetFriendly, ref string Notes)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from Rooms where RoomID = @RoomID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomID", (object)RoomID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

RoomTypeID = (int)reader["RoomTypeID"];
RoomNumber = (int)reader["RoomNumber"];
FloorNumber = (byte)reader["FloorNumber"];
Size = (decimal)reader["Size"];
Status = (byte)reader["Status"];
IsSmokingAllowed = (bool)reader["IsSmokingAllowed"];
IsPetFriendly = (bool)reader["IsPetFriendly"];
Notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : null;
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

public static int? AddNewRoom(int RoomTypeID, int RoomNumber, byte FloorNumber, decimal Size, byte Status, bool IsSmokingAllowed, bool IsPetFriendly, string Notes)
{
// This function will return the new person id if succeeded and null if not
    int? RoomID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into Rooms (RoomTypeID, RoomNumber, FloorNumber, Size, Status, IsSmokingAllowed, IsPetFriendly, Notes)
values (@RoomTypeID, @RoomNumber, @FloorNumber, @Size, @Status, @IsSmokingAllowed, @IsPetFriendly, @Notes)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
command.Parameters.AddWithValue("@RoomNumber", RoomNumber);
command.Parameters.AddWithValue("@FloorNumber", FloorNumber);
command.Parameters.AddWithValue("@Size", Size);
command.Parameters.AddWithValue("@Status", Status);
command.Parameters.AddWithValue("@IsSmokingAllowed", IsSmokingAllowed);
command.Parameters.AddWithValue("@IsPetFriendly", IsPetFriendly);
command.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    RoomID = InsertID;
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

    return RoomID;
}

public static bool UpdateRoom(int? RoomID, int RoomTypeID, int RoomNumber, byte FloorNumber, decimal Size, byte Status, bool IsSmokingAllowed, bool IsPetFriendly, string Notes)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update Rooms
set RoomTypeID = @RoomTypeID,
RoomNumber = @RoomNumber,
FloorNumber = @FloorNumber,
Size = @Size,
Status = @Status,
IsSmokingAllowed = @IsSmokingAllowed,
IsPetFriendly = @IsPetFriendly,
Notes = @Notes
where RoomID = @RoomID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomID", (object)RoomID ?? DBNull.Value);
command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
command.Parameters.AddWithValue("@RoomNumber", RoomNumber);
command.Parameters.AddWithValue("@FloorNumber", FloorNumber);
command.Parameters.AddWithValue("@Size", Size);
command.Parameters.AddWithValue("@Status", Status);
command.Parameters.AddWithValue("@IsSmokingAllowed", IsSmokingAllowed);
command.Parameters.AddWithValue("@IsPetFriendly", IsPetFriendly);
command.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);

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

public static bool DeleteRoom(int? RoomID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete Rooms where RoomID = @RoomID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomID", (object)RoomID ?? DBNull.Value);

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

public static bool DoesRoomExist(int? RoomID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from Rooms where RoomID = @RoomID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomID", (object)RoomID ?? DBNull.Value);

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

public static DataTable GetAllRooms()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from Rooms";

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