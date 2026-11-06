using StudentManagement.DTO;

namespace StudentManagement.BLL.Services
{
    public static class DepartmentValidator
    {
        public static string Validate(DepartmentDTO item)
        {
            if (item == null)
                return "Thông tin khoa không hợp lệ.";

            if (string.IsNullOrWhiteSpace(item.DepartmentName))
                return "Vui lòng nhập tên khoa.";

            if (item.DepartmentName.Length > 100)
                return "Tên khoa không được vượt quá 100 ký tự.";

            if (item.Description != null &&
                item.Description.Length > 255)
                return "Mô tả không được vượt quá 255 ký tự.";

            return null;
        }
    }
}