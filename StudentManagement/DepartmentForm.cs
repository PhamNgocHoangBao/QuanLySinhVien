using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.UI.Helpers;
using StudentManagement.DTO;
using StudentManagement.BLL.Services;

namespace StudentManagement.UI
{
    public partial class DepartmentForm : Form
    {
        private readonly DepartmentBLL departmentBLL = new DepartmentBLL();

        private List<DepartmentDTO> departmentList =
            new List<DepartmentDTO>();

        private int selectedDepartmentID = 0;

        public DepartmentForm()
        {
            InitializeComponent();

            LoadDepartments();
            ClearFields();
        }

        // TẢI DANH SÁCH KHOA
        private void LoadDepartments()
        {
            try
            {
                departmentList = departmentBLL.GetAll();

                dgvDepartments.DataSource = null;
                dgvDepartments.DataSource = departmentList;

                dgvDepartments.Columns["DepartmentID"].Visible = false;
                dgvDepartments.Columns["DepartmentName"].HeaderText = "Tên khoa";
                dgvDepartments.Columns["Description"].HeaderText = "Mô tả";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khoa: " + ex.Message);
            }
        }

        // LẤY DỮ LIỆU TỪ FORM
        private DepartmentDTO GetDepartmentFromForm()
        {
            return new DepartmentDTO
            {
                DepartmentID = selectedDepartmentID,
                DepartmentName = txtDepartmentName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };
        }

        // XÓA TRẮNG
        private void ClearFields()
        {
            selectedDepartmentID = 0;

            txtDepartmentName.Clear();
            txtDescription.Clear();

            dgvDepartments.ClearSelection();
            txtDepartmentName.Focus();
        }

        // THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentDTO department = GetDepartmentFromForm();

                if (departmentBLL.Insert(department))
                {
                    MessageBox.Show("Thêm khoa thành công!");

                    LoadDepartments();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm khoa thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                MessageHelper.Error(ex.Message);

            }
        }

        // SỬA
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDepartmentID == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoa cần sửa.");
                    return;
                }

                DepartmentDTO department = GetDepartmentFromForm();

                if (departmentBLL.Update(department))
                {
                    MessageBox.Show("Cập nhật khoa thành công!");

                    LoadDepartments();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật khoa thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                MessageHelper.Error(ex.Message);
            }
        }

        // XÓA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDepartmentID == 0)
                {
                    MessageBox.Show("Vui lòng chọn khoa cần xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa khoa này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (departmentBLL.Delete(selectedDepartmentID))
                    {
                        MessageBox.Show("Xóa khoa thành công!");

                        LoadDepartments();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khoa thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa khoa vì có thể vẫn còn lớp thuộc khoa này.\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                MessageHelper.Error(ex.Message);
            }
        }

        // CHỌN KHOA TRONG BẢNG
        private void dgvDepartments_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DepartmentDTO department =
                dgvDepartments.Rows[e.RowIndex].DataBoundItem
                as DepartmentDTO;

            if (department == null)
                return;

            selectedDepartmentID = department.DepartmentID;

            txtDepartmentName.Text = department.DepartmentName;
            txtDescription.Text = department.Description;
        }

        // TÌM KIẾM
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            List<DepartmentDTO> result = departmentList
                .Where(d =>
                    (d.DepartmentName ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (d.Description ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            dgvDepartments.DataSource = null;
            dgvDepartments.DataSource = result;

            dgvDepartments.Columns["DepartmentID"].Visible = false;
            dgvDepartments.Columns["DepartmentName"].HeaderText = "Tên khoa";
            dgvDepartments.Columns["Description"].HeaderText = "Mô tả";

            ClearFields();
        }

        // TẢI LẠI
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadDepartments();
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