using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using StudentManagement.DAL.Database;
using StudentManagement.DTO;

namespace StudentManagement.DAL.Repositories
{
    public class StudentDAL
    {
        // Lấy toàn bộ danh sách sinh viên
        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT s.*, c.ClassName
                    FROM Students s
                    INNER JOIN Classes c ON s.ClassID = c.ClassID
                    ORDER BY s.StudentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(MapStudent(reader));
                        }
                    }
                }
            }

            return students;
        }

        // Lấy sinh viên theo ID
        public StudentDTO GetById(int studentID)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT s.*, c.ClassName
                    FROM Students s
                    INNER JOIN Classes c ON s.ClassID = c.ClassID
                    WHERE s.StudentID = @StudentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@StudentID", SqlDbType.Int)
                        .Value = studentID;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapStudent(reader);
                        }
                    }
                }
            }

            return null;
        }

        // Thêm sinh viên
        public bool Insert(StudentDTO student)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    INSERT INTO Students
                    (
                        StudentCode, FullName, DateOfBirth,
                        Gender, Phone, Email, Address, ClassID
                    )
                    VALUES
                    (
                        @StudentCode, @FullName, @DateOfBirth,
                        @Gender, @Phone, @Email, @Address, @ClassID
                    )";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    AddStudentParameters(cmd, student);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Cập nhật sinh viên
        public bool Update(StudentDTO student)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    UPDATE Students
                    SET StudentCode = @StudentCode,
                        FullName = @FullName,
                        DateOfBirth = @DateOfBirth,
                        Gender = @Gender,
                        Phone = @Phone,
                        Email = @Email,
                        Address = @Address,
                        ClassID = @ClassID
                    WHERE StudentID = @StudentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    AddStudentParameters(cmd, student);

                    cmd.Parameters.Add("@StudentID", SqlDbType.Int)
                        .Value = student.StudentID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Xóa sinh viên
        public bool Delete(int studentID)
        {
            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    DELETE FROM Students
                    WHERE StudentID = @StudentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@StudentID", SqlDbType.Int)
                        .Value = studentID;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tìm kiếm theo mã, tên hoặc lớp
        public List<StudentDTO> Search(string keyword)
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (SqlConnection conn = DbConnectionFactory.GetConnection())
            {
                string query = @"
                    SELECT s.*, c.ClassName
                    FROM Students s
                    INNER JOIN Classes c ON s.ClassID = c.ClassID
                    WHERE s.StudentCode LIKE @Keyword
                       OR s.FullName LIKE @Keyword
                       OR c.ClassName LIKE @Keyword
                    ORDER BY s.StudentID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar, 100)
                        .Value = "%" + (keyword ?? "") + "%";

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(MapStudent(reader));
                        }
                    }
                }
            }

            return students;
        }

        // Chuyển dữ liệu SQL thành StudentDTO
        private StudentDTO MapStudent(SqlDataReader reader)
        {
            return new StudentDTO
            {
                StudentID = Convert.ToInt32(reader["StudentID"]),
                StudentCode = reader["StudentCode"].ToString(),
                FullName = reader["FullName"].ToString(),

                DateOfBirth = reader["DateOfBirth"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(reader["DateOfBirth"]),

                Gender = reader["Gender"] == DBNull.Value
                    ? null : reader["Gender"].ToString(),

                Phone = reader["Phone"] == DBNull.Value
                    ? null : reader["Phone"].ToString(),

                Email = reader["Email"] == DBNull.Value
                    ? null : reader["Email"].ToString(),

                Address = reader["Address"] == DBNull.Value
                    ? null : reader["Address"].ToString(),

                ClassID = Convert.ToInt32(reader["ClassID"]),
                ClassName = reader["ClassName"].ToString()
            };
        }

        // Thêm các tham số dùng chung cho Insert và Update
        private void AddStudentParameters(SqlCommand cmd, StudentDTO student)
        {
            cmd.Parameters.Add("@StudentCode", SqlDbType.VarChar, 20)
                .Value = student.StudentCode;

            cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 100)
                .Value = student.FullName;

            cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date)
                .Value = (object)student.DateOfBirth ?? DBNull.Value;

            cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10)
                .Value = (object)student.Gender ?? DBNull.Value;

            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15)
                .Value = (object)student.Phone ?? DBNull.Value;

            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100)
                .Value = (object)student.Email ?? DBNull.Value;

            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 255)
                .Value = (object)student.Address ?? DBNull.Value;

            cmd.Parameters.Add("@ClassID", SqlDbType.Int)
                .Value = student.ClassID;
        }
    }
}
