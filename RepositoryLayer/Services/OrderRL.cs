using CommonLayer.OrderModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class OrderRL : IOrderRL
    {
        private readonly string connectionString;
        public OrderRL(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("BookStoreConnection");
        }
        public bool AddOrder(OrderDataModel postModel)
        {
            SqlConnection sqlconnection = new SqlConnection(this.connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("SPAddOrder", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", postModel.UserId);
                    cmd.Parameters.AddWithValue("@BookId", postModel.BookId);
                    cmd.Parameters.AddWithValue("@BookQuantity", postModel.Quantity);
                    cmd.Parameters.AddWithValue("@AddressId", postModel.AddressId);
                    int result = cmd.ExecuteNonQuery();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
        public List<GetOrderModel> GetAllOrders(int UserId)
        {
            List<GetOrderModel> list = new List<GetOrderModel>();
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPGetAllOrders", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetOrderModel order = new GetOrderModel();
                        order.OrderId = reader["OrderId"] == DBNull.Value ? default : reader.GetInt32("OrderId");
                        order.UserId = reader["UserId"] == DBNull.Value ? default : reader.GetInt32("UserId");
                        order.BookId = reader["BookId"] == DBNull.Value ? default : reader.GetInt32("BookId");
                        order.AddressId = reader["AddressId"] == DBNull.Value ? default : reader.GetInt32("AddressId");
                        order.BookName = reader["BookName"] == DBNull.Value ? default : reader.GetString("BookName");
                        order.Author = reader["Author"] == DBNull.Value ? default : reader.GetString("Author");
                        order.Quantity = reader["Quantity"] == DBNull.Value ? default : reader.GetInt32("Quantity");
                        order.TotalPrice = reader["TotalPrice"] == DBNull.Value ? default : reader.GetDouble("TotalPrice");
                        order.OrderDate = reader["OrderDate"] == DBNull.Value ? default : reader.GetDateTime("OrderDate");
                        order.BookImg = reader["BookImg"] == DBNull.Value ? default : reader.GetString("BookImg");
                        list.Add(order);
                    }
                    return list;
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


        public bool DeleteOrderItem(int UserId, int OrderId)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPDeleteOrderItem", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId ", OrderId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);
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
