using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsRoomServiceData
{
public static bool GetRoomServiceInfoByID(int? RoomServiceID, ref string RoomServiceTitle, ref decimal Fees, ref string Description)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from RoomServices where RoomServiceID = @RoomServiceID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

RoomServiceTitle = (string)reader["RoomServiceTitle"];
Fees = (decimal)reader["Fees"];
Description = (string)reader["Description"];
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

public static int? AddNewRoomService(string RoomServiceTitle, decimal Fees, string Description)
{
// This function will return the new person id if succeeded and null if not
    int? RoomServiceID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into RoomServices (RoomServiceTitle, Fees, Description)
values (@RoomServiceTitle, @Fees, @Description)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@RoomServiceTitle", RoomServiceTitle);
command.Parameters.AddWithValue("@Fees", Fees);
command.Parameters.AddWithValue("@Description", Description);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    RoomServiceID = InsertID;
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

    return RoomServiceID;
}

public static bool UpdateRoomService(int? RoomServiceID, string RoomServiceTitle, decimal Fees, string Description)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update RoomServices
set RoomServiceTitle = @RoomServiceTitle,
Fees = @Fees,
Description = @Description
where RoomServiceID = @RoomServiceID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);
command.Parameters.AddWithValue("@RoomServiceTitle", RoomServiceTitle);
command.Parameters.AddWithValue("@Fees", Fees);
command.Parameters.AddWithValue("@Description", Description);

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

public static bool DeleteRoomService(int? RoomServiceID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete RoomServices where RoomServiceID = @RoomServiceID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);

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

public static bool DoesRoomServiceExist(int? RoomServiceID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from RoomServices where RoomServiceID = @RoomServiceID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);

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

public static DataTable GetAllRoomServices()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from RoomServices";

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