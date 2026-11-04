using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using StudentManagement.DTO;
using StudentManagement.BLL.Services;

namespace StudentManagement.UI
{
    public partial class GradeForm : Form
    {
        private readonly GradeBLL gradeBLL = new GradeBLL();
        private readonly StudentBLL studentBLL = new StudentBLL();
        private readonly SubjectBLL subjectBLL = new SubjectBLL();

        private List<GradeDTO> gradeList = new List<GradeDTO>();

        private int selectedGradeID = 0;

        public GradeForm()
        {
            InitializeComponent();

            LoadStudents();
            LoadSubjects();
            LoadGrades();
            ClearFields();
        }

        // TẢI DANH SÁCH SINH VIÊN
        private void LoadStudents()
        {
            try
            {
                cboStudent.DataSource = studentBLL.GetAll();
                cboStudent.DisplayMember = "FullName";
                cboStudent.ValueMember = "StudentID";
                cboStudent.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sinh viên: " + ex.Message);
            }
        }

        // TẢI DANH SÁCH MÔN HỌC
        private void LoadSubjects()
        {
            try
            {
                cboSubject.DataSource = subjectBLL.GetAll();
                cboSubject.DisplayMember = "SubjectName";
                cboSubject.ValueMember = "SubjectID";
                cboSubject.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message);
            }
        }

        // TẢI DANH SÁCH ĐIỂM
        private void LoadGrades()
        {
            try
            {
                gradeList = gradeBLL.GetAll();

                dgvGrades.DataSource = null;
                dgvGrades.DataSource = gradeList;

                string[] hiddenColumns =
                {
                    "GradeID", "StudentID", "SubjectID"
                };

                foreach (string column in hiddenColumns)
                {
                    if (dgvGrades.Columns[column] != null)
                        dgvGrades.Columns[column].Visible = false;
                }

                SetColumnHeader("StudentCode", "Mã sinh viên");
                SetColumnHeader("StudentName", "Họ và tên");
                SetColumnHeader("SubjectName", "Môn học");
                SetColumnHeader("Semester", "Học kỳ");
                SetColumnHeader("SchoolYear", "Năm học");
                SetColumnHeader("MidtermScore", "Điểm giữa kỳ");
                SetColumnHeader("FinalScore", "Điểm cuối kỳ");
                SetColumnHeader("TotalScore", "Điểm tổng kết");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách điểm: " + ex.Message);
            }
        }

        private void SetColumnHeader(string columnName, string header)
        {
            if (dgvGrades.Columns[columnName] != null)
                dgvGrades.Columns[columnName].HeaderText = header;
        }

        // TÍNH ĐIỂM TỔNG KẾT
        // Công thức tạm dùng: giữa kỳ 40%, cuối kỳ 60%.
        private decimal CalculateTotal()
        {
            decimal midterm = nudMidterm.Value;
            decimal final = nudFinal.Value;

            return Math.Round(
                midterm * 0.4M + final * 0.6M,
                2,
                MidpointRounding.AwayFromZero);
        }

        private void Score_ValueChanged(object sender, EventArgs e)
        {
            txtTotal.Text = CalculateTotal().ToString("0.00");
        }

        // LẤY DỮ LIỆU TỪ FORM
        private GradeDTO GetGradeFromForm()
        {
            if (cboStudent.SelectedValue == null)
                throw new Exception("Vui lòng chọn sinh viên.");

            if (cboSubject.SelectedValue == null)
                throw new Exception("Vui lòng chọn môn học.");

            if (string.IsNullOrWhiteSpace(txtSchoolYear.Text))
                throw new Exception("Vui lòng nhập năm học.");

            return new GradeDTO
            {
                GradeID = selectedGradeID,
                StudentID = Convert.ToInt32(cboStudent.SelectedValue),
                SubjectID = Convert.ToInt32(cboSubject.SelectedValue),
                Semester = Convert.ToInt32(nudSemester.Value),
                SchoolYear = txtSchoolYear.Text.Trim(),
                MidtermScore = nudMidterm.Value,
                FinalScore = nudFinal.Value,
                TotalScore = CalculateTotal()
            };
        }

        // XÓA TRẮNG
        private void ClearFields()
        {
            selectedGradeID = 0;

            cboStudent.SelectedIndex = -1;
            cboSubject.SelectedIndex = -1;

            nudSemester.Value = 1;
            txtSchoolYear.Clear();

            nudMidterm.Value = 0;
            nudFinal.Value = 0;

            txtTotal.Text = "0.00";

            dgvGrades.ClearSelection();
        }

        // THÊM ĐIỂM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GradeDTO grade = GetGradeFromForm();

                if (gradeBLL.Insert(grade))
                {
                    MessageBox.Show("Thêm điểm thành công!");

                    LoadGrades();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm điểm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // SỬA ĐIỂM
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGradeID == 0)
                {
                    MessageBox.Show("Vui lòng chọn bản ghi điểm cần sửa.");
                    return;
                }

                GradeDTO grade = GetGradeFromForm();

                if (gradeBLL.Update(grade))
                {
                    MessageBox.Show("Cập nhật điểm thành công!");

                    LoadGrades();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật điểm thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // XÓA ĐIỂM
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedGradeID == 0)
                {
                    MessageBox.Show("Vui lòng chọn bản ghi điểm cần xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa điểm này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (gradeBLL.Delete(selectedGradeID))
                    {
                        MessageBox.Show("Xóa điểm thành công!");

                        LoadGrades();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa điểm thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa điểm: " + ex.Message);
            }
        }

        // CHỌN BẢN GHI TRONG BẢNG
        private void dgvGrades_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            GradeDTO grade =
                dgvGrades.Rows[e.RowIndex].DataBoundItem as GradeDTO;

            if (grade == null)
                return;

            selectedGradeID = grade.GradeID;

            cboStudent.SelectedValue = grade.StudentID;
            cboSubject.SelectedValue = grade.SubjectID;

            nudSemester.Value = grade.Semester;
            txtSchoolYear.Text = grade.SchoolYear;

            nudMidterm.Value = grade.MidtermScore ?? 0;
            nudFinal.Value = grade.FinalScore ?? 0;

            txtTotal.Text = grade.TotalScore.HasValue
                ? grade.TotalScore.Value.ToString("0.00")
                : "0.00";
        }

        // TÌM KIẾM
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            List<GradeDTO> result = gradeList
                .Where(g =>
                    (g.StudentCode ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (g.StudentName ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (g.SubjectName ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            dgvGrades.DataSource = null;
            dgvGrades.DataSource = result;

            string[] hiddenColumns =
            {
                "GradeID", "StudentID", "SubjectID"
            };

            foreach (string column in hiddenColumns)
            {
                if (dgvGrades.Columns[column] != null)
                    dgvGrades.Columns[column].Visible = false;
            }

            SetColumnHeader("StudentCode", "Mã sinh viên");
            SetColumnHeader("StudentName", "Họ và tên");
            SetColumnHeader("SubjectName", "Môn học");
            SetColumnHeader("Semester", "Học kỳ");
            SetColumnHeader("SchoolYear", "Năm học");
            SetColumnHeader("MidtermScore", "Điểm giữa kỳ");
            SetColumnHeader("FinalScore", "Điểm cuối kỳ");
            SetColumnHeader("TotalScore", "Điểm tổng kết");

            ClearFields();
        }

        // TẢI LẠI
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            LoadStudents();
            LoadSubjects();
            LoadGrades();

            ClearFields();
        }

        // LÀM MỚI
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // QUAY LẠI
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}