using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.DTO
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }
}
