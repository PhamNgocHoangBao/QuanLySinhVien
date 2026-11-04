namespace StudentManagement.UI
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblClass;

        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cboClass;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvStudents;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblStudentCode = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();

            this.txtStudentCode = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cboClass = new System.Windows.Forms.ComboBox();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text = "QUẢN LÝ SINH VIÊN";
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // TITLE
            this.lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(1160, 45);

            // LABELS
            SetupLabel(lblStudentCode, "Mã sinh viên", 30, 90);
            SetupLabel(lblFullName, "Họ và tên", 30, 140);
            SetupLabel(lblDateOfBirth, "Ngày sinh", 30, 190);
            SetupLabel(lblGender, "Giới tính", 30, 240);

            SetupLabel(lblPhone, "Điện thoại", 600, 90);
            SetupLabel(lblEmail, "Email", 600, 140);
            SetupLabel(lblAddress, "Địa chỉ", 600, 190);
            SetupLabel(lblClass, "Lớp", 600, 240);

            // TEXTBOXES
            SetupTextBox(txtStudentCode, 160, 88, 350);
            SetupTextBox(txtFullName, 160, 138, 350);

            SetupTextBox(txtPhone, 730, 88, 400);
            SetupTextBox(txtEmail, 730, 138, 400);
            SetupTextBox(txtAddress, 730, 188, 400);

            // DATE OF BIRTH
            this.dtpDateOfBirth.Location =
                new System.Drawing.Point(160, 188);
            this.dtpDateOfBirth.Size =
                new System.Drawing.Size(350, 27);
            this.dtpDateOfBirth.Format =
                System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.ShowCheckBox = true;
            this.dtpDateOfBirth.Checked = false;

            // GENDER
            this.cboGender.Location =
                new System.Drawing.Point(160, 238);
            this.cboGender.Size =
                new System.Drawing.Size(350, 27);
            this.cboGender.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Items.AddRange(new object[]
            {
                "Nam",
                "Nữ",
                "Khác"
            });

            // CLASS
            this.cboClass.Location =
                new System.Drawing.Point(730, 238);
            this.cboClass.Size =
                new System.Drawing.Size(400, 27);
            this.cboClass.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // BUTTONS
            SetupButton(btnAdd, "THÊM", 30, 300, 110,
                System.Drawing.Color.FromArgb(40, 167, 69));

            SetupButton(btnUpdate, "SỬA", 155, 300, 110,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnDelete, "XÓA", 280, 300, 110,
                System.Drawing.Color.FromArgb(220, 53, 69));

            SetupButton(btnClear, "LÀM MỚI", 405, 300, 110,
                System.Drawing.Color.FromArgb(108, 117, 125));

            SetupButton(btnBack, "QUAY LẠI", 1030, 300, 130,
                System.Drawing.Color.FromArgb(31, 78, 121));

            // SEARCH
            this.txtSearch.Location =
                new System.Drawing.Point(30, 370);
            this.txtSearch.Size =
                new System.Drawing.Size(400, 27);
            this.txtSearch.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            SetupButton(btnSearch, "TÌM KIẾM", 445, 365, 120,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnRefresh, "TẢI LẠI", 580, 365, 120,
                System.Drawing.Color.FromArgb(40, 167, 69));

            // DATAGRIDVIEW
            this.dgvStudents.Location =
                new System.Drawing.Point(30, 420);
            this.dgvStudents.Size =
                new System.Drawing.Size(1130, 290);

            this.dgvStudents.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvStudents.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvStudents.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.RowHeadersVisible = false;

            this.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.RowTemplate.Height = 30;

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

            this.dgvStudents.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvStudents_CellClick);

            // ADD CONTROLS
            this.Controls.Add(lblTitle);

            this.Controls.Add(lblStudentCode);
            this.Controls.Add(lblFullName);
            this.Controls.Add(lblDateOfBirth);
            this.Controls.Add(lblGender);
            this.Controls.Add(lblPhone);
            this.Controls.Add(lblEmail);
            this.Controls.Add(lblAddress);
            this.Controls.Add(lblClass);

            this.Controls.Add(txtStudentCode);
            this.Controls.Add(txtFullName);
            this.Controls.Add(dtpDateOfBirth);
            this.Controls.Add(cboGender);
            this.Controls.Add(txtPhone);
            this.Controls.Add(txtEmail);
            this.Controls.Add(txtAddress);
            this.Controls.Add(cboClass);

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnBack);

            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(dgvStudents);

            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
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
            label.Size = new System.Drawing.Size(120, 27);
            label.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;
            label.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        }

        private void SetupTextBox(
            System.Windows.Forms.TextBox textBox,
            int x,
            int y,
            int width)
        {
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(width, 27);
            textBox.Font = new System.Drawing.Font("Segoe UI", 10F);
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