using System.Windows.Forms;

namespace StudentManagement.UI.Helpers
{
    public static class MessageHelper
    {
        public static void Success(string message)
        {
            MessageBox.Show(
                message,
                "Thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void Error(string message)
        {
            MessageBox.Show(
                message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static bool Confirm(string message)
        {
            return MessageBox.Show(
                message,
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}