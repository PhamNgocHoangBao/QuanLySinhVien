using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagement.DAL.Database;
using StudentManagement.DTO;

namespace StudentManagement.DAL.Repositories
{
    public class ClassDAL
    {
        public List<ClassDTO> GetAll()
        {
            List<ClassDTO> classes = new List<ClassDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT c.ClassID, c.ClassName, c.DepartmentID,
                           d.DepartmentName, c.AcademicYear
                    FROM Classes c
                    INNER JOIN Departments d
                        ON c.DepartmentID = d.DepartmentID
                    ORDER BY c.ClassID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            classes.Add(new ClassDTO
                            {
                                ClassID = Convert.ToInt32(reader["ClassID"]),
                                ClassName = reader["ClassName"].ToString(),
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                AcademicYear = reader["AcademicYear"] == DBNull.Value
                                    ? null
                                    : reader["AcademicYear"].ToString()
                            });
                        }
                    }
                }
            }

            return classes;
        }
    

    public bool Insert(ClassDTO classDTO)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    INSERT INTO Classes (ClassName, DepartmentID, AcademicYear)
                    VALUES (@ClassName, @DepartmentID, @AcademicYear)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar, 50)
                        .Value = classDTO.ClassName;

                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int)
                        .Value = classDTO.DepartmentID;

                    cmd.Parameters.Add("@AcademicYear", SqlDbType.NVarChar, 20)
                        .Value = (object)classDTO.AcademicYear ?? DBNull.Value;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool Update(ClassDTO classDTO)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    UPDATE Classes
                    SET ClassName = @ClassName,
                        DepartmentID = @DepartmentID,
                        AcademicYear = @AcademicYear
                    WHERE ClassID = @ClassID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ClassID", SqlDbType.Int)
                        .Value = classDTO.ClassID;

                    cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar, 50)
                        .Value = classDTO.ClassName;

                    cmd.Parameters.Add("@DepartmentID", SqlDbType.Int)
                        .Value = classDTO.DepartmentID;

                    cmd.Parameters.Add("@AcademicYear", SqlDbType.NVarChar, 20)
                        .Value = (object)classDTO.AcademicYear ?? DBNull.Value;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool Delete(int classID)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    DELETE FROM Classes
                    WHERE ClassID = @ClassID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ClassID", SqlDbType.Int)
                        .Value = classID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
