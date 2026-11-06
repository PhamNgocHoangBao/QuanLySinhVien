using System;
using System.Text.RegularExpressions;
using StudentManagement.DTO;

namespace StudentManagement.BLL.Services
{
    public static class StudentValidator
    {
        public static string Validate(StudentDTO student)
        {
            if (student == null)
                return "Thông tin sinh viên không hợp lệ.";

            if (string.IsNullOrWhiteSpace(student.StudentCode))
                return "Vui lòng nhập mã sinh viên.";

            if (string.IsNullOrWhiteSpace(student.FullName))
                return "Vui lòng nhập họ và tên.";

            if (student.FullName.Length > 100)
                return "Họ tên không được vượt quá 100 ký tự.";

            if (student.StudentCode.Length > 20)
                return "Mã sinh viên không được vượt quá 20 ký tự.";

            if (!string.IsNullOrWhiteSpace(student.Email))
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(student.Email, pattern))
                    return "Email không đúng định dạng.";
            }

            if (!string.IsNullOrWhiteSpace(student.Phone))
            {
                if (!Regex.IsMatch(student.Phone, @"^[0-9]{9,15}$"))
                    return "Số điện thoại phải gồm 9 đến 15 chữ số.";
            }

            if (student.DateOfBirth.HasValue &&
                student.DateOfBirth.Value.Date > DateTime.Today)
            {
                return "Ngày sinh không được lớn hơn ngày hiện tại.";
            }

            if (student.ClassID <= 0)
                return "Vui lòng chọn lớp học.";

            return null;
        }
    }
}