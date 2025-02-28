using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

public record Category
{
    public int CategoryID { get; init; }
    public string CategoryName { get; init; }
}

public class ManageCategories
{
    SqlConnection connection;
    SqlCommand command;
    string ConnectionString = "Server=(local);Database=MyStore;uid=sa;pwd=chinh123;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false";

    public List<Category> GetCategories()
    {
        List<Category> categories = new List<Category>();
        connection = new SqlConnection(ConnectionString);
        string SQL = "SELECT CategoryID, CategoryName FROM Categories";
        command = new SqlCommand(SQL, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                        CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
                    });
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return categories;
    }

  
    public void InsertCategory(Category category)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            SqlCommand command = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", connection);
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    //--------------------
    public void UpdateCategory(Category category)
    {
        connection = new SqlConnection(ConnectionString);
        string SQL = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
        command = new SqlCommand(SQL, connection);
        command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
        command.Parameters.AddWithValue("@CategoryName", category.CategoryName);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public void DeleteCategory(Category category)
    {
        connection = new SqlConnection(ConnectionString);
        string SQL = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
        command = new SqlCommand(SQL, connection);
        command.Parameters.AddWithValue("@CategoryID", category.CategoryID);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }
}
