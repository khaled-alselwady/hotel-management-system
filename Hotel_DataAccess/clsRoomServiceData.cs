using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessToolkit;

namespace Hotel_DataAccess
{
    public class clsRoomServiceData
    {
        public static bool GetRoomServiceInfoByID(short? RoomServiceID, ref string RoomServiceTitle,
            ref float Fees, ref string Description)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetRoomServiceInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                RoomServiceTitle = (string)reader["RoomServiceTitle"];
                                Fees = Convert.ToSingle(reader["Fees"]);
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

                clsErrorLogger.LogError("Hotel", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsErrorLogger.LogError("Hotel", "General Exception", ex);
            }

            return IsFound;
        }

        public static short? AddNewRoomService(string RoomServiceTitle, float Fees, string Description)
        {
            // This function will return the new person id if succeeded and null if not
            short? RoomServiceID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewRoomService", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@RoomServiceTitle", RoomServiceTitle);
                        command.Parameters.AddWithValue("@Fees", Fees);
                        command.Parameters.AddWithValue("@Description", Description);

                        SqlParameter outputIdParam = new SqlParameter("@NewRoomServiceID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        RoomServiceID = (short?)(int?)outputIdParam.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger.LogError("Hotel", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError("Hotel", "General Exception", ex);
            }

            return RoomServiceID;
        }

        public static bool UpdateRoomService(short? RoomServiceID, string RoomServiceTitle, float Fees, string Description)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateRoomService", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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
                clsErrorLogger.LogError("Hotel", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError("Hotel", "General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DeleteRoomService(short? RoomServiceID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteRoomService", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger.LogError("Hotel", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError("Hotel", "General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DoesRoomServiceExist(short? RoomServiceID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesRoomServiceExistByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);

                        // @ReturnVal could be any name, and we don't need to add it to the SP, just use it here in the code.
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();

                        IsFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsErrorLogger.LogError("Hotel", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsErrorLogger.LogError("Hotel", "General Exception", ex);
            }

            return IsFound;
        }

        public static bool DoesRoomServiceExist(string RoomServiceTitle)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesRoomServiceExistByTitle", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@RoomServiceTitle", RoomServiceTitle);

                        // @ReturnVal could be any name, and we don't need to add it to the SP, just use it here in the code.
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();

                        IsFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsErrorLogger.LogError("Hotel", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsErrorLogger.LogError("Hotel", "General Exception", ex);
            }

            return IsFound;
        }

        public static DataTable GetAllRoomServices()
        {
            return clsDataAccessHelper.GetAll("SP_GetAllRoomServices", "Hotel");
        }
    }
}