namespace StudentManagement.UI
{
    partial class DepartmentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.DataGridView dgvDepartments;

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
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.dgvDepartments = new System.Windows.Forms.DataGridView();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text = "QUẢN LÝ KHOA";
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // TITLE
            this.lblTitle.Text = "QUẢN LÝ KHOA";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(1060, 45);

            // LABELS
            this.lblDepartmentName.Text = "Tên khoa";
            this.lblDepartmentName.Location =
                new System.Drawing.Point(50, 110);
            this.lblDepartmentName.Size =
                new System.Drawing.Size(120, 30);
            this.lblDepartmentName.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblDescription.Text = "Mô tả";
            this.lblDescription.Location =
                new System.Drawing.Point(50, 165);
            this.lblDescription.Size =
                new System.Drawing.Size(120, 30);
            this.lblDescription.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // INPUTS
            this.txtDepartmentName.Location =
                new System.Drawing.Point(180, 108);
            this.txtDepartmentName.Size =
                new System.Drawing.Size(800, 30);
            this.txtDepartmentName.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtDescription.Location =
                new System.Drawing.Point(180, 163);
            this.txtDescription.Size =
                new System.Drawing.Size(800, 65);
            this.txtDescription.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.Multiline = true;

            // BUTTONS
            SetupButton(btnAdd, "THÊM", 50, 260, 110,
                System.Drawing.Color.FromArgb(40, 167, 69));

            SetupButton(btnUpdate, "SỬA", 175, 260, 110,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnDelete, "XÓA", 300, 260, 110,
                System.Drawing.Color.FromArgb(220, 53, 69));

            SetupButton(btnClear, "LÀM MỚI", 425, 260, 110,
                System.Drawing.Color.FromArgb(108, 117, 125));

            SetupButton(btnBack, "QUAY LẠI", 930, 260, 130,
                System.Drawing.Color.FromArgb(31, 78, 121));

            // SEARCH
            this.txtSearch.Location =
                new System.Drawing.Point(50, 330);
            this.txtSearch.Size =
                new System.Drawing.Size(350, 30);
            this.txtSearch.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            SetupButton(btnSearch, "TÌM KIẾM", 415, 325, 120,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnRefresh, "TẢI LẠI", 550, 325, 120,
                System.Drawing.Color.FromArgb(40, 167, 69));

            // DATAGRIDVIEW
            this.dgvDepartments.Location =
                new System.Drawing.Point(50, 390);
            this.dgvDepartments.Size =
                new System.Drawing.Size(1010, 220);

            this.dgvDepartments.BackgroundColor = System.Drawing.Color.White;
            this.dgvDepartments.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvDepartments.AllowUserToAddRows = false;
            this.dgvDepartments.AllowUserToDeleteRows = false;
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.MultiSelect = false;
            this.dgvDepartments.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartments.RowHeadersVisible = false;

            this.dgvDepartments.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvDepartments.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvDepartments.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.dgvDepartments.EnableHeadersVisualStyles = false;
            this.dgvDepartments.RowTemplate.Height = 30;

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

            this.dgvDepartments.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvDepartments_CellClick);

            // ADD CONTROLS
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblDepartmentName);
            this.Controls.Add(lblDescription);

            this.Controls.Add(txtDepartmentName);
            this.Controls.Add(txtDescription);
            this.Controls.Add(txtSearch);

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnBack);

            this.Controls.Add(dgvDepartments);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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