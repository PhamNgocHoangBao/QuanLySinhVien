namespace StudentManagement.UI
{
    partial class ClassForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblAcademicYear;

        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtAcademicYear;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.DataGridView dgvClasses;

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
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblAcademicYear = new System.Windows.Forms.Label();

            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtAcademicYear = new System.Windows.Forms.TextBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.dgvClasses = new System.Windows.Forms.DataGridView();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text = "QUẢN LÝ LỚP HỌC";
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // TITLE
            this.lblTitle.Text = "QUẢN LÝ LỚP HỌC";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(1060, 45);

            // LABELS
            SetupLabel(lblClassName, "Tên lớp", 40, 110);
            SetupLabel(lblDepartment, "Khoa", 570, 110);
            SetupLabel(lblAcademicYear, "Năm học", 40, 170);

            // INPUTS
            SetupTextBox(txtClassName, 170, 108, 320);

            SetupTextBox(txtAcademicYear, 170, 168, 320);

            this.cboDepartment.Location =
                new System.Drawing.Point(700, 108);
            this.cboDepartment.Size =
                new System.Drawing.Size(340, 30);
            this.cboDepartment.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // BUTTONS
            SetupButton(btnAdd, "THÊM", 40, 235, 110,
                System.Drawing.Color.FromArgb(40, 167, 69));

            SetupButton(btnUpdate, "SỬA", 165, 235, 110,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnDelete, "XÓA", 290, 235, 110,
                System.Drawing.Color.FromArgb(220, 53, 69));

            SetupButton(btnClear, "LÀM MỚI", 415, 235, 110,
                System.Drawing.Color.FromArgb(108, 117, 125));

            SetupButton(btnBack, "QUAY LẠI", 930, 235, 130,
                System.Drawing.Color.FromArgb(31, 78, 121));

            // SEARCH
            this.txtSearch.Location =
                new System.Drawing.Point(40, 315);
            this.txtSearch.Size =
                new System.Drawing.Size(350, 30);
            this.txtSearch.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            SetupButton(btnSearch, "TÌM KIẾM", 405, 310, 120,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnRefresh, "TẢI LẠI", 540, 310, 120,
                System.Drawing.Color.FromArgb(40, 167, 69));

            // DATAGRIDVIEW
            this.dgvClasses.Location =
                new System.Drawing.Point(40, 370);
            this.dgvClasses.Size =
                new System.Drawing.Size(1020, 240);

            this.dgvClasses.BackgroundColor = System.Drawing.Color.White;
            this.dgvClasses.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvClasses.AllowUserToAddRows = false;
            this.dgvClasses.AllowUserToDeleteRows = false;
            this.dgvClasses.ReadOnly = true;
            this.dgvClasses.MultiSelect = false;
            this.dgvClasses.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasses.RowHeadersVisible = false;

            this.dgvClasses.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvClasses.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvClasses.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.dgvClasses.EnableHeadersVisualStyles = false;
            this.dgvClasses.RowTemplate.Height = 30;

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

            this.dgvClasses.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvClasses_CellClick);

            // ADD CONTROLS
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblClassName);
            this.Controls.Add(lblDepartment);
            this.Controls.Add(lblAcademicYear);

            this.Controls.Add(txtClassName);
            this.Controls.Add(txtAcademicYear);
            this.Controls.Add(cboDepartment);
            this.Controls.Add(txtSearch);

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnBack);

            this.Controls.Add(dgvClasses);

            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
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
            label.Size = new System.Drawing.Size(120, 30);
            label.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        }

        private void SetupTextBox(
            System.Windows.Forms.TextBox textBox,
            int x,
            int y,
            int width)
        {
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(width, 30);
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