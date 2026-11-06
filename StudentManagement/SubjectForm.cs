using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.UI.Helpers;
using StudentManagement.DTO;
using StudentManagement.BLL.Services;

namespace StudentManagement.UI
{
    public partial class SubjectForm : Form
    {
        private readonly SubjectBLL subjectBLL = new SubjectBLL();

        private List<SubjectDTO> subjectList = new List<SubjectDTO>();

        private int selectedSubjectID = 0;

        public SubjectForm()
        {
            InitializeComponent();

            LoadSubjects();
            ClearFields();
        }

        // TẢI DANH SÁCH MÔN HỌC
        private void LoadSubjects()
        {
            try
            {
                subjectList = subjectBLL.GetAll();

                dgvSubjects.DataSource = null;
                dgvSubjects.DataSource = subjectList;

                dgvSubjects.Columns["SubjectID"].Visible = false;
                dgvSubjects.Columns["SubjectCode"].HeaderText = "Mã môn học";
                dgvSubjects.Columns["SubjectName"].HeaderText = "Tên môn học";
                dgvSubjects.Columns["Credits"].HeaderText = "Số tín chỉ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách môn học: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // LẤY DỮ LIỆU TỪ FORM
        private SubjectDTO GetSubjectFromForm()
        {
            return new SubjectDTO
            {
                SubjectID = selectedSubjectID,
                SubjectCode = txtSubjectCode.Text.Trim(),
                SubjectName = txtSubjectName.Text.Trim(),
                Credits = Convert.ToInt32(nudCredits.Value)
            };
        }

        // XÓA TRẮNG FORM
        private void ClearFields()
        {
            selectedSubjectID = 0;

            txtSubjectCode.Clear();
            txtSubjectName.Clear();
            nudCredits.Value = 3;

            dgvSubjects.ClearSelection();
            txtSubjectCode.Focus();
        }

        // THÊM MÔN HỌC
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SubjectDTO subject = GetSubjectFromForm();

                if (subjectBLL.Insert(subject))
                {
                    MessageBox.Show("Thêm môn học thành công!");

                    LoadSubjects();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Thêm môn học thất bại.");
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

        // SỬA MÔN HỌC
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSubjectID == 0)
                {
                    MessageBox.Show("Vui lòng chọn môn học cần sửa.");
                    return;
                }

                SubjectDTO subject = GetSubjectFromForm();

                if (subjectBLL.Update(subject))
                {
                    MessageBox.Show("Cập nhật môn học thành công!");

                    LoadSubjects();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật môn học thất bại.");
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

        // XÓA MÔN HỌC
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSubjectID == 0)
                {
                    MessageBox.Show("Vui lòng chọn môn học cần xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa môn học này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (subjectBLL.Delete(selectedSubjectID))
                    {
                        MessageBox.Show("Xóa môn học thành công!");

                        LoadSubjects();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa môn học thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xóa môn học vì có thể đã có điểm liên quan.\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                MessageHelper.Error(ex.Message);
            }
        }

        // CHỌN MÔN HỌC TRONG BẢNG
        private void dgvSubjects_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SubjectDTO subject =
                dgvSubjects.Rows[e.RowIndex].DataBoundItem as SubjectDTO;

            if (subject == null)
                return;

            selectedSubjectID = subject.SubjectID;

            txtSubjectCode.Text = subject.SubjectCode;
            txtSubjectName.Text = subject.SubjectName;
            nudCredits.Value = subject.Credits;
        }

        // TÌM KIẾM
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            List<SubjectDTO> result = subjectList
                .Where(s =>
                    (s.SubjectCode ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (s.SubjectName ?? "").IndexOf(
                        keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            dgvSubjects.DataSource = null;
            dgvSubjects.DataSource = result;

            dgvSubjects.Columns["SubjectID"].Visible = false;
            dgvSubjects.Columns["SubjectCode"].HeaderText = "Mã môn học";
            dgvSubjects.Columns["SubjectName"].HeaderText = "Tên môn học";
            dgvSubjects.Columns["Credits"].HeaderText = "Số tín chỉ";

            ClearFields();
        }

        // TẢI LẠI
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            LoadSubjects();
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