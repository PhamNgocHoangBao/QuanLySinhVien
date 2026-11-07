using StudentManagement.BLL.Services;
using StudentManagement.DTO;

namespace StudentManagement.Tests
{
    [TestClass]
    public class ClassValidatorTests
    {
        private static ClassDTO Valid() => new ClassDTO
        {
            ClassName = "CNTT99",
            DepartmentID = 1,
            AcademicYear = "2024-2028"
        };

        [TestMethod]
        public void Validate_ValidClass_ReturnsNull()
        {
            Assert.IsNull(ClassValidator.Validate(Valid()));
        }

        [TestMethod]
        public void Validate_Null_ReturnsError()
        {
            Assert.AreEqual("Thông tin lớp không hợp lệ.", ClassValidator.Validate(null!));
        }

        [TestMethod]
        public void Validate_EmptyName_ReturnsError()
        {
            var c = Valid(); c.ClassName = " ";
            Assert.AreEqual("Vui lòng nhập tên lớp.", ClassValidator.Validate(c));
        }

        [TestMethod]
        public void Validate_NameTooLong_ReturnsError()
        {
            var c = Valid(); c.ClassName = new string('a', 51);
            Assert.AreEqual("Tên lớp không được vượt quá 50 ký tự.", ClassValidator.Validate(c));
        }

        [TestMethod]
        public void Validate_NoDepartment_ReturnsError()
        {
            var c = Valid(); c.DepartmentID = 0;
            Assert.AreEqual("Vui lòng chọn khoa.", ClassValidator.Validate(c));
        }

        [TestMethod]
        public void Validate_AcademicYearTooLong_ReturnsError()
        {
            var c = Valid(); c.AcademicYear = new string('1', 21);
            Assert.AreEqual("Niên khóa không được vượt quá 20 ký tự.", ClassValidator.Validate(c));
        }

        [TestMethod]
        public void Validate_EmptyAcademicYear_ReturnsNull()
        {
            var c = Valid(); c.AcademicYear = "";
            Assert.IsNull(ClassValidator.Validate(c));
        }
    }

    [TestClass]
    public class ClassBllTests
    {
        private readonly ClassBLL bll = new ClassBLL();

        [TestMethod]
        public void Insert_InvalidClass_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(new ClassDTO { ClassName = "", DepartmentID = 1 }));
            Assert.AreEqual("Vui lòng nhập tên lớp.", ex.Message);
        }

        [TestMethod]
        public void Update_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Update(new ClassDTO { ClassID = 0 }));
            Assert.AreEqual("Thông tin lớp không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void Delete_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Delete(0));
            Assert.AreEqual("Mã lớp không hợp lệ.", ex.Message);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_ReturnsClasses()
        {
            Assert.IsTrue(bll.GetAll().Count > 0);
        }

        [TestMethod, TestCategory("Integration")]
        public void Insert_DuplicateName_IgnoreCase_Throws()
        {
            var c = new ClassDTO { ClassName = "cntt01", DepartmentID = 1 };
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(c));
            Assert.AreEqual("Tên lớp đã tồn tại.", ex.Message);
        }
    }
}
