namespace StudentManagement.UI
{
    partial class SubjectForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubjectCode;
        private System.Windows.Forms.Label lblSubjectName;
        private System.Windows.Forms.Label lblCredits;

        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.NumericUpDown nudCredits;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.DataGridView dgvSubjects;

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
            this.lblSubjectCode = new System.Windows.Forms.Label();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();

            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.nudCredits = new System.Windows.Forms.NumericUpDown();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.dgvSubjects = new System.Windows.Forms.DataGridView();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCredits)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.Text = "QUẢN LÝ MÔN HỌC";
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // TITLE
            this.lblTitle.Text = "QUẢN LÝ MÔN HỌC";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(1060, 45);

            // LABELS
            this.lblSubjectCode.Text = "Mã môn học";
            this.lblSubjectCode.Location =
                new System.Drawing.Point(50, 110);
            this.lblSubjectCode.Size =
                new System.Drawing.Size(120, 30);
            this.lblSubjectCode.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblSubjectName.Text = "Tên môn học";
            this.lblSubjectName.Location =
                new System.Drawing.Point(50, 165);
            this.lblSubjectName.Size =
                new System.Drawing.Size(120, 30);
            this.lblSubjectName.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblCredits.Text = "Số tín chỉ";
            this.lblCredits.Location =
                new System.Drawing.Point(50, 220);
            this.lblCredits.Size =
                new System.Drawing.Size(120, 30);
            this.lblCredits.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // INPUTS
            this.txtSubjectCode.Location =
                new System.Drawing.Point(180, 108);
            this.txtSubjectCode.Size =
                new System.Drawing.Size(800, 30);
            this.txtSubjectCode.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.txtSubjectName.Location =
                new System.Drawing.Point(180, 163);
            this.txtSubjectName.Size =
                new System.Drawing.Size(800, 30);
            this.txtSubjectName.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.nudCredits.Location =
                new System.Drawing.Point(180, 218);
            this.nudCredits.Size =
                new System.Drawing.Size(200, 30);
            this.nudCredits.Minimum = 1;
            this.nudCredits.Maximum = 20;
            this.nudCredits.Value = 3;
            this.nudCredits.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            // BUTTONS
            SetupButton(btnAdd, "THÊM", 50, 285, 110,
                System.Drawing.Color.FromArgb(40, 167, 69));

            SetupButton(btnUpdate, "SỬA", 175, 285, 110,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnDelete, "XÓA", 300, 285, 110,
                System.Drawing.Color.FromArgb(220, 53, 69));

            SetupButton(btnClear, "LÀM MỚI", 425, 285, 110,
                System.Drawing.Color.FromArgb(108, 117, 125));

            SetupButton(btnBack, "QUAY LẠI", 930, 285, 130,
                System.Drawing.Color.FromArgb(31, 78, 121));

            // SEARCH
            this.txtSearch.Location =
                new System.Drawing.Point(50, 355);
            this.txtSearch.Size =
                new System.Drawing.Size(350, 30);
            this.txtSearch.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            SetupButton(btnSearch, "TÌM KIẾM", 415, 350, 120,
                System.Drawing.Color.FromArgb(0, 123, 255));

            SetupButton(btnRefresh, "TẢI LẠI", 550, 350, 120,
                System.Drawing.Color.FromArgb(40, 167, 69));

            // DATAGRIDVIEW
            this.dgvSubjects.Location =
                new System.Drawing.Point(50, 410);
            this.dgvSubjects.Size =
                new System.Drawing.Size(1010, 200);

            this.dgvSubjects.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubjects.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvSubjects.AllowUserToAddRows = false;
            this.dgvSubjects.AllowUserToDeleteRows = false;
            this.dgvSubjects.ReadOnly = true;
            this.dgvSubjects.MultiSelect = false;
            this.dgvSubjects.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubjects.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubjects.RowHeadersVisible = false;

            this.dgvSubjects.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvSubjects.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvSubjects.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.dgvSubjects.EnableHeadersVisualStyles = false;
            this.dgvSubjects.RowTemplate.Height = 30;

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

            this.dgvSubjects.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvSubjects_CellClick);

            // ADD CONTROLS
            this.Controls.Add(lblTitle);

            this.Controls.Add(lblSubjectCode);
            this.Controls.Add(lblSubjectName);
            this.Controls.Add(lblCredits);

            this.Controls.Add(txtSubjectCode);
            this.Controls.Add(txtSubjectName);
            this.Controls.Add(nudCredits);
            this.Controls.Add(txtSearch);

            this.Controls.Add(btnAdd);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnBack);

            this.Controls.Add(dgvSubjects);

            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCredits)).EndInit();
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