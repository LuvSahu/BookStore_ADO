using CommonLayer.BookModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        private readonly string connectionString;
        public BookRL(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("BookStoreConnection");
        }
        public BookDataModel AddBook(BookDataModel bookdataModel)
        {
            SqlConnection sqlconnection = new SqlConnection(this.connectionString);
            try
            {
                {
                    sqlconnection.Open();

                    SqlCommand cmd = new SqlCommand("SPAddBook", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName ", bookdataModel.BookName);
                    cmd.Parameters.AddWithValue("@Author", bookdataModel.Author);
                    cmd.Parameters.AddWithValue("@Description ", bookdataModel.Description);
                    cmd.Parameters.AddWithValue("@Quantity", bookdataModel.Quantity);
                    cmd.Parameters.AddWithValue("@Price", bookdataModel.Price);
                    cmd.Parameters.AddWithValue("@DiscountPrice ", bookdataModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@TotalRating ", bookdataModel.TotalRating);
                    cmd.Parameters.AddWithValue("@RatingCount", bookdataModel.RatingCount);
                    cmd.Parameters.AddWithValue("@BookImg", bookdataModel.BookImg);

                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return bookdataModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public List<GetBookModel> GetAllBooks()
        {
            List<GetBookModel> listOfUsers = new List<GetBookModel>();
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPGetAllBooks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetBookModel book = new GetBookModel();
                        book.BookId = reader["BookId"] == DBNull.Value ? default : reader.GetInt32("BookId");
                        book.BookName = reader["BookName"] == DBNull.Value ? default : reader.GetString("BookName");
                        book.Author = reader["Author"] == DBNull.Value ? default : reader.GetString("Author");
                        book.Description = reader["Description"] == DBNull.Value ? default : reader.GetString("Description");
                        book.Quantity = reader["Quantity"] == DBNull.Value ? default : reader.GetInt32("Quantity");
                        book.Price = reader["Price"] == DBNull.Value ? default : reader.GetDecimal("Price");
                        book.DiscountPrice = reader["DiscountPrice"] == DBNull.Value ? default : reader.GetDecimal("DiscountPrice");
                        book.TotalRating = reader["TotalRating"] == DBNull.Value ? default : reader.GetDouble("TotalRating");
                        book.RatingCount = reader["RatingCount"] == DBNull.Value ? default : reader.GetInt32("RatingCount");
                        book.BookImg = reader["BookImg"] == DBNull.Value ? default : reader.GetString("BookImg");
                        listOfUsers.Add(book);
                    }
                    return listOfUsers;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public GetBookModel GetBookById(int BookId)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPGetBooksById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId ", BookId);
                    var result = cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        return null;
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    GetBookModel book = new GetBookModel();
                    while (reader.Read())
                    {
                        book.BookId = reader["BookId"] == DBNull.Value ? default : reader.GetInt32("BookId");
                        book.BookName = reader["BookName"] == DBNull.Value ? default : reader.GetString("BookName");
                        book.Author = reader["Author"] == DBNull.Value ? default : reader.GetString("Author");
                        book.Description = reader["Description"] == DBNull.Value ? default : reader.GetString("Description");
                        book.Quantity = reader["Quantity"] == DBNull.Value ? default : reader.GetInt32("Quantity");
                        book.Price = reader["Price"] == DBNull.Value ? default : reader.GetDecimal("Price");
                        book.DiscountPrice = reader["DiscountPrice"] == DBNull.Value ? default : reader.GetDecimal("DiscountPrice");
                        book.TotalRating = reader["TotalRating"] == DBNull.Value ? default : reader.GetDouble("TotalRating");
                        book.RatingCount = reader["RatingCount"] == DBNull.Value ? default : reader.GetInt32("RatingCount");
                        book.BookImg = reader["BookImg"] == DBNull.Value ? default : reader.GetString("BookImg");
                    }
                    return book;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public GetBookModel UpdateBooks(int BookId, BookDataModel bookdataModel)
        {
            SqlConnection sqlconnection = new SqlConnection(this.connectionString);
            try
            {
                {
                    sqlconnection.Open();

                    SqlCommand cmd = new SqlCommand("SPUpdateBooks", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    cmd.Parameters.AddWithValue("@BookName ", bookdataModel.BookName);
                    cmd.Parameters.AddWithValue("@Author", bookdataModel.Author);
                    cmd.Parameters.AddWithValue("@Description ", bookdataModel.Description);
                    cmd.Parameters.AddWithValue("@Quantity", bookdataModel.Quantity);
                    cmd.Parameters.AddWithValue("@Price", bookdataModel.Price);
                    cmd.Parameters.AddWithValue("@DiscountPrice ", bookdataModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@TotalRating ", bookdataModel.TotalRating);
                    cmd.Parameters.AddWithValue("@RatingCount", bookdataModel.RatingCount);
                    cmd.Parameters.AddWithValue("@BookImg", bookdataModel.BookImg);

                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        GetBookModel response = new GetBookModel();
                        if (reader.Read())
                        {
                            response.BookId = reader["BookId"] == DBNull.Value ? default : reader.GetInt32("BookId");
                            response.BookName = reader["BookName"] == DBNull.Value ? default : reader.GetString("BookName");
                            response.Author = reader["Author"] == DBNull.Value ? default : reader.GetString("Author");
                            response.Description = reader["Description"] == DBNull.Value ? default : reader.GetString("Description");
                            response.Quantity = reader["Quantity"] == DBNull.Value ? default : reader.GetInt32("Quantity");
                            response.Price = reader["Price"] == DBNull.Value ? default : reader.GetDecimal("Price");
                            response.DiscountPrice = reader["DiscountPrice"] == DBNull.Value ? default : reader.GetDecimal("DiscountPrice");
                            response.TotalRating = reader["TotalRating"] == DBNull.Value ? default : reader.GetDouble("TotalRating");
                            response.RatingCount = reader["RatingCount"] == DBNull.Value ? default : reader.GetInt32("RatingCount");
                            response.BookImg = reader["BookImg"] == DBNull.Value ? default : reader.GetString("BookImg");
                        }

                        return response;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public bool DeleteBook(int BookId)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPdeleteBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId ", BookId);
                    var result = cmd.ExecuteNonQuery();
                    if (result == 0)
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
