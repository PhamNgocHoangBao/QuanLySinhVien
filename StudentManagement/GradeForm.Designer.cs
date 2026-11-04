namespace StudentManagement.UI
{
    partial class GradeForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblMidterm;
        private System.Windows.Forms.Label lblFinal;
        private System.Windows.Forms.Label lblTotal;

        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.ComboBox cboSubject;

        private System.Windows.Forms.NumericUpDown nudSemester;
        private System.Windows.Forms.NumericUpDown nudMidterm;
        private System.Windows.Forms.NumericUpDown nudFinal;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.TextBox txtTotal;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvGrades;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblMidterm = new System.Windows.Forms.Label();
            this.lblFinal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.cboSubject = new System.Windows.Forms.ComboBox();

            this.nudSemester = new System.Windows.Forms.NumericUpDown();
            this.nudMidterm = new System.Windows.Forms.NumericUpDown();
            this.nudFinal = new System.Windows.Forms.NumericUpDown();

            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.dgvGrades = new System.Windows.Forms.DataGridView();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMidterm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinal)).BeginInit();

            this.SuspendLayout();

            // FORM
            this.Text = "QUẢN LÝ ĐIỂM SINH VIÊN";
            this.ClientSize = new System.Drawing.Size(1150, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // TITLE
            this.lblTitle.Text = "QUẢN LÝ ĐIỂM SINH VIÊN";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(1110, 45);

            // LABELS
            SetupLabel(lblStudent, "Sinh viên", 40, 95);
            SetupLabel(lblSubject, "Môn học", 590, 95);
            SetupLabel(lblSemester, "Học kỳ", 40, 155);
            SetupLabel(lblSchoolYear, "Năm học", 590, 155);
            SetupLabel(lblMidterm, "Điểm giữa kỳ", 40, 215);
            SetupLabel(lblFinal, "Điểm cuối kỳ", 590, 215);
            SetupLabel(lblTotal, "Điểm tổng kết", 40, 275);

            // STUDENT
            this.cboStudent.Location =
                new System.Drawing.Point(180, 93);
            this.cboStudent.Size =
                new System.Drawing.Size(340, 30);
            this.cboStudent.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            // SUBJECT
            this.cboSubject.Location =
                new System.Drawing.Point(730, 93);
            this.cboSubject.Size =
                new System.Drawing.Size(350, 30);
            this.cboSubject.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            // SEMESTER
            this.nudSemester.Location =
                new System.Drawing.Point(180, 153);
            this.nudSemester.Size =
                new System.Drawing.Size(150, 30);
            this.nudSemester.Minimum = 1;
            this.nudSemester.Maximum = 3;
            this.nudSemester.Value = 1;

            // SCHOOL YEAR
            this.txtSchoolYear.Location =
                new System.Drawing.Point(730, 153);
            this.txtSchoolYear.Size =
                new System.Drawing.Size(350, 30);
            this.txtSchoolYear.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.txtSchoolYear.PlaceholderText = "Ví dụ: 2026-2027";

            // MIDTERM
            this.nudMidterm.Location =
                new System.Drawing.Point(180, 213);
            this.nudMidterm.Size =
                new System.Drawing.Size(150, 30);
            this.nudMidterm.DecimalPlaces = 2;
            this.nudMidterm.Increment = 0.25M;
            this.nudMidterm.Minimum = 0;
            this.nudMidterm.Maximum = 10;

            // FINAL
            this.nudFinal.Location =
                new System.Drawing.Point(730, 213);
            this.nudFinal.Size =
                new System.Drawing.Size(150, 30);
            this.nudFinal.DecimalPlaces = 2;
            this.nudFinal.Increment = 0.25M;
            this.nudFinal.Minimum = 0;
            this.nudFinal.Maximum = 10;

            // TOTAL
            this.txtTotal.Location =
                new System.Drawing.Point(180, 273);
            this.txtTotal.Size =
                new System.Drawing.Size(150, 30);
            this.txtTotal.ReadOnly = true;
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font =
                new System.Drawing.Font("Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);

            // BUTTONS
            SetupButton(btnAdd, "THÊM", 40, 335, 110,
                System.Drawing.Color.FromArgb(40, 167, 69));

            SetupButton(btnUpdate, "SỬA", 165, 335, 110,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnDelete, "XÓA", 290, 335, 110,
                System.Drawing.Color.FromArgb(220, 53, 69));

            SetupButton(btnClear, "LÀM MỚI", 415, 335, 110,
                System.Drawing.Color.FromArgb(108, 117, 125));

            SetupButton(btnBack, "QUAY LẠI", 970, 335, 130,
                System.Drawing.Color.FromArgb(31, 78, 121));

            // SEARCH
            this.txtSearch.Location =
                new System.Drawing.Point(40, 405);
            this.txtSearch.Size =
                new System.Drawing.Size(350, 30);
            this.txtSearch.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            SetupButton(btnSearch, "TÌM KIẾM", 405, 400, 120,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnRefresh, "TẢI LẠI", 540, 400, 120,
                System.Drawing.Color.FromArgb(40, 167, 69));

            // DATAGRIDVIEW
            this.dgvGrades.Location =
                new System.Drawing.Point(40, 460);
            this.dgvGrades.Size =
                new System.Drawing.Size(1060, 220);

            this.dgvGrades.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrades.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.ReadOnly = true;
            this.dgvGrades.MultiSelect = false;
            this.dgvGrades.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrades.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.RowHeadersVisible = false;

            this.dgvGrades.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvGrades.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvGrades.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.dgvGrades.EnableHeadersVisualStyles = false;
            this.dgvGrades.RowTemplate.Height = 30;

            // EVENTS
            this.btnAdd.Click +=
                new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Click +=
                new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Click +=
                new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Click +=
                new System.EventHandler(this.btnClear_Click);

            this.btnSearch.Click +=
                new System.EventHandler(this.btnSearch_Click);

            this.btnRefresh.Click +=
                new System.EventHandler(this.btnRefresh_Click);

            this.btnBack.Click +=
                new System.EventHandler(this.btnBack_Click);

            this.dgvGrades.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvGrades_CellClick);

            this.nudMidterm.ValueChanged +=
                new System.EventHandler(this.Score_ValueChanged);

            this.nudFinal.ValueChanged +=
                new System.EventHandler(this.Score_ValueChanged);

            // ADD CONTROLS
            this.Controls.Add(lblTitle);

            this.Controls.Add(lblStudent);
            this.Controls.Add(lblSubject);
            this.Controls.Add(lblSemester);
            this.Controls.Add(lblSchoolYear);
            this.Controls.Add(lblMidterm);
            this.Controls.Add(lblFinal);
            this.Controls.Add(lblTotal);

            this.Controls.Add(cboStudent);
            this.Controls.Add(cboSubject);

            this.Controls.Add(nudSemester);
            this.Controls.Add(nudMidterm);
            this.Controls.Add(nudFinal);

            this.Controls.Add(txtSchoolYear);
            this.Controls.Add(txtTotal);
            this.Controls.Add(txtSearch);

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnBack);

            this.Controls.Add(dgvGrades);

            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMidterm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinal)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupLabel(
            System.Windows.Forms.Label label,
            string text,
            int x,
            int y)
        {
            label.Text = text;
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(130, 30);
            label.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        }

        private void SetupButton(
            System.Windows.Forms.Button button,
            string text,
            int x,
            int y,
            int width,
            System.Drawing.Color color)
        {
            button.Text = text;
            button.Location = new System.Drawing.Point(x, y);
            button.Size = new System.Drawing.Size(width, 40);
            button.BackColor = color;
            button.ForeColor = System.Drawing.Color.White;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}