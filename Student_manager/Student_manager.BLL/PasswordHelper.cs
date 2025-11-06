using System;
using System.Security.Cryptography;
using System.Text;

namespace Student_manager.BLL
{
    public static class PasswordHelper
    {
        public static string HashSha256(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                var sb = new StringBuilder();
                foreach (var b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
