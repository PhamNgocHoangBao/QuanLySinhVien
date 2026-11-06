using System;
using System.Windows.Forms;
using StudentManagement.UI;

namespace StudentManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // QUẢN LÝ SINH VIÊN
        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            form.ShowDialog();
        }

        // QUẢN LÝ LỚP
        private void btnClasses_Click(object sender, EventArgs e)
        {
            ClassForm form = new ClassForm();
            form.ShowDialog();
        }

        // QUẢN LÝ KHOA
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            DepartmentForm form = new DepartmentForm();
            form.ShowDialog();
        }

        // QUẢN LÝ MÔN HỌC
        private void btnSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm form = new SubjectForm();
            form.ShowDialog();
        }

        // QUẢN LÝ ĐIỂM
        private void btnGrades_Click(object sender, EventArgs e)
        {
            GradeForm form = new GradeForm();
            form.ShowDialog();
        }

        // THỐNG KÊ
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm form = new StatisticsForm();
            form.ShowDialog();
        }

        // THOÁT
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}