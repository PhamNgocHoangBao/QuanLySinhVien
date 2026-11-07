using System;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagement.DAL.Database;
using StudentManagement.DTO;

namespace StudentManagement.DAL.Repositories
{
    public class UserDAL
    {
        public UserDTO GetByUsername(string username)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT UserID, Username, PasswordHash, IsActive
                    FROM Users
                    WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50)
                        .Value = username;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }

            return null;
        }

        public int Count()
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users", conn))
                {
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Insert(UserDTO user)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    INSERT INTO Users (Username, PasswordHash, IsActive)
                    VALUES (@Username, @PasswordHash, @IsActive)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50)
                        .Value = user.Username;

                    cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 200)
                        .Value = user.PasswordHash;

                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit)
                        .Value = user.IsActive;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}