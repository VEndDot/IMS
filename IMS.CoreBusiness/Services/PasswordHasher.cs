using System.Security.Cryptography;
using System.Text;

namespace IMS.CoreBusiness.Services
{
    public static class PasswordHasher
    {
        private const int ExpectedHashLength = 44;

        public static string Hash(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public static bool Verify(string password, string hash)
        {
            var computedHash = Hash(password);
            return computedHash == hash;
        }

        public static bool IsHashed(string passwordOrHash)
        {
            if (string.IsNullOrWhiteSpace(passwordOrHash))
                return false;

            if (passwordOrHash.Length != ExpectedHashLength)
                return false;

            try
            {
                Convert.FromBase64String(passwordOrHash);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
