using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessToolkit
{
    public static class clsDataAccessHelper
    {
        public static int Count(string StoredProcedureName, string ProjectName)
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(StoredProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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
                clsErrorLogger.LogError(ProjectName, "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError(ProjectName, "General Exception", ex);
            }

            return Count;
        }

        public static DataTable GetAll(string StoredProcedureName, string ProjectName)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(StoredProcedureName, connection))
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
                clsErrorLogger.LogError(ProjectName, "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError(ProjectName, "General Exception", ex);
            }

            return dt;
        }
    }
}
