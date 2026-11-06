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

                // Thống kê điểm trung bình theo sinh viên
                var ranking = grades
                    .Where(g => g.TotalScore.HasValue)
                    .GroupBy(g => new
                    {
                        g.StudentID,
                        g.StudentCode,
                        g.StudentName
                    })
                    .Select(g => new
                    {
                        StudentCode = g.Key.StudentCode,
                        StudentName = g.Key.StudentName,
                        AverageScore = Math.Round(
                            g.Average(x => x.TotalScore.Value), 2),
                        NumberOfSubjects = g.Count()
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

                    dgvRanking.Columns["NumberOfSubjects"].HeaderText =
                        "Số môn có điểm";
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