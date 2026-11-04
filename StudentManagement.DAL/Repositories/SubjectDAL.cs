
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagement.DAL.Database;
using StudentManagement.DTO;

namespace StudentManagement.DAL.Repositories
{
    public class SubjectDAL
    {
        public List<SubjectDTO> GetAll()
        {
            List<SubjectDTO> subjects = new List<SubjectDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = "SELECT * FROM Subjects ORDER BY SubjectID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new SubjectDTO
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectCode = reader["SubjectCode"].ToString(),
                                SubjectName = reader["SubjectName"].ToString(),
                                Credits = Convert.ToInt32(reader["Credits"])
                            });
                        }
                    }
                }
            }

            return subjects;
        }

        public bool Insert(SubjectDTO subject)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    INSERT INTO Subjects (SubjectCode, SubjectName, Credits)
                    VALUES (@SubjectCode, @SubjectName, @Credits)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@SubjectCode", SqlDbType.VarChar, 20)
                        .Value = subject.SubjectCode;

                    cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100)
                        .Value = subject.SubjectName;

                    cmd.Parameters.Add("@Credits", SqlDbType.Int)
                        .Value = subject.Credits;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(SubjectDTO subject)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    UPDATE Subjects
                    SET SubjectCode = @SubjectCode,
                        SubjectName = @SubjectName,
                        Credits = @Credits
                    WHERE SubjectID = @SubjectID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@SubjectID", SqlDbType.Int)
                        .Value = subject.SubjectID;

                    cmd.Parameters.Add("@SubjectCode", SqlDbType.VarChar, 20)
                        .Value = subject.SubjectCode;

                    cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 100)
                        .Value = subject.SubjectName;

                    cmd.Parameters.Add("@Credits", SqlDbType.Int)
                        .Value = subject.Credits;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int subjectID)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    DELETE FROM Subjects
                    WHERE SubjectID = @SubjectID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@SubjectID", SqlDbType.Int)
                        .Value = subjectID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
