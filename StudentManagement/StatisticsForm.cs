
using System;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.BLL.Services;

namespace StudentManagement.UI
{
    public partial class StatisticsForm : Form
    {
        private StudentBLL studentBLL = new StudentBLL();
        private ClassBLL classBLL = new ClassBLL();
        private DepartmentBLL departmentBLL = new DepartmentBLL();
        private SubjectBLL subjectBLL = new SubjectBLL();
        private GradeBLL gradeBLL = new GradeBLL();

        public StatisticsForm()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                var students = studentBLL.GetAll();
                var classes = classBLL.GetAll();
                var departments = departmentBLL.GetAll();
                var subjects = subjectBLL.GetAll();
                var grades = gradeBLL.GetAll();

                // Tổng số lượng
                lblStudentCount.Text = students.Count.ToString();
                lblClassCount.Text = classes.Count.ToString();
                lblDepartmentCount.Text = departments.Count.ToString();
                lblSubjectCount.Text = subjects.Count.ToString();

                // Xếp hạng sinh viên
                var ranking = students.Select(student =>
                {
                    var scores = grades
                        .Where(g => g.StudentID == student.StudentID
                                 && g.TotalScore.HasValue)
                        .ToList();

                    decimal? average = scores.Count > 0
                        ? Math.Round(
                            scores.Average(g => g.TotalScore.Value), 2)
                        : (decimal?)null;

                    return new
                    {
                        StudentCode = student.StudentCode,
                        StudentName = student.FullName,
                        AverageScore = average,
                        Classification = average.HasValue
                            ? GetClassification(average.Value)
                            : "Chưa có điểm",
                        NumberOfSubjects = scores.Count
                    };
                })
                .OrderByDescending(x => x.AverageScore)
                .ToList();

                dgvRanking.DataSource = ranking;

                if (dgvRanking.Columns.Count > 0)
                {
                    dgvRanking.Columns["StudentCode"].HeaderText =
                        "Mã sinh viên";

                    dgvRanking.Columns["StudentName"].HeaderText =
                        "Họ và tên";

                    dgvRanking.Columns["AverageScore"].HeaderText =
                        "Điểm trung bình";

                    dgvRanking.Columns["Classification"].HeaderText =
                        "Xếp loại";

                    dgvRanking.Columns["NumberOfSubjects"].HeaderText =
                        "Số môn có điểm";
                }

                // Thống kê sinh viên theo lớp
                var classStatistics = classes.Select(c => new
                {
                    ClassName = c.ClassName,
                    StudentCount = students.Count(s =>
                        s.ClassID == c.ClassID)
                }).ToList();

                dgvClassStatistics.DataSource = classStatistics;

                if (dgvClassStatistics.Columns.Count > 0)
                {
                    dgvClassStatistics.Columns["ClassName"].HeaderText =
                        "Tên lớp";

                    dgvClassStatistics.Columns["StudentCount"].HeaderText =
                        "Số lượng sinh viên";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải thống kê: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GetClassification(decimal average)
        {
            if (average >= 8.5m)
                return "Giỏi";

            if (average >= 7.0m)
                return "Khá";

            if (average >= 5.0m)
                return "Trung bình";

            return "Yếu";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
