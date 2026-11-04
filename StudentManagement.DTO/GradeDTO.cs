using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.DTO
{
    public class GradeDTO
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int Semester { get; set; }
        public string SchoolYear { get; set; }
        public decimal? MidtermScore { get; set; }
        public decimal? FinalScore { get; set; }
        public decimal? TotalScore { get; set; }

        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
    }
}
