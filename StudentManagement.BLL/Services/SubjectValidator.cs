using StudentManagement.DTO;

namespace StudentManagement.BLL.Services
{
    public static class SubjectValidator
    {
        public static string Validate(SubjectDTO item)
        {
            if (item == null)
                return "Thông tin môn học không hợp lệ.";

            if (string.IsNullOrWhiteSpace(item.SubjectCode))
                return "Vui lòng nhập mã môn học.";

            if (item.SubjectCode.Length > 20)
                return "Mã môn học không được vượt quá 20 ký tự.";

            if (string.IsNullOrWhiteSpace(item.SubjectName))
                return "Vui lòng nhập tên môn học.";

            if (item.SubjectName.Length > 100)
                return "Tên môn học không được vượt quá 100 ký tự.";

            if (item.Credits <= 0)
                return "Số tín chỉ phải lớn hơn 0.";

            return null;
        }
    }
}