
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagement.DAL.Database;
using StudentManagement.DTO;

namespace StudentManagement.DAL.Repositories
{
    public class GradeDAL
    {
        // Lấy toàn bộ danh sách điểm
        public List<GradeDTO> GetAll()
        {
            List<GradeDTO> grades = new List<GradeDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT g.*, s.StudentCode, s.FullName AS StudentName,
                           sub.SubjectName
                    FROM Grades g
                    INNER JOIN Students s ON g.StudentID = s.StudentID
                    INNER JOIN Subjects sub ON g.SubjectID = sub.SubjectID
                    ORDER BY g.GradeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grades.Add(MapGrade(reader));
                        }
                    }
                }
            }

            return grades;
        }

        // Lấy điểm theo sinh viên
        public List<GradeDTO> GetByStudentID(int studentID)
        {
            List<GradeDTO> grades = new List<GradeDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT g.*, s.StudentCode, s.FullName AS StudentName,
                           sub.SubjectName
                    FROM Grades g
                    INNER JOIN Students s ON g.StudentID = s.StudentID
                    INNER JOIN Subjects sub ON g.SubjectID = sub.SubjectID
                    WHERE g.StudentID = @StudentID
                    ORDER BY g.Semester, sub.SubjectName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@StudentID", SqlDbType.Int)
                        .Value = studentID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grades.Add(MapGrade(reader));
                        }
                    }
                }
            }

            return grades;
        }

        // Thêm điểm
        public bool Insert(GradeDTO grade)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    INSERT INTO Grades
                    (
                        StudentID, SubjectID, Semester, SchoolYear,
                        MidtermScore, FinalScore, TotalScore
                    )
                    VALUES
                    (
                        @StudentID, @SubjectID, @Semester, @SchoolYear,
                        @MidtermScore, @FinalScore, @TotalScore
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    AddGradeParameters(cmd, grade);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Cập nhật điểm
        public bool Update(GradeDTO grade)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    UPDATE Grades
                    SET StudentID = @StudentID,
                        SubjectID = @SubjectID,
                        Semester = @Semester,
                        SchoolYear = @SchoolYear,
                        MidtermScore = @MidtermScore,
                        FinalScore = @FinalScore,
                        TotalScore = @TotalScore
                    WHERE GradeID = @GradeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    AddGradeParameters(cmd, grade);

                    cmd.Parameters.Add("@GradeID", SqlDbType.Int)
                        .Value = grade.GradeID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa điểm
        public bool Delete(int gradeID)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    DELETE FROM Grades
                    WHERE GradeID = @GradeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@GradeID", SqlDbType.Int)
                        .Value = gradeID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tìm kiếm điểm theo mã hoặc tên sinh viên
        public List<GradeDTO> Search(string keyword)
        {
            List<GradeDTO> grades = new List<GradeDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT g.*, s.StudentCode, s.FullName AS StudentName,
                           sub.SubjectName
                    FROM Grades g
                    INNER JOIN Students s ON g.StudentID = s.StudentID
                    INNER JOIN Subjects sub ON g.SubjectID = sub.SubjectID
                    WHERE s.StudentCode LIKE @Keyword
                       OR s.FullName LIKE @Keyword
                       OR sub.SubjectName LIKE @Keyword
                    ORDER BY g.GradeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar, 100)
                        .Value = "%" + (keyword ?? "") + "%";

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            grades.Add(MapGrade(reader));
                        }
                    }
                }
            }

            return grades;
        }

        // Chuyển dữ liệu SQL thành GradeDTO
        private GradeDTO MapGrade(SqlDataReader reader)
        {
            return new GradeDTO
            {
                GradeID = Convert.ToInt32(reader["GradeID"]),
                StudentID = Convert.ToInt32(reader["StudentID"]),
                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                Semester = Convert.ToInt32(reader["Semester"]),
                SchoolYear = reader["SchoolYear"].ToString(),

                MidtermScore = reader["MidtermScore"] == DBNull.Value
                    ? (decimal?)null
                    : Convert.ToDecimal(reader["MidtermScore"]),

                FinalScore = reader["FinalScore"] == DBNull.Value
                    ? (decimal?)null
                    : Convert.ToDecimal(reader["FinalScore"]),

                TotalScore = reader["TotalScore"] == DBNull.Value
                    ? (decimal?)null
                    : Convert.ToDecimal(reader["TotalScore"]),

                StudentCode = reader["StudentCode"].ToString(),
                StudentName = reader["StudentName"].ToString(),
                SubjectName = reader["SubjectName"].ToString()
            };
        }

        // Thêm các tham số dùng chung
        private void AddGradeParameters(SqlCommand cmd, GradeDTO grade)
        {
            cmd.Parameters.Add("@StudentID", SqlDbType.Int)
                .Value = grade.StudentID;

            cmd.Parameters.Add("@SubjectID", SqlDbType.Int)
                .Value = grade.SubjectID;

            cmd.Parameters.Add("@Semester", SqlDbType.Int)
                .Value = grade.Semester;

            cmd.Parameters.Add("@SchoolYear", SqlDbType.NVarChar, 20)
                .Value = grade.SchoolYear;

            cmd.Parameters.Add("@MidtermScore", SqlDbType.Decimal)
                .Value = (object)grade.MidtermScore ?? DBNull.Value;

            cmd.Parameters.Add("@FinalScore", SqlDbType.Decimal)
                .Value = (object)grade.FinalScore ?? DBNull.Value;

            cmd.Parameters.Add("@TotalScore", SqlDbType.Decimal)
                .Value = (object)grade.TotalScore ?? DBNull.Value;

            cmd.Parameters["@MidtermScore"].Precision = 4;
            cmd.Parameters["@MidtermScore"].Scale = 2;

            cmd.Parameters["@FinalScore"].Precision = 4;
            cmd.Parameters["@FinalScore"].Scale = 2;

            cmd.Parameters["@TotalScore"].Precision = 4;
            cmd.Parameters["@TotalScore"].Scale = 2;
        }
    }
}
