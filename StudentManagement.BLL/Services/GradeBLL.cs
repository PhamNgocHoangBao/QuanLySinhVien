using System;
using System.Collections.Generic;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;

namespace StudentManagement.BLL.Services
{
    public class GradeBLL
    {
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

        public bool Insert(GradeDTO grade)
        {
            ValidateGrade(grade);
            CalculateTotalScore(grade);

            return gradeDAL.Insert(grade);
        }

        public bool Update(GradeDTO grade)
        {
            if (grade == null || grade.GradeID <= 0)
                throw new Exception("Mã điểm không hợp lệ.");

            ValidateGrade(grade);
            CalculateTotalScore(grade);

            return gradeDAL.Update(grade);
        }

        public bool Delete(int gradeID)
        {
            if (gradeID <= 0)
                throw new Exception("Mã điểm không hợp lệ.");

            return gradeDAL.Delete(gradeID);
        }

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