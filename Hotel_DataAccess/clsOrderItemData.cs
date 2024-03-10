using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessToolkit;

namespace Hotel_DataAccess
{
    public class clsOrderItemData
    {
        public static bool GetOrderItemInfoByID(int? OrderItemID, ref int? OrderID, ref int? ItemID,
            ref int Quantity, ref decimal PricePerItem, ref decimal TotalItemsPrice)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetOrderItemInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                OrderID = (reader["OrderID"] != DBNull.Value) ? (int?)reader["OrderID"] : null;
                                ItemID = (reader["ItemID"] != DBNull.Value) ? (int?)reader["ItemID"] : null;
                                Quantity = (int)reader["Quantity"];
                                PricePerItem = (decimal)reader["PricePerItem"];
                                TotalItemsPrice = (decimal)reader["TotalItemsPrice"];
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

        public static int? AddNewOrderItem(int? OrderID, int? ItemID, int Quantity,
            decimal PricePerItem)
        {
            // This function will return the new person id if succeeded and null if not
            int? OrderItemID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewOrderItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemID", (object)ItemID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@PricePerItem", PricePerItem);

                        SqlParameter outputIdParam = new SqlParameter("@NewOrderItemID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        OrderItemID = (int?)outputIdParam.Value;
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

            return OrderItemID;
        }

        public static bool UpdateOrderItem(int? OrderItemID, int? OrderID, int? ItemID,
            int Quantity, decimal PricePerItem)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateOrderItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@OrderID", (object)OrderID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ItemID", (object)ItemID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Quantity", Quantity);
                        command.Parameters.AddWithValue("@PricePerItem", PricePerItem);

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

        public static bool DeleteOrderItem(int? OrderItemID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteOrderItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);

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

        public static bool DoesOrderItemExist(int? OrderItemID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesOrderItemExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);

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

        public static DataTable GetAllOrderItems()
        {
            return clsDataAccessHelper.GetAll("SP_GetAllOrderItems", "Hotel");
        }

        public static DataTable GetAllOrderItemsByOrderID(int? OrderID)
        {
            return clsDataAccessHelper.GetAll("SP_GetAllOrderItemsByOrderID", "Hotel");
        }
    }
}