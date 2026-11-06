using StudentManagement.DTO;

namespace StudentManagement.BLL.Services
{
    public static class GradeValidator
    {
        public static string Validate(GradeDTO item)
        {
            if (item == null)
                return "Thông tin điểm không hợp lệ.";

            if (item.StudentID <= 0)
                return "Vui lòng chọn sinh viên.";

            if (item.SubjectID <= 0)
                return "Vui lòng chọn môn học.";

            if (item.Semester < 1 || item.Semester > 3)
                return "Học kỳ phải từ 1 đến 3.";

            if (string.IsNullOrWhiteSpace(item.SchoolYear))
                return "Vui lòng nhập năm học.";

            if (item.SchoolYear.Length > 20)
                return "Năm học không được vượt quá 20 ký tự.";

            if (item.MidtermScore.HasValue &&
                (item.MidtermScore < 0 || item.MidtermScore > 10))
                return "Điểm giữa kỳ phải từ 0 đến 10.";

            if (item.FinalScore.HasValue &&
                (item.FinalScore < 0 || item.FinalScore > 10))
                return "Điểm cuối kỳ phải từ 0 đến 10.";

            if (item.TotalScore.HasValue &&
                (item.TotalScore < 0 || item.TotalScore > 10))
                return "Điểm tổng kết phải từ 0 đến 10.";

            return null;
        }
    }
}