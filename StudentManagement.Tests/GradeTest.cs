using StudentManagement.BLL.Services;
using StudentManagement.DTO;

namespace StudentManagement.Tests
{
    [TestClass]
    public class GradeValidatorTests
    {
        private static GradeDTO Valid() => new GradeDTO
        {
            StudentID = 1,
            SubjectID = 1,
            Semester = 1,
            SchoolYear = "2025-2026",
            MidtermScore = 8m,
            FinalScore = 9m,
            TotalScore = 8.6m
        };

        [TestMethod]
        public void Validate_ValidGrade_ReturnsNull()
        {
            Assert.IsNull(GradeValidator.Validate(Valid()));
        }

        [TestMethod]
        public void Validate_Null_ReturnsError()
        {
            Assert.AreEqual("Thông tin điểm không hợp lệ.", GradeValidator.Validate(null!));
        }

        [TestMethod]
        public void Validate_NoStudent_ReturnsError()
        {
            var g = Valid(); g.StudentID = 0;
            Assert.AreEqual("Vui lòng chọn sinh viên.", GradeValidator.Validate(g));
        }

        [TestMethod]
        public void Validate_NoSubject_ReturnsError()
        {
            var g = Valid(); g.SubjectID = 0;
            Assert.AreEqual("Vui lòng chọn môn học.", GradeValidator.Validate(g));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(4)]
        public void Validate_InvalidSemester_ReturnsError(int semester)
        {
            var g = Valid(); g.Semester = semester;
            Assert.AreEqual("Học kỳ phải từ 1 đến 3.", GradeValidator.Validate(g));
        }

        [TestMethod]
        public void Validate_EmptySchoolYear_ReturnsError()
        {
            var g = Valid(); g.SchoolYear = "";
            Assert.AreEqual("Vui lòng nhập năm học.", GradeValidator.Validate(g));
        }

        [TestMethod]
        public void Validate_SchoolYearTooLong_ReturnsError()
        {
            var g = Valid(); g.SchoolYear = new string('1', 21);
            Assert.AreEqual("Năm học không được vượt quá 20 ký tự.", GradeValidator.Validate(g));
        }

        [TestMethod]
        [DataRow(-0.5)]
        [DataRow(10.5)]
        public void Validate_InvalidMidterm_ReturnsError(double score)
        {
            var g = Valid(); g.MidtermScore = (decimal)score;
            Assert.AreEqual("Điểm giữa kỳ phải từ 0 đến 10.", GradeValidator.Validate(g));
        }

        [TestMethod]
        [DataRow(-0.5)]
        [DataRow(10.5)]
        public void Validate_InvalidFinal_ReturnsError(double score)
        {
            var g = Valid(); g.FinalScore = (decimal)score;
            Assert.AreEqual("Điểm cuối kỳ phải từ 0 đến 10.", GradeValidator.Validate(g));
        }

        [TestMethod]
        [DataRow(-0.5)]
        [DataRow(10.5)]
        public void Validate_InvalidTotal_ReturnsError(double score)
        {
            var g = Valid(); g.TotalScore = (decimal)score;
            Assert.AreEqual("Điểm tổng kết phải từ 0 đến 10.", GradeValidator.Validate(g));
        }

        [TestMethod]
        public void Validate_BoundaryScores_ReturnsNull()
        {
            var g = Valid(); g.MidtermScore = 0m; g.FinalScore = 10m; g.TotalScore = 10m;
            Assert.IsNull(GradeValidator.Validate(g));
        }

        [TestMethod]
        public void Validate_NullScores_ReturnsNull()
        {
            var g = Valid(); g.MidtermScore = null; g.FinalScore = null; g.TotalScore = null;
            Assert.IsNull(GradeValidator.Validate(g));
        }
    }

    [TestClass]
    public class GradeBllTests
    {
        private readonly GradeBLL bll = new GradeBLL();

        [TestMethod]
        public void GetByStudentID_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.GetByStudentID(0));
            Assert.AreEqual("Mã sinh viên không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void Insert_InvalidGrade_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(new GradeDTO { StudentID = 0 }));
            Assert.AreEqual("Vui lòng chọn sinh viên.", ex.Message);
        }

        [TestMethod]
        public void Update_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Update(new GradeDTO { GradeID = 0 }));
            Assert.AreEqual("Mã điểm không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void Delete_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Delete(0));
            Assert.AreEqual("Mã điểm không hợp lệ.", ex.Message);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_ReturnsGrades()
        {
            Assert.IsTrue(bll.GetAll().Count > 0);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetByStudentID_ReturnsOnlyThatStudent()
        {
            var grades = bll.GetByStudentID(1);
            Assert.IsTrue(grades.Count > 0);
            Assert.IsTrue(grades.TrueForAll(g => g.StudentID == 1));
        }

        [TestMethod, TestCategory("Integration")]
        public void Search_BySubjectName_ReturnsMatch()
        {
            Assert.IsTrue(bll.Search("Cơ sở dữ liệu").Count > 0);
        }

        [TestMethod, TestCategory("Integration")]
        public void Insert_DuplicateGrade_Throws()
        {
            var g = new GradeDTO
            {
                StudentID = 1,
                SubjectID = 1,
                Semester = 1,
                SchoolYear = "2025-2026",
                MidtermScore = 5m,
                FinalScore = 5m,
                TotalScore = 5m
            };
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(g));
            Assert.AreEqual("Sinh viên đã có điểm môn học này trong học kỳ và năm học đã chọn.", ex.Message);
        }
    }
}
