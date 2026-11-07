using System;
using System.Windows.Forms;
using StudentManagement.UI.Helpers;
using StudentManagement.BLL.Services;
using Microsoft.Extensions.Logging;
using StudentManagement.DAL.Logging;

namespace StudentManagement.UI
{
    public partial class LoginForm : Form
    {
        private static readonly ILogger logger = AppLogger.GetLogger<LoginForm>();

        private readonly UserBLL userBLL = new UserBLL();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                userBLL.Login(txtUsername.Text.Trim(), txtPassword.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                logger.LogWarning("Đăng nhập không thành công: {Message}", ex.Message);

                MessageHelper.Error(ex.Message);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}