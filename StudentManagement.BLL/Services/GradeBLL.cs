using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;
using Microsoft.Extensions.Logging;
using StudentManagement.DAL.Logging;

namespace StudentManagement.BLL.Services
{
    public class GradeBLL
    {
        private static readonly ILogger logger = AppLogger.GetLogger<GradeBLL>();
        private readonly GradeDAL gradeDAL = new GradeDAL();

        public List<GradeDTO> GetAll()
        {
            return gradeDAL.GetAll();
        }

        public List<GradeDTO> GetByStudentID(int studentID)
        {
            if (studentID <= 0)
                throw new Exception("Mã sinh viên không hợp lệ.");

            return gradeDAL.GetByStudentID(studentID);
        }

        public List<GradeDTO> Search(string keyword)
        {
            return gradeDAL.Search(keyword ?? "");
        }

        public bool Insert(GradeDTO item)
        {
            string error = GradeValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Thêm điểm (SV={StudentID}, môn={SubjectID}, HK{Semester}, {SchoolYear}) thất bại: {Error}",
                    item?.StudentID, item?.SubjectID, item?.Semester, item?.SchoolYear, error);
                throw new Exception(error);
            }

            CheckDuplicateGrade(item);

            bool result = gradeDAL.Insert(item);

            if (result)
                logger.LogInformation(
                    "Thêm điểm (SV={StudentID}, môn={SubjectID}, HK{Semester}, {SchoolYear}) thành công",
                    item.StudentID, item.SubjectID, item.Semester, item.SchoolYear);
            else
                logger.LogWarning(
                    "Thêm điểm (SV={StudentID}, môn={SubjectID}, HK{Semester}, {SchoolYear}) thất bại: không có dòng nào được thêm",
                    item.StudentID, item.SubjectID, item.Semester, item.SchoolYear);

            return result;
        }

        public bool Update(GradeDTO item)
        {
            if (item == null || item.GradeID <= 0)
            {
                logger.LogWarning("Cập nhật điểm thất bại: mã điểm không hợp lệ");
                throw new Exception("Mã điểm không hợp lệ.");
            }

            string error = GradeValidator.Validate(item);

            if (error != null)
            {
                logger.LogWarning(
                    "Cập nhật điểm ID={GradeID} (SV={StudentID}, môn={SubjectID}) thất bại: {Error}",
                    item.GradeID, item.StudentID, item.SubjectID, error);
                throw new Exception(error);
            }

            CheckDuplicateGrade(item);

            bool result = gradeDAL.Update(item);

            if (result)
                logger.LogInformation(
                    "Cập nhật điểm ID={GradeID} (SV={StudentID}, môn={SubjectID}) thành công",
                    item.GradeID, item.StudentID, item.SubjectID);
            else
                logger.LogWarning(
                    "Cập nhật điểm ID={GradeID} (SV={StudentID}, môn={SubjectID}) thất bại: không có dòng nào được cập nhật",
                    item.GradeID, item.StudentID, item.SubjectID);

            return result;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                logger.LogWarning(
                    "Xóa điểm thất bại: mã điểm không hợp lệ ({Id})", id);
                throw new Exception("Mã điểm không hợp lệ.");
            }

            bool result = gradeDAL.Delete(id);

            if (result)
                logger.LogInformation("Xóa điểm ID={Id} thành công", id);
            else
                logger.LogWarning(
                    "Xóa điểm ID={Id} thất bại: không tìm thấy bản ghi", id);

            return result;
        }
        private void CheckDuplicateGrade(GradeDTO item)
        {
            var grades = gradeDAL.GetAll();

            bool exists = grades.Exists(g =>
                g.StudentID == item.StudentID &&
                g.SubjectID == item.SubjectID &&
                g.Semester == item.Semester &&
                g.SchoolYear == item.SchoolYear &&
                g.GradeID != item.GradeID);

            if (exists)
                throw new Exception(
                    "Sinh viên đã có điểm môn học này trong học kỳ và năm học đã chọn.");
        }

        /*
        private void ValidateGrade(GradeDTO grade)
        {
            if (grade == null)
                throw new Exception("Dữ liệu điểm không hợp lệ.");

            if (grade.StudentID <= 0)
                throw new Exception("Vui lòng chọn sinh viên.");

            if (grade.SubjectID <= 0)
                throw new Exception("Vui lòng chọn môn học.");

            if (grade.Semester < 1 || grade.Semester > 3)
                throw new Exception("Học kỳ phải từ 1 đến 3.");

            if (string.IsNullOrWhiteSpace(grade.SchoolYear))
                throw new Exception("Năm học không được để trống.");

            if (!IsValidScore(grade.MidtermScore))
                throw new Exception("Điểm giữa kỳ phải nằm trong khoảng 0 đến 10.");

            if (!IsValidScore(grade.FinalScore))
                throw new Exception("Điểm cuối kỳ phải nằm trong khoảng 0 đến 10.");
        }
        */
        private bool IsValidScore(decimal? score)
        {
            return !score.HasValue ||
                   (score.Value >= 0 && score.Value <= 10);
        }

        private void CalculateTotalScore(GradeDTO grade)
        {
            if (grade.MidtermScore.HasValue && grade.FinalScore.HasValue)
            {
                // Công thức đề xuất: giữa kỳ 40%, cuối kỳ 60%.
                grade.TotalScore = Math.Round(
                    grade.MidtermScore.Value * 0.4m +
                    grade.FinalScore.Value * 0.6m,
                    2
                );
            }
            else
            {
                grade.TotalScore = null;
            }
        }
    }
}