using StudentManagement.BLL.Services;
using StudentManagement.DTO;

namespace StudentManagement.Tests
{
    [TestClass]
    public class SubjectValidatorTests
    {
        private static SubjectDTO Valid() => new SubjectDTO
        {
            SubjectCode = "TS101",
            SubjectName = "Môn test",
            Credits = 3
        };

        [TestMethod]
        public void Validate_ValidSubject_ReturnsNull()
        {
            Assert.IsNull(SubjectValidator.Validate(Valid()));
        }

        [TestMethod]
        public void Validate_Null_ReturnsError()
        {
            Assert.AreEqual("Thông tin môn học không hợp lệ.", SubjectValidator.Validate(null!));
        }

        [TestMethod]
        public void Validate_EmptyCode_ReturnsError()
        {
            var s = Valid(); s.SubjectCode = "";
            Assert.AreEqual("Vui lòng nhập mã môn học.", SubjectValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_CodeTooLong_ReturnsError()
        {
            var s = Valid(); s.SubjectCode = new string('A', 21);
            Assert.AreEqual("Mã môn học không được vượt quá 20 ký tự.", SubjectValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_EmptyName_ReturnsError()
        {
            var s = Valid(); s.SubjectName = " ";
            Assert.AreEqual("Vui lòng nhập tên môn học.", SubjectValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_NameTooLong_ReturnsError()
        {
            var s = Valid(); s.SubjectName = new string('a', 101);
            Assert.AreEqual("Tên môn học không được vượt quá 100 ký tự.", SubjectValidator.Validate(s));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void Validate_InvalidCredits_ReturnsError(int credits)
        {
            var s = Valid(); s.Credits = credits;
            Assert.AreEqual("Số tín chỉ phải lớn hơn 0.", SubjectValidator.Validate(s));
        }
    }

    [TestClass]
    public class SubjectBllTests
    {
        private readonly SubjectBLL bll = new SubjectBLL();

        [TestMethod]
        public void Insert_InvalidSubject_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(new SubjectDTO { SubjectCode = "", SubjectName = "A", Credits = 3 }));
            Assert.AreEqual("Vui lòng nhập mã môn học.", ex.Message);
        }

        [TestMethod]
        public void Update_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Update(new SubjectDTO { SubjectID = 0 }));
            Assert.AreEqual("Mã môn học không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void Delete_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Delete(0));
            Assert.AreEqual("Mã môn học không hợp lệ.", ex.Message);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_ReturnsSubjects()
        {
            Assert.IsTrue(bll.GetAll().Count > 0);
        }

        [TestMethod, TestCategory("Integration")]
        public void Insert_DuplicateCode_IgnoreCase_Throws()
        {
            var s = new SubjectDTO { SubjectCode = "cs101", SubjectName = "Trùng mã", Credits = 3 };
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(s));
            Assert.AreEqual("Mã môn học đã tồn tại.", ex.Message);
        }
    }
}
