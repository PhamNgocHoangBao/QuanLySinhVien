using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;

namespace StudentManagement.BLL.Services
{
    public class StudentBLL
    {
        private readonly StudentDAL studentDAL = new StudentDAL();

        public List<StudentDTO> GetAll()
        {
            return studentDAL.GetAll();
        }

        public StudentDTO GetById(int studentID)
        {
            if (studentID <= 0)
                throw new Exception("Mã sinh viên không hợp lệ.");

            return studentDAL.GetById(studentID);
        }

        public List<StudentDTO> Search(string keyword)
        {
            return studentDAL.Search(keyword ?? "");
        }

        public bool Insert(StudentDTO student)
        {
            ValidateStudent(student);
            return studentDAL.Insert(student);
        }

        public bool Update(StudentDTO student)
        {
            if (student == null || student.StudentID <= 0)
                throw new Exception("Thông tin sinh viên không hợp lệ.");

            ValidateStudent(student);
            return studentDAL.Update(student);
        }

        public bool Delete(int studentID)
        {
            if (studentID <= 0)
                throw new Exception("Mã sinh viên không hợp lệ.");

            return studentDAL.Delete(studentID);
        }

        private void ValidateStudent(StudentDTO student)
        {
            if (student == null)
                throw new Exception("Dữ liệu sinh viên không hợp lệ.");

            if (string.IsNullOrWhiteSpace(student.StudentCode))
                throw new Exception("Mã sinh viên không được để trống.");

            if (student.StudentCode.Length > 20)
                throw new Exception("Mã sinh viên không được vượt quá 20 ký tự.");

            if (string.IsNullOrWhiteSpace(student.FullName))
                throw new Exception("Họ tên không được để trống.");

            if (student.FullName.Length > 100)
                throw new Exception("Họ tên không được vượt quá 100 ký tự.");

            if (student.DateOfBirth.HasValue &&
                student.DateOfBirth.Value.Date > DateTime.Today)
                throw new Exception("Ngày sinh không được lớn hơn ngày hiện tại.");

            if (student.ClassID <= 0)
                throw new Exception("Vui lòng chọn lớp.");

            if (!string.IsNullOrWhiteSpace(student.Email) &&
                !student.Email.Contains("@"))
                throw new Exception("Email không hợp lệ.");

            if (!string.IsNullOrWhiteSpace(student.Phone) &&
                student.Phone.Length > 15)
                throw new Exception("Số điện thoại không được vượt quá 15 ký tự.");
        }
    }
}