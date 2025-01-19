using System.Security.Cryptography;
using System.Text;


namespace OnlineShop.Extensions
{
    public static class StringHelper
    {
        public static string GetHashedString(this string text)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
