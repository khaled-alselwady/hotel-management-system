using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
    public class clsOrderData
    {
        public static bool GetOrderInfoByID(int? OrderID, ref int? BookingID, ref int? GuestID,
            ref int? RoomID, ref short? RoomServiceID, ref byte OrderType, ref decimal Fees,
            ref DateTime OrderDate, ref int? PaymentID, ref int? CreatedByUserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetOrderInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                BookingID = (reader["BookingID"] != DBNull.Value) ? (int?)reader["BookingID"] : null;
                                GuestID = (reader["GuestID"] != DBNull.Value) ? (int?)reader["GuestID"] : null;
                                RoomID = (reader["RoomID"] != DBNull.Value) ? (int?)reader["RoomID"] : null;
                                RoomServiceID = (reader["RoomServiceID"] != DBNull.Value) ? (short?)(int)reader["RoomServiceID"] : null;
                                OrderType = (byte)reader["OrderType"];
                                Fees = (decimal)reader["Fees"];
                                OrderDate = (DateTime)reader["OrderDate"];
                                PaymentID = (reader["PaymentID"] != DBNull.Value) ? (int?)reader["PaymentID"] : null;
                                CreatedByUserID = (reader["CreatedByUserID"] != DBNull.Value) ? (int?)reader["CreatedByUserID"] : null;
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

        public static int? AddNewOrder(int? BookingID, int? GuestID, int? RoomID, short? RoomServiceID,
            byte OrderType, decimal Fees, int? CreatedByUserID)
        {
            // This function will return the new person id if succeeded and null if not
            int? OrderID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@GuestID", (object)GuestID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RoomID", (object)RoomID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@OrderType", OrderType);
                        command.Parameters.AddWithValue("@Fees", Fees);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)CreatedByUserID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewOrderID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        OrderID = (int?)outputIdParam.Value;
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

        public static bool UpdateOrder(int? OrderID, int? BookingID, int? GuestID, int? RoomID,
            short? RoomServiceID, byte OrderType, decimal Fees,
            int? CreatedByUserID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@GuestID", (object)GuestID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RoomID", (object)RoomID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RoomServiceID", (object)RoomServiceID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@OrderType", OrderType);
                        command.Parameters.AddWithValue("@Fees", Fees);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)CreatedByUserID ?? DBNull.Value);

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

                    using (SqlCommand command = new SqlCommand("SP_DeleteOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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

                    using (SqlCommand command = new SqlCommand("SP_DoesOrderExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);

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

                    using (SqlCommand command = new SqlCommand("SP_GetAllOrders", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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