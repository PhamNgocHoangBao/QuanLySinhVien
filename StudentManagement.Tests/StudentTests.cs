using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagement.BLL.Services;
using System;

namespace StudentManagement.Tests
{
    [TestClass]
    public class StudentTests
    {
        private StudentBLL studentBLL;

        [TestInitialize]
        public void Setup()
        {
            studentBLL = new StudentBLL();
        }

        [TestMethod]
        public void GetAll_ReturnsStudentList()
        {
            // Act
            var students = studentBLL.GetAll();

            // Assert
            Assert.IsNotNull(students);
        }

        [TestMethod]
        public void GetAll_ReturnsExistingStudents()
        {
            // Act
            var students = studentBLL.GetAll();

            // Assert
            Assert.IsTrue(students.Count > 0,
                "Danh sách sinh viên đang trống.");
        }
    }
}