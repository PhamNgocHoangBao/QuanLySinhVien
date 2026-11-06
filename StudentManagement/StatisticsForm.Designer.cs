namespace StudentManagement.UI
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentTitle;
        private System.Windows.Forms.Label lblClassTitle;
        private System.Windows.Forms.Label lblDepartmentTitle;
        private System.Windows.Forms.Label lblSubjectTitle;

        private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.Label lblClassCount;
        private System.Windows.Forms.Label lblDepartmentCount;
        private System.Windows.Forms.Label lblSubjectCount;

        private System.Windows.Forms.Label lblRankingTitle;
        private System.Windows.Forms.DataGridView dgvRanking;
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
            this.lblStudentTitle = new System.Windows.Forms.Label();
            this.lblClassTitle = new System.Windows.Forms.Label();
            this.lblDepartmentTitle = new System.Windows.Forms.Label();
            this.lblSubjectTitle = new System.Windows.Forms.Label();

            this.lblStudentCount = new System.Windows.Forms.Label();
            this.lblClassCount = new System.Windows.Forms.Label();
            this.lblDepartmentCount = new System.Windows.Forms.Label();
            this.lblSubjectCount = new System.Windows.Forms.Label();

            this.lblRankingTitle = new System.Windows.Forms.Label();
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text = "Thống kê sinh viên";
            this.Size = new System.Drawing.Size(1100, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;

            // Title
            this.lblTitle.Text = "THỐNG KÊ HỆ THỐNG";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F,
                System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Size = new System.Drawing.Size(600, 45);

            // Card titles and values
            SetupCard(this.lblStudentTitle, this.lblStudentCount,
                "Tổng sinh viên", 30);

            SetupCard(this.lblClassTitle, this.lblClassCount,
                "Tổng lớp học", 285);

            SetupCard(this.lblDepartmentTitle, this.lblDepartmentCount,
                "Tổng khoa", 540);

            SetupCard(this.lblSubjectTitle, this.lblSubjectCount,
                "Tổng môn học", 795);

            // Ranking title
            this.lblRankingTitle.Text = "BẢNG XẾP HẠNG SINH VIÊN";
            this.lblRankingTitle.Font = new System.Drawing.Font(
                "Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRankingTitle.Location = new System.Drawing.Point(30, 200);
            this.lblRankingTitle.Size = new System.Drawing.Size(500, 35);

            // Ranking grid
            this.dgvRanking.Location = new System.Drawing.Point(30, 245);
            this.dgvRanking.Size = new System.Drawing.Size(1020, 330);
            this.dgvRanking.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRanking.ReadOnly = true;
            this.dgvRanking.AllowUserToAddRows = false;
            this.dgvRanking.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRanking.MultiSelect = false;
            this.dgvRanking.RowHeadersVisible = false;

            // Refresh button
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Location = new System.Drawing.Point(800, 600);
            this.btnRefresh.Size = new System.Drawing.Size(110, 40);
            this.btnRefresh.Click += new System.EventHandler(
                this.btnRefresh_Click);

            // Back button
            this.btnBack.Text = "Quay lại";
            this.btnBack.Location = new System.Drawing.Point(930, 600);
            this.btnBack.Size = new System.Drawing.Size(110, 40);
            this.btnBack.Click += new System.EventHandler(
                this.btnBack_Click);

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.lblStudentTitle);
            this.Controls.Add(this.lblStudentCount);

            this.Controls.Add(this.lblClassTitle);
            this.Controls.Add(this.lblClassCount);

            this.Controls.Add(this.lblDepartmentTitle);
            this.Controls.Add(this.lblDepartmentCount);

            this.Controls.Add(this.lblSubjectTitle);
            this.Controls.Add(this.lblSubjectCount);

            this.Controls.Add(this.lblRankingTitle);
            this.Controls.Add(this.dgvRanking);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBack);

            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupCard(
            System.Windows.Forms.Label title,
            System.Windows.Forms.Label value,
            string text,
            int x)
        {
            title.Text = text;
            title.Font = new System.Drawing.Font("Segoe UI", 11F,
                System.Drawing.FontStyle.Bold);
            title.Location = new System.Drawing.Point(x, 100);
            title.Size = new System.Drawing.Size(220, 30);

            value.Text = "0";
            value.Font = new System.Drawing.Font("Segoe UI", 22F,
                System.Drawing.FontStyle.Bold);
            value.ForeColor = System.Drawing.Color.DarkBlue;
            value.Location = new System.Drawing.Point(x, 135);
            value.Size = new System.Drawing.Size(220, 45);
        }
    }
}