using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.DTO
{
    public class ClassDTO
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string AcademicYear { get; set; }
    }
}
