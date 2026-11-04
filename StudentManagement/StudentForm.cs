using System;
using System.Collections.Generic;
using System.Windows.Forms;

using StudentManagement.DTO;
using StudentManagement.BLL.Services;

namespace StudentManagement.UI
{
    public partial class StudentForm : Form
    {
        private readonly StudentBLL studentBLL = new StudentBLL();
        private readonly ClassBLL classBLL = new ClassBLL();

        private int selectedStudentID = 0;

        public StudentForm()
        {
            InitializeComponent();

            LoadClasses();
            LoadStudents();
            ClearFields();
        }

        // Tải danh sách lớp vào ComboBox
        private void LoadClasses()
        {
            try
            {
                List<ClassDTO> classes = classBLL.GetAll();

                cboClass.DataSource = classes;
                cboClass.DisplayMember = "ClassName";
                cboClass.ValueMember = "ClassID";
                cboClass.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách lớp: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Tải danh sách sinh viên
        private void LoadStudents()
        {
            try
            {
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studentBLL.GetAll();

                if (dgvStudents.Columns["StudentID"] != null)
                    dgvStudents.Columns["StudentID"].Visible = false;

                dgvStudents.Columns["StudentCode"].HeaderText = "Mã sinh viên";
                dgvStudents.Columns["FullName"].HeaderText = "Họ và tên";
                dgvStudents.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Gender"].HeaderText = "Giới tính";
                dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
                dgvStudents.Columns["Email"].HeaderText = "Email";
                dgvStudents.Columns["Address"].HeaderText = "Địa chỉ";
                dgvStudents.Columns["ClassName"].HeaderText = "Lớp";

                if (dgvStudents.Columns["ClassID"] != null)
                    dgvStudents.Columns["ClassID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sinh viên: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Lấy dữ liệu từ các ô nhập
        private StudentDTO GetStudentFromForm()
        {
            if (cboClass.SelectedValue == null)
                throw new Exception("Vui lòng chọn lớp.");

            StudentDTO student = new StudentDTO();

            student.StudentID = selectedStudentID;
            student.StudentCode = txtStudentCode.Text.Trim();
            student.FullName = txtFullName.Text.Trim();

            student.DateOfBirth = dtpDateOfBirth.Checked
                ? dtpDateOfBirth.Value.Date
                : (DateTime?)null;

            student.Gender = cboGender.SelectedItem == null
                ? null
                : cboGender.SelectedItem.ToString();

            student.Phone = txtPhone.Text.Trim();
            student.Email = txtEmail.Text.Trim();
            student.Address = txtAddress.Text.Trim();
            student.ClassID = Convert.ToInt32(cboClass.SelectedValue);

            return student;
        }

        // Xóa dữ liệu trên form
        private void ClearFields()
        {
            selectedStudentID = 0;

            txtStudentCode.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            dtpDateOfBirth.Value = DateTime.Today;
            dtpDateOfBirth.Checked = false;

            cboGender.SelectedIndex = -1;
            cboClass.SelectedIndex = -1;

            dgvStudents.ClearSelection();
            txtStudentCode.Focus();
        }

        // THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDTO student = GetStudentFromForm();

                if (studentBLL.Insert(student))
                {
                    MessageBox.Show("Thêm sinh viên thành công!");

                    LoadStudents();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại.");
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

        // SỬA
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedStudentID == 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa.");
                    return;
                }

                StudentDTO student = GetStudentFromForm();

                if (studentBLL.Update(student))
                {
                    MessageBox.Show("Cập nhật sinh viên thành công!");

                    LoadStudents();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.");
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

        // XÓA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedStudentID == 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sinh viên này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (studentBLL.Delete(selectedStudentID))
                    {
                        MessageBox.Show("Xóa sinh viên thành công!");

                        LoadStudents();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sinh viên thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa sinh viên. Có thể sinh viên đã có điểm.\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // CHỌN SINH VIÊN TRONG BẢNG
        private void dgvStudents_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            StudentDTO student =
                dgvStudents.Rows[e.RowIndex].DataBoundItem as StudentDTO;

            if (student == null)
                return;

            selectedStudentID = student.StudentID;

            txtStudentCode.Text = student.StudentCode;
            txtFullName.Text = student.FullName;
            txtPhone.Text = student.Phone;
            txtEmail.Text = student.Email;
            txtAddress.Text = student.Address;

            if (student.DateOfBirth.HasValue)
            {
                dtpDateOfBirth.Value = student.DateOfBirth.Value;
                dtpDateOfBirth.Checked = true;
            }
            else
            {
                dtpDateOfBirth.Value = DateTime.Today;
                dtpDateOfBirth.Checked = false;
            }

            cboGender.SelectedItem = student.Gender;
            cboClass.SelectedValue = student.ClassID;
        }

        // TÌM KIẾM
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = studentBLL.Search(keyword);

                if (dgvStudents.Columns["StudentID"] != null)
                    dgvStudents.Columns["StudentID"].Visible = false;

                dgvStudents.Columns["StudentCode"].HeaderText = "Mã sinh viên";
                dgvStudents.Columns["FullName"].HeaderText = "Họ và tên";
                dgvStudents.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Gender"].HeaderText = "Giới tính";
                dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
                dgvStudents.Columns["Email"].HeaderText = "Email";
                dgvStudents.Columns["Address"].HeaderText = "Địa chỉ";
                dgvStudents.Columns["ClassName"].HeaderText = "Lớp";

                if (dgvStudents.Columns["ClassID"] != null)
                    dgvStudents.Columns["ClassID"].Visible = false;

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // LÀM MỚI
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStudents();
            ClearFields();
        }

        // XÓA TRẮNG
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