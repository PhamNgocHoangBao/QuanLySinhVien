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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            form.ShowDialog();
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            ClassForm form = new ClassForm();
            form.ShowDialog();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            DepartmentForm form = new DepartmentForm();
            form.ShowDialog();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm form = new SubjectForm();
            form.ShowDialog();
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            GradeForm form = new GradeForm();
            form.ShowDialog();
        }
    }
}