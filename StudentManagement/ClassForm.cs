using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.UI.Helpers;
using StudentManagement.DTO;
using StudentManagement.BLL.Services;
///
namespace StudentManagement.UI
{
    public partial class ClassForm : Form
    {
        private readonly ClassBLL classBLL = new ClassBLL();
        private readonly DepartmentBLL departmentBLL = new DepartmentBLL();

        private List<ClassDTO> classList = new List<ClassDTO>();
        private int selectedClassID = 0;

        public ClassForm()
        {
            InitializeComponent();

            LoadDepartments();
            LoadClasses();
            ClearFields();
        }

        // Tải danh sách khoa
        private void LoadDepartments()
        {
            try
            {
                cboDepartment.DataSource = departmentBLL.GetAll();
                cboDepartment.DisplayMember = "DepartmentName";
                cboDepartment.ValueMember = "DepartmentID";
                cboDepartment.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khoa: " + ex.Message);
            }
        }

        // Tải danh sách lớp
        private void LoadClasses()
        {
            try
            {
                classList = classBLL.GetAll();
                dgvClasses.DataSource = null;
                dgvClasses.DataSource = classList;

                if (dgvClasses.Columns["ClassID"] != null)
                    dgvClasses.Columns["ClassID"].Visible = false;

                dgvClasses.Columns["ClassName"].HeaderText = "Tên lớp";
                dgvClasses.Columns["DepartmentName"].HeaderText = "Khoa";
                dgvClasses.Columns["AcademicYear"].HeaderText = "Năm học";

                if (dgvClasses.Columns["DepartmentID"] != null)
                    dgvClasses.Columns["DepartmentID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message);
            }
        }

        // Lấy dữ liệu từ form
        private ClassDTO GetClassFromForm()
        {
            if (cboDepartment.SelectedValue == null)
                throw new Exception("Vui lòng chọn khoa.");

            return new ClassDTO
            {
                ClassID = selectedClassID,
                ClassName = txtClassName.Text.Trim(),
                DepartmentID = Convert.ToInt32(cboDepartment.SelectedValue),
                AcademicYear = txtAcademicYear.Text.Trim()
            };
        }

        // Xóa trắng form
        private void ClearFields()
        {
            selectedClassID = 0;

            txtClassName.Clear();
            txtAcademicYear.Clear();
            cboDepartment.SelectedIndex = -1;

            dgvClasses.ClearSelection();
            txtClassName.Focus();
        }

        // THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClassDTO classDTO = GetClassFromForm();

                if (classBLL.Insert(classDTO))
                {
                    MessageBox.Show("Thêm lớp học thành công!");
                    LoadClasses();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm lớp học thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
<<<<<<< HEAD
=======
                MessageHelper.Error(ex.Message);
>>>>>>> 04e7228a2417add90b9ebc1858933613daa73b2a
            }
        }

        // SỬA
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedClassID == 0)
                {
                    MessageBox.Show("Vui lòng chọn lớp cần sửa.");
                    return;
                }

                ClassDTO classDTO = GetClassFromForm();

                if (classBLL.Update(classDTO))
                {
                    MessageBox.Show("Cập nhật lớp học thành công!");
                    LoadClasses();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật lớp học thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
<<<<<<< HEAD
=======
                MessageHelper.Error(ex.Message);
>>>>>>> 04e7228a2417add90b9ebc1858933613daa73b2a
            }
        }

        // XÓA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedClassID == 0)
                {
                    MessageBox.Show("Vui lòng chọn lớp cần xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa lớp này không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (classBLL.Delete(selectedClassID))
                    {
                        MessageBox.Show("Xóa lớp học thành công!");
                        LoadClasses();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa lớp học thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa lớp vì có thể vẫn còn sinh viên thuộc lớp này.\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
<<<<<<< HEAD
=======
                MessageHelper.Error(ex.Message);
>>>>>>> 04e7228a2417add90b9ebc1858933613daa73b2a
            }
        }

        // CHỌN DÒNG TRONG BẢNG
        private void dgvClasses_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ClassDTO classDTO =
                dgvClasses.Rows[e.RowIndex].DataBoundItem as ClassDTO;

            if (classDTO == null)
                return;

            selectedClassID = classDTO.ClassID;
            txtClassName.Text = classDTO.ClassName;
            txtAcademicYear.Text = classDTO.AcademicYear;
            cboDepartment.SelectedValue = classDTO.DepartmentID;
        }

        // TÌM KIẾM
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            List<ClassDTO> result = classList
                .Where(c =>
                    (c.ClassName ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.DepartmentName ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.AcademicYear ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            dgvClasses.DataSource = null;
            dgvClasses.DataSource = result;

            if (dgvClasses.Columns["ClassID"] != null)
                dgvClasses.Columns["ClassID"].Visible = false;

            dgvClasses.Columns["ClassName"].HeaderText = "Tên lớp";
            dgvClasses.Columns["DepartmentName"].HeaderText = "Khoa";
            dgvClasses.Columns["AcademicYear"].HeaderText = "Năm học";

            if (dgvClasses.Columns["DepartmentID"] != null)
                dgvClasses.Columns["DepartmentID"].Visible = false;

            ClearFields();
        }

        // TẢI LẠI
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadClasses();
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