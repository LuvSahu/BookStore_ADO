using CommonLayer.AdminModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AdminRL : IAdminRL
    {
        private readonly string connectionString;
        public AdminRL(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("BookStoreConnection");
        }
        // Method to Admin Login
        public string AdminLogin(AdminLoginModel adminLoginModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPAdminLogin", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminEmailID", adminLoginModel.AdminEmailID);
                    cmd.Parameters.AddWithValue("@AdminPassword", adminLoginModel.AdminPassword);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();
                    AdminResponseModel response = new AdminResponseModel();
                    if (reader.Read())
                    {
                        response.AdminID = reader["AdminID"] == DBNull.Value ? default : reader.GetInt32("AdminID");
                        response.AdminEmailID = reader["AdminEmailID"] == DBNull.Value ? default : reader.GetString("AdminEmailID");
                        response.AdminPassword = reader["AdminPassword"] == DBNull.Value ? default : reader.GetString("AdminPassword");
                    }

                    return GenerateJWTToken_Admin(response.AdminEmailID, response.AdminID);
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
        //Method to Generate JWT Token for Authentication and Athorization when Admin Login Sucessful
        private string GenerateJWTToken_Admin(string AdminEmailID, int AdminID)
        {
            try
            {
                // generate token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim("AdminEmailID", AdminEmailID),
                        new Claim("AdminID",AdminID.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
