using StudentManagement.BLL.Services;
using StudentManagement.DTO;

namespace StudentManagement.Tests
{
    // ===== Kiểm tra dữ liệu (không cần database) =====
    [TestClass]
    public class StudentValidatorTests
    {
        private static StudentDTO Valid() => new StudentDTO
        {
            StudentCode = "SV999",
            FullName = "Nguyễn Văn A",
            Email = "",
            Phone = "",
            ClassID = 1
        };

        [TestMethod]
        public void Validate_ValidStudent_ReturnsNull()
        {
            Assert.IsNull(StudentValidator.Validate(Valid()));
        }

        [TestMethod]
        public void Validate_Null_ReturnsError()
        {
            Assert.AreEqual("Thông tin sinh viên không hợp lệ.", StudentValidator.Validate(null!));
        }

        [TestMethod]
        public void Validate_EmptyCode_ReturnsError()
        {
            var s = Valid(); s.StudentCode = "  ";
            Assert.AreEqual("Vui lòng nhập mã sinh viên.", StudentValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_EmptyName_ReturnsError()
        {
            var s = Valid(); s.FullName = "";
            Assert.AreEqual("Vui lòng nhập họ và tên.", StudentValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_NameTooLong_ReturnsError()
        {
            var s = Valid(); s.FullName = new string('a', 101);
            Assert.AreEqual("Họ tên không được vượt quá 100 ký tự.", StudentValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_CodeTooLong_ReturnsError()
        {
            var s = Valid(); s.StudentCode = new string('1', 21);
            Assert.AreEqual("Mã sinh viên không được vượt quá 20 ký tự.", StudentValidator.Validate(s));
        }

        [TestMethod]
        [DataRow("abc")]
        [DataRow("a@b")]
        [DataRow("a b@c.com")]
        public void Validate_InvalidEmail_ReturnsError(string email)
        {
            var s = Valid(); s.Email = email;
            Assert.AreEqual("Email không đúng định dạng.", StudentValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_ValidEmail_ReturnsNull()
        {
            var s = Valid(); s.Email = "an@gmail.com";
            Assert.IsNull(StudentValidator.Validate(s));
        }

        [TestMethod]
        [DataRow("abc")]
        [DataRow("12345678")]
        [DataRow("1234567890123456")]
        public void Validate_InvalidPhone_ReturnsError(string phone)
        {
            var s = Valid(); s.Phone = phone;
            Assert.AreEqual("Số điện thoại phải gồm 9 đến 15 chữ số.", StudentValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_ValidPhone_ReturnsNull()
        {
            var s = Valid(); s.Phone = "0901234567";
            Assert.IsNull(StudentValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_FutureBirthDate_ReturnsError()
        {
            var s = Valid(); s.DateOfBirth = DateTime.Today.AddDays(1);
            Assert.AreEqual("Ngày sinh không được lớn hơn ngày hiện tại.", StudentValidator.Validate(s));
        }

        [TestMethod]
        public void Validate_NoClass_ReturnsError()
        {
            var s = Valid(); s.ClassID = 0;
            Assert.AreEqual("Vui lòng chọn lớp học.", StudentValidator.Validate(s));
        }
    }

    // ===== Kiểm tra StudentBLL =====
    [TestClass]
    public class StudentBllTests
    {
        private readonly StudentBLL bll = new StudentBLL();

        // ===== Không cần database (lỗi bị chặn trước khi truy vấn) =====
        [TestMethod]
        public void GetById_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.GetById(0));
            Assert.AreEqual("Mã sinh viên không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void Insert_InvalidStudent_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(new StudentDTO { StudentCode = "", FullName = "A", ClassID = 1 }));
            Assert.AreEqual("Vui lòng nhập mã sinh viên.", ex.Message);
        }

        [TestMethod]
        public void Update_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Update(new StudentDTO { StudentID = 0 }));
            Assert.AreEqual("Mã sinh viên không hợp lệ.", ex.Message);
        }

        [TestMethod]
        public void Delete_InvalidId_Throws()
        {
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Delete(0));
            Assert.AreEqual("Mã sinh viên không hợp lệ.", ex.Message);
        }

        // ===== GetAll() - cần database có dữ liệu mẫu =====
        [TestMethod, TestCategory("Integration")]
        public void GetAll_ReturnsNotNull()
        {
            var students = bll.GetAll();

            Assert.IsNotNull(students);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_ReturnsExistingStudents()
        {
            var students = bll.GetAll();

            Assert.IsNotEmpty(students, "Danh sách sinh viên đang trống.");
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_ContainsSeedStudent()
        {
            var students = bll.GetAll();

            var sv001 = students.Find(s => s.StudentCode == "SV001");

            Assert.IsNotNull(sv001, "Không thấy sinh viên SV001 trong dữ liệu mẫu.");
            Assert.AreEqual("Nguyễn Văn An", sv001!.FullName);
            Assert.AreEqual("CNTT01", sv001.ClassName);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_EachStudentHasValidData()
        {
            var students = bll.GetAll();

            foreach (var s in students)
            {
                Assert.IsGreaterThan(0, s.StudentID);
                Assert.IsFalse(string.IsNullOrWhiteSpace(s.StudentCode));
                Assert.IsFalse(string.IsNullOrWhiteSpace(s.FullName));
                Assert.IsGreaterThan(0, s.ClassID);
                Assert.IsFalse(string.IsNullOrWhiteSpace(s.ClassName));
            }
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAll_StudentCodesAreUnique()
        {
            var students = bll.GetAll();

            int distinct = students.Select(s => s.StudentCode.ToLower()).Distinct().Count();

            Assert.AreEqual(students.Count, distinct);
        }

        // ===== Thêm / tìm kiếm / lấy theo ID - cần database =====
        [TestMethod, TestCategory("Integration")]
        public void Insert_DuplicateCode_IgnoreCase_Throws()
        {
            var s = new StudentDTO { StudentCode = "sv001", FullName = "Trùng mã", ClassID = 1 };
            var ex = Assert.ThrowsExactly<Exception>(() => bll.Insert(s));
            Assert.AreEqual("Mã sinh viên đã tồn tại.", ex.Message);
        }

        [TestMethod, TestCategory("Integration")]
        public void Search_ByCode_ReturnsMatch()
        {
            var result = bll.Search("SV001");
            Assert.IsNotEmpty(result);
            Assert.IsTrue(result.Exists(s => s.StudentCode == "SV001"));
        }

        [TestMethod, TestCategory("Integration")]
        public void Search_EmptyKeyword_ReturnsAll()
        {
            Assert.HasCount(bll.GetAll().Count, bll.Search(""));
        }

        [TestMethod, TestCategory("Integration")]
        public void Search_Null_DoesNotThrow()
        {
            Assert.IsNotNull(bll.Search(null!));
        }

        [TestMethod, TestCategory("Integration")]
        public void GetById_Existing_ReturnsStudent()
        {
            var first = bll.GetAll()[0];
            var s = bll.GetById(first.StudentID);
            Assert.IsNotNull(s);
            Assert.AreEqual(first.StudentCode, s!.StudentCode);
        }

        [TestMethod, TestCategory("Integration")]
        public void GetById_NotFound_ReturnsNull()
        {
            Assert.IsNull(bll.GetById(999999));
        }
    }
}