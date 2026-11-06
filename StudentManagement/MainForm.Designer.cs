namespace StudentManagement
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();

            this.lblLogo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.btnStudents = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnGrades = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // FORM
            this.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // SIDEBAR
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(250, 750);
            this.pnlSidebar.BackColor =
                System.Drawing.Color.FromArgb(31, 45, 61);
            this.pnlSidebar.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            // LOGO
            this.lblLogo.Text = "STUDENT\nMANAGEMENT";
            this.lblLogo.Location = new System.Drawing.Point(15, 25);
            this.lblLogo.Size = new System.Drawing.Size(220, 75);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Font = new System.Drawing.Font(
                "Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblLogo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // SIDEBAR BUTTONS
            SetupMenuButton(btnStudents, "QUẢN LÝ SINH VIÊN", 120);
            SetupMenuButton(btnClasses, "QUẢN LÝ LỚP HỌC", 180);
            SetupMenuButton(btnDepartments, "QUẢN LÝ KHOA", 240);
            SetupMenuButton(btnSubjects, "QUẢN LÝ MÔN HỌC", 300);
            SetupMenuButton(btnGrades, "QUẢN LÝ ĐIỂM", 360);
            SetupMenuButton(btnStatistics, "THỐNG KÊ - BÁO CÁO", 420);

            SetupMenuButton(btnExit, "THOÁT CHƯƠNG TRÌNH", 650);
            btnExit.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);

            // HEADER
            this.pnlHeader.Location = new System.Drawing.Point(250, 0);
            this.pnlHeader.Size = new System.Drawing.Size(950, 80);
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.lblHeader.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            this.lblHeader.Location = new System.Drawing.Point(30, 20);
            this.lblHeader.Size = new System.Drawing.Size(700, 40);
            this.lblHeader.Font = new System.Drawing.Font(
                "Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor =
                System.Drawing.Color.FromArgb(31, 78, 121);

            // CONTENT
            this.pnlContent.Location = new System.Drawing.Point(250, 80);
            this.pnlContent.Size = new System.Drawing.Size(950, 670);
            this.pnlContent.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlContent.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.lblWelcome.Text = "CHÀO MỪNG ĐẾN VỚI HỆ THỐNG";
            this.lblWelcome.Location = new System.Drawing.Point(70, 180);
            this.lblWelcome.Size = new System.Drawing.Size(810, 60);
            this.lblWelcome.Font = new System.Drawing.Font(
                "Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor =
                System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblWelcome.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            this.lblDescription.Text =
                "Phần mềm hỗ trợ quản lý sinh viên, lớp học, khoa, môn học và kết quả học tập.";
            this.lblDescription.Location = new System.Drawing.Point(70, 255);
            this.lblDescription.Size = new System.Drawing.Size(810, 60);
            this.lblDescription.Font =
                new System.Drawing.Font("Segoe UI", 11F);
            this.lblDescription.ForeColor =
                System.Drawing.Color.FromArgb(90, 100, 110);
            this.lblDescription.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // EVENTS
            this.btnStudents.Click +=
                new System.EventHandler(this.btnStudents_Click);

            this.btnClasses.Click +=
                new System.EventHandler(this.btnClasses_Click);

            this.btnDepartments.Click +=
                new System.EventHandler(this.btnDepartments_Click);

            this.btnSubjects.Click +=
                new System.EventHandler(this.btnSubjects_Click);

            this.btnGrades.Click +=
                new System.EventHandler(this.btnGrades_Click);

            this.btnStatistics.Click +=
                new System.EventHandler(this.btnStatistics_Click);

            this.btnExit.Click +=
                new System.EventHandler(this.btnExit_Click);

            // ADD SIDEBAR CONTROLS
            this.pnlSidebar.Controls.Add(lblLogo);
            this.pnlSidebar.Controls.Add(btnStudents);
            this.pnlSidebar.Controls.Add(btnClasses);
            this.pnlSidebar.Controls.Add(btnDepartments);
            this.pnlSidebar.Controls.Add(btnSubjects);
            this.pnlSidebar.Controls.Add(btnGrades);
            this.pnlSidebar.Controls.Add(btnStatistics);
            this.pnlSidebar.Controls.Add(btnExit);

            // ADD HEADER CONTROLS
            this.pnlHeader.Controls.Add(lblHeader);

            // ADD CONTENT CONTROLS
            this.pnlContent.Controls.Add(lblWelcome);
            this.pnlContent.Controls.Add(lblDescription);

            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlSidebar);

            this.ResumeLayout(false);
        }

        private void SetupMenuButton(
            System.Windows.Forms.Button button,
            string text,
            int y)
        {
            button.Text = text;
            button.Location = new System.Drawing.Point(15, y);
            button.Size = new System.Drawing.Size(220, 45);
            button.BackColor =
                System.Drawing.Color.FromArgb(44, 62, 80);
            button.ForeColor = System.Drawing.Color.White;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            button.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;
            button.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            button.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}