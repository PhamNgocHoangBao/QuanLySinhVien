namespace StudentManagement.UI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // FORM
            this.Text = "ĐĂNG NHẬP";
            this.ClientSize = new System.Drawing.Size(420, 330);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AcceptButton = this.btnLogin;
            this.CancelButton = this.btnExit;

            // TITLE
            this.lblTitle.Text = "ĐĂNG NHẬP";
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Size = new System.Drawing.Size(380, 45);

            // LABELS
            this.lblUsername.Text = "Tên đăng nhập";
            this.lblUsername.Location = new System.Drawing.Point(40, 95);
            this.lblUsername.Size = new System.Drawing.Size(340, 22);
            this.lblUsername.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblPassword.Text = "Mật khẩu";
            this.lblPassword.Location = new System.Drawing.Point(40, 165);
            this.lblPassword.Size = new System.Drawing.Size(340, 22);
            this.lblPassword.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // INPUTS
            this.txtUsername.Location = new System.Drawing.Point(40, 122);
            this.txtUsername.Size = new System.Drawing.Size(340, 30);
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);

            this.txtPassword.Location = new System.Drawing.Point(40, 192);
            this.txtPassword.Size = new System.Drawing.Size(340, 30);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.UseSystemPasswordChar = true;

            // BUTTONS
            SetupButton(btnLogin, "ĐĂNG NHẬP", 40, 255, 160,
                System.Drawing.Color.FromArgb(40, 167, 69));

            SetupButton(btnExit, "THOÁT", 220, 255, 160,
                System.Drawing.Color.FromArgb(108, 117, 125));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // EVENTS
            this.btnLogin.Click +=
                new System.EventHandler(this.btnLogin_Click);

            // ADD CONTROLS
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnExit);

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