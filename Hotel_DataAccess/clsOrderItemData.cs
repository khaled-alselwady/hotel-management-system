using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsOrderItemData
{
public static bool GetOrderItemInfoByID(int? OrderItemID, ref int OrderID, ref int ItemID, ref int Quantity, ref decimal PricePerItem, ref decimal TotalItemsPrice)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from OrderItems where OrderItemID = @OrderItemID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

OrderID = (int)reader["OrderID"];
ItemID = (int)reader["ItemID"];
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

    clsLogError.LogError("Database Exception", ex);
}
catch (Exception ex)
{
    IsFound = false;

    clsLogError.LogError("General Exception", ex);
}

    return IsFound;
}

public static int? AddNewOrderItem(int OrderID, int ItemID, int Quantity, decimal PricePerItem, decimal TotalItemsPrice)
{
// This function will return the new person id if succeeded and null if not
    int? OrderItemID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into OrderItems (OrderID, ItemID, Quantity, PricePerItem, TotalItemsPrice)
values (@OrderID, @ItemID, @Quantity, @PricePerItem, @TotalItemsPrice)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@OrderID", OrderID);
command.Parameters.AddWithValue("@ItemID", ItemID);
command.Parameters.AddWithValue("@Quantity", Quantity);
command.Parameters.AddWithValue("@PricePerItem", PricePerItem);
command.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    OrderItemID = InsertID;
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

    return OrderItemID;
}

public static bool UpdateOrderItem(int? OrderItemID, int OrderID, int ItemID, int Quantity, decimal PricePerItem, decimal TotalItemsPrice)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update OrderItems
set OrderID = @OrderID,
ItemID = @ItemID,
Quantity = @Quantity,
PricePerItem = @PricePerItem,
TotalItemsPrice = @TotalItemsPrice
where OrderItemID = @OrderItemID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);
command.Parameters.AddWithValue("@OrderID", OrderID);
command.Parameters.AddWithValue("@ItemID", ItemID);
command.Parameters.AddWithValue("@Quantity", Quantity);
command.Parameters.AddWithValue("@PricePerItem", PricePerItem);
command.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);

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

public static bool DeleteOrderItem(int? OrderItemID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete OrderItems where OrderItemID = @OrderItemID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);

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

public static bool DoesOrderItemExist(int? OrderItemID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from OrderItems where OrderItemID = @OrderItemID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@OrderItemID", (object)OrderItemID ?? DBNull.Value);

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

public static DataTable GetAllOrderItems()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from OrderItems";

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