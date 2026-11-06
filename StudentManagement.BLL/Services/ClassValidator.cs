using System;
using StudentManagement.DTO;

namespace StudentManagement.BLL.Services
{
    public static class ClassValidator
    {
        public static string Validate(ClassDTO item)
        {
            if (item == null)
                return "Thông tin lớp không hợp lệ.";

            if (string.IsNullOrWhiteSpace(item.ClassName))
                return "Vui lòng nhập tên lớp.";

            if (item.ClassName.Length > 50)
                return "Tên lớp không được vượt quá 50 ký tự.";

            if (item.DepartmentID <= 0)
                return "Vui lòng chọn khoa.";

            if (!string.IsNullOrWhiteSpace(item.AcademicYear) &&
                item.AcademicYear.Length > 20)
                return "Niên khóa không được vượt quá 20 ký tự.";

            return null;
        }
    }
}