using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public static class ConnectionStringProtector
    {
        private static readonly byte[] Entropy =
        Encoding.UTF8.GetBytes(
            "GizaTraffic.ConnectionString.v1");
        public static string Protect(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                throw new ArgumentException(
                    "Connection string cannot be empty.",
                    nameof(plainText));

            byte[] plainBytes =
                Encoding.UTF8.GetBytes(plainText);

            byte[] encryptedBytes =
                ProtectedData.Protect(
                    plainBytes,
                    Entropy,
                    DataProtectionScope.LocalMachine);

            return Convert.ToBase64String(encryptedBytes);
        }
        public static string Unprotect(string encryptedText)
        {
            if (string.IsNullOrWhiteSpace(encryptedText))
                throw new ArgumentException(
                    "Encrypted connection string cannot be empty.",
                    nameof(encryptedText));

            try
            {
                byte[] encryptedBytes =
                    Convert.FromBase64String(encryptedText);

                byte[] plainBytes =
                    ProtectedData.Unprotect(
                        encryptedBytes,
                        Entropy,
                        DataProtectionScope.LocalMachine);

                return Encoding.UTF8.GetString(plainBytes);
            }
            catch (CryptographicException ex)
            {
                throw new InvalidOperationException(
                    "Unable to decrypt the database connection string. " +
                    "The encrypted value may belong to another computer.",
                    ex);
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException("The encrypted connection string is invalid.", ex);
            }
        }

        public static bool IsEncrypted(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            try
            {
                string decrypted = Unprotect(value);
                return !string.IsNullOrWhiteSpace(decrypted) && decrypted.Contains('=');
            }
            catch
            {
                return false;
            }
        }
    }
}