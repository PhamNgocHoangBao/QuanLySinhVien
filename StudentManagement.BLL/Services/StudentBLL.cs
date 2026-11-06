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

        public bool Insert(StudentDTO item)
        {
            string error = StudentValidator.Validate(item);

            if (error != null)
                throw new Exception(error);

            return studentDAL.Insert(item);
        }

        public bool Update(StudentDTO item)
        {
            if (item == null || item.StudentID <= 0)
                throw new Exception("Mã sinh viên không hợp lệ.");

            string error = StudentValidator.Validate(item);

            if (error != null)
                throw new Exception(error);

            return studentDAL.Update(item);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Mã sinh viên không hợp lệ.");

            return studentDAL.Delete(id);
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