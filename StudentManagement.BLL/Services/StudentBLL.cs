using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;
using Microsoft.Extensions.Logging;
using StudentManagement.DAL.Logging;

namespace StudentManagement.BLL.Services
{
    public class StudentBLL
    {
        private static readonly ILogger logger = AppLogger.GetLogger<StudentBLL>();
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
            {
                logger.LogWarning(
                    "Thêm sinh viên {Code} thất bại: {Error}",
                    item?.StudentCode, error);
                throw new Exception(error);
            }

            CheckDuplicateStudent(item);

            bool result = studentDAL.Insert(item);

            if (result)
                logger.LogInformation(
                    "Thêm sinh viên {Code} thành công",
                    item.StudentCode);
            else
                logger.LogWarning(
                    "Thêm sinh viên {Code} thất bại: không có dòng nào được thêm",
                    item.StudentCode);

            return result;
        }

        public bool Update(StudentDTO item)
        {
            if (item == null || item.StudentID <= 0)
            {
                logger.LogWarning("Cập nhật sinh viên thất bại: mã sinh viên không hợp lệ");
                throw new Exception("Mã sinh viên không hợp lệ.");
            }

            string error = StudentValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Cập nhật sinh viên {Code} (ID={Id}) thất bại: {Error}",
                    item.StudentCode, item.StudentID, error);
                throw new Exception(error);
            }

            CheckDuplicateStudent(item);

            bool result = studentDAL.Update(item);

            if (result)
                logger.LogInformation(
                    "Cập nhật sinh viên {Code} (ID={Id}) thành công",
                    item.StudentCode, item.StudentID);
            else
                logger.LogWarning(
                    "Cập nhật sinh viên {Code} (ID={Id}) thất bại: không có dòng nào được cập nhật",
                    item.StudentCode, item.StudentID);

            return result;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                logger.LogWarning(
                    "Xóa sinh viên thất bại: mã sinh viên không hợp lệ ({Id})", id);
                throw new Exception("Mã sinh viên không hợp lệ.");
            }

            bool result = studentDAL.Delete(id);

            if (result)
                logger.LogInformation("Xóa sinh viên ID={Id} thành công", id);
            else
                logger.LogWarning(
                    "Xóa sinh viên ID={Id} thất bại: không tìm thấy bản ghi", id);

            return result;
        }
        private void CheckDuplicateStudent(StudentDTO student)
        {
            var students = studentDAL.GetAll();

            bool exists = students.Exists(s =>
                s.StudentCode.Equals(
                    student.StudentCode.Trim(),
                    StringComparison.OrdinalIgnoreCase)
                && s.StudentID != student.StudentID);

            if (exists)
                throw new Exception("Mã sinh viên đã tồn tại.");
        }
        /*
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
        */

    }
}