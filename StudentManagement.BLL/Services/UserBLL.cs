using System;
using System.Security.Cryptography;
using StudentManagement.DTO;
using StudentManagement.DAL.Repositories;
using Microsoft.Extensions.Logging;
using StudentManagement.DAL.Logging;

namespace StudentManagement.BLL.Services
{
    public class UserBLL
    {
        private static readonly ILogger logger = AppLogger.GetLogger<UserBLL>();
        private readonly UserDAL userDAL = new UserDAL();

        private const int Iterations = 100_000;

        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Vui lòng nhập tên đăng nhập.");

            if (string.IsNullOrEmpty(password))
                throw new Exception("Vui lòng nhập mật khẩu.");

            UserDTO user = userDAL.GetByUsername(username.Trim());

            if (user == null || !user.IsActive || !VerifyPassword(password, user.PasswordHash))
            {
                logger.LogWarning("Đăng nhập thất bại: {Username}", username);
                throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            logger.LogInformation("Đăng nhập thành công: {Username}", user.Username);
            return user;
        }

        // Tạo tài khoản admin mặc định nếu bảng Users đang trống.
        public void EnsureDefaultAdmin()
        {
            if (userDAL.Count() > 0)
                return;

            userDAL.Insert(new UserDTO
            {
                Username = "admin",
                PasswordHash = HashPassword("Admin@123"),
                IsActive = true
            });

            logger.LogInformation("Đã tạo tài khoản admin mặc định");
        }

        private static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, Iterations, HashAlgorithmName.SHA256, 32);

            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        private static bool VerifyPassword(string password, string stored)
        {
            string[] parts = stored.Split(':');
            if (parts.Length != 2)
                return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] expected = Convert.FromBase64String(parts[1]);

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, Iterations, HashAlgorithmName.SHA256, expected.Length);

            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
    }
}