using StudentManagement.BLL.Services;
using StudentManagement.DTO;

namespace StudentManagement.Tests
{
    [TestClass]
    public class DepartmentValidatorTests
    {
        private static DepartmentDTO Valid() => new DepartmentDTO
        {
            DepartmentName = "Khoa Test",
            Description = "Mô tả"
        };

        [TestMethod]
        public void Validate_ValidDepartment_ReturnsNull()
        {
            Assert.IsNull(DepartmentValidator.Validate(Valid()));
        }

        [TestMethod]
        public void Validate_Null_ReturnsError()
        {
            Assert.AreEqual("Thông tin khoa không hợp lệ.", DepartmentValidator.Validate(null!));
        }

        [TestMethod]
        public void Validate_EmptyName_ReturnsError()
        {
            var d = Valid(); d.DepartmentName = "";
            Assert.AreEqual("Vui lòng nhập tên khoa.", DepartmentValidator.Validate(d));
        }

        [TestMethod]
        public void Validate_NameTooLong_ReturnsError()
        {
            var d = Valid(); d.DepartmentName = new string('a', 101);
            Assert.AreEqual("Tên khoa không được vượt quá 100 ký tự.", DepartmentValidator.Validate(d));
        }

        [TestMethod]
        public void Validate_DescriptionTooLong_ReturnsError()
        {
            var d = Valid(); d.Description = new string('a', 256);
            Assert.AreEqual("Mô tả không được vượt quá 255 ký tự.", DepartmentValidator.Validate(d));
        }

        [TestMethod]
        public void Validate_NullDescription_ReturnsNull()
        {
            var d = Valid(); d.Description = null!;
            Assert.IsNull(DepartmentValidator.Validate(d));
        }
    }

    [TestClass]
    public class DepartmentBllTests
    {
        private readonly DepartmentBLL bll = new DepartmentBLL();

        [TestMethod]
        public void Insert_InvalidDepartment_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(new DepartmentDTO { DepartmentName = "" }));
            Assert.AreEqual("Vui lòng nhập tên khoa.", ex.Message);
        }

        [TestMethod]
        public void Update_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Update(new DepartmentDTO { DepartmentID = 0 }));
            Assert.AreEqual("Mã khoa không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void Delete_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Delete(0));
            Assert.AreEqual("Mã khoa không hợp lệ.", ex.Message);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_ReturnsDepartments()
        {
            Assert.IsTrue(bll.GetAll().Count > 0);
        }

        [TestMethod, TestCategory("Integration")]
        public void Insert_DuplicateName_IgnoreCase_Throws()
        {
            var d = new DepartmentDTO { DepartmentName = "công nghệ thông tin" };
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(d));
            Assert.AreEqual("Tên khoa đã tồn tại.", ex.Message);
        }
    }
}
