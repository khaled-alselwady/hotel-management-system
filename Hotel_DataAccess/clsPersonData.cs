using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_DataAccess
{
public class clsPersonData
{
public static bool GetPersonInfoByID(int? PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

    string query = @"select * from People where PersonID = @PersonID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        IsFound = true;

NationalNo = (string)reader["NationalNo"];
FirstName = (string)reader["FirstName"];
SecondName = (string)reader["SecondName"];
ThirdName = (reader["ThirdName"] != DBNull.Value) ? (string)reader["ThirdName"] : null;
LastName = (string)reader["LastName"];
DateOfBirth = (DateTime)reader["DateOfBirth"];
Gender = (byte)reader["Gender"];
Address = (string)reader["Address"];
Phone = (string)reader["Phone"];
Email = (reader["Email"] != DBNull.Value) ? (string)reader["Email"] : null;
NationalityCountryID = (int)reader["NationalityCountryID"];
ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : null;
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

public static int? AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
{
// This function will return the new person id if succeeded and null if not
    int? PersonID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"insert into People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
select scope_identity()";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
command.Parameters.AddWithValue("@NationalNo", NationalNo);
command.Parameters.AddWithValue("@FirstName", FirstName);
command.Parameters.AddWithValue("@SecondName", SecondName);
command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? DBNull.Value);
command.Parameters.AddWithValue("@LastName", LastName);
command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
command.Parameters.AddWithValue("@Gender", Gender);
command.Parameters.AddWithValue("@Address", Address);
command.Parameters.AddWithValue("@Phone", Phone);
command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PersonID = InsertID;
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

    return PersonID;
}

public static bool UpdatePerson(int? PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

string query = @"Update People
set NationalNo = @NationalNo,
FirstName = @FirstName,
SecondName = @SecondName,
ThirdName = @ThirdName,
LastName = @LastName,
DateOfBirth = @DateOfBirth,
Gender = @Gender,
Address = @Address,
Phone = @Phone,
Email = @Email,
NationalityCountryID = @NationalityCountryID,
ImagePath = @ImagePath
where PersonID = @PersonID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);
command.Parameters.AddWithValue("@NationalNo", NationalNo);
command.Parameters.AddWithValue("@FirstName", FirstName);
command.Parameters.AddWithValue("@SecondName", SecondName);
command.Parameters.AddWithValue("@ThirdName", (object)ThirdName ?? DBNull.Value);
command.Parameters.AddWithValue("@LastName", LastName);
command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
command.Parameters.AddWithValue("@Gender", Gender);
command.Parameters.AddWithValue("@Address", Address);
command.Parameters.AddWithValue("@Phone", Phone);
command.Parameters.AddWithValue("@Email", (object)Email ?? DBNull.Value);
command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);

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

public static bool DeletePerson(int? PersonID)
{
    int RowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"delete People where PersonID = @PersonID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

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

public static bool DoesPersonExist(int? PersonID)
{
    bool IsFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select found = 1 from People where PersonID = @PersonID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", (object)PersonID ?? DBNull.Value);

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

public static DataTable GetAllPeople()
{
    DataTable dt = new DataTable();

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            string query = @"select * from People";

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