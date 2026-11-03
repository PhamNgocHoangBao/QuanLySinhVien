
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagement.DAL.Database;
using StudentManagement.DTO;

namespace StudentManagement.DAL.Repositories
{
    public class DepartmentDAL
    {
        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = "SELECT * FROM Departments ORDER BY DepartmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new DepartmentDTO
                            {
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                Description = reader["Description"] == DBNull.Value
                                    ? null
                                    : reader["Description"].ToString()
                            });
                        }
                    }
                }
            }

            return departments;
        }

        public bool Insert(DepartmentDTO department)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    INSERT INTO Departments (DepartmentName, Description)
                    VALUES (@DepartmentName, @Description)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100)
                        .Value = department.DepartmentName;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255)
                        .Value = (object)department.Description ?? DBNull.Value;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(DepartmentDTO department)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    UPDATE Departments
                    SET DepartmentName = @DepartmentName,
                        Description = @Description
                    WHERE DepartmentID = @DepartmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int)
                        .Value = department.DepartmentID;

                    cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100)
                        .Value = department.DepartmentName;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255)
                        .Value = (object)department.Description ?? DBNull.Value;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int departmentID)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    DELETE FROM Departments
                    WHERE DepartmentID = @DepartmentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int)
                        .Value = departmentID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
