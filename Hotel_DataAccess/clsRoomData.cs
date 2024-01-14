using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
    public class clsRoomData
    {
        public static bool GetRoomInfoByID(int? RoomID, ref byte? RoomTypeID, ref int RoomNumber,
            ref byte FloorNumber, ref decimal Size, ref byte Status, ref bool IsSmokingAllowed,
            ref bool IsPetFriendly, ref string Notes)
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

                                RoomTypeID = (reader["RoomTypeID"] != DBNull.Value) ? (byte?)Convert.ToByte(reader["RoomTypeID"]) : null;
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

        public static bool GetRoomInfoByRoomNumber(int RoomNumber, ref int? RoomID, ref byte? RoomTypeID,
            ref byte FloorNumber, ref decimal Size, ref byte Status, ref bool IsSmokingAllowed,
            ref bool IsPetFriendly, ref string Notes)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from Rooms where RoomNumber = @RoomNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomNumber", RoomNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                RoomTypeID = (reader["RoomTypeID"] != DBNull.Value) ? (byte?)Convert.ToByte(reader["RoomTypeID"]) : null;
                                RoomID = (reader["RoomID"] != DBNull.Value) ? (int?)reader["RoomID"] : null;
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

        public static int? AddNewRoom(byte? RoomTypeID, int RoomNumber, byte FloorNumber,
            decimal Size, byte Status, bool IsSmokingAllowed, bool IsPetFriendly, string Notes)
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
                        command.Parameters.AddWithValue("@RoomTypeID", (object)RoomTypeID ?? DBNull.Value);
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

        public static bool UpdateRoom(int? RoomID, byte? RoomTypeID, int RoomNumber,
            byte FloorNumber, decimal Size, byte Status, bool IsSmokingAllowed,
            bool IsPetFriendly, string Notes)
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
                        command.Parameters.AddWithValue("@RoomTypeID", (object)RoomTypeID ?? DBNull.Value);
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

        public static DataTable GetAllAvailableRoomsBySpecificRoomType(byte? RoomTypeID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select RoomNumber from Rooms
                                     where RoomTypeID = @RoomTypeID and Status = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomTypeID", (object)RoomTypeID ?? DBNull.Value);

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

        public static int GetRoomsCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select count(*) from Rooms";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
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

            return Count;
        }

        public static int GetAvailableRoomsCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select count(*) from Rooms where Status = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
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

            return Count;
        }

        public static int GetBookedRoomsCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select count(*) from Rooms where Status = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
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

            return Count;
        }

        public static int GetUnderMaintenanceRoomsCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select count(*) from Rooms where Status = 2";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
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

            return Count;
        }

    }
}