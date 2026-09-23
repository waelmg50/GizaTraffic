using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public class Downloader
    {

        #region Methods

        /// <summary>
        /// Decrypt the string with word key.
        /// </summary>
        /// <param name="Text">The string to be decrypted.</param>
        /// <param name="Word">The key of the encryption.</param>
        /// <returns>Returns a tuple of true and the decrypted string if the encryption successded other wise it returns false and the error message.</returns>
        public static (bool, string) Download(string Text, string Word)
        {
            try
            {
                if (Text == null || Text.Length == 0)
                    return (false, string.Empty);
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(Text);

                MD5CryptoServiceProvider hashmd5 = new();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Word));

                TripleDESCryptoServiceProvider tdes = new()
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return (true, Encoding.UTF8.GetString(resultArray));
            }
            catch (FormatException ex)
            {
                if (ex.Message == "Invalid length for a Base-64 char array.")
                    return (false, "String is not encrypted.");
                else
                    return (false, ex.Message);
            }
            catch (CryptographicException ex)
            {
                if (ex.Message == "Length of the data to decrypt is invalid." || ex.Message == "Invalid character in a Base-64 string.")
                    return (false, "String is not encrypted.");
                else
                    return (false, ex.Message);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        /// <summary>
        /// Encrypt the string with word key.
        /// </summary>
        /// <param name="Text">The string to be encrypted.</param>
        /// <param name="Word">The key of the encryption.</param>
        /// <returns>Returns a tuple of true and the encrypted string if the encryption successded other wise it returns false and the error message.</returns>
        public static (bool, string) Upload(string Text, string Word)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(Text);

                MD5CryptoServiceProvider hashmd5 = new ();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Word));

                TripleDESCryptoServiceProvider tdes = new()
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return (true, Convert.ToBase64String(resultArray, 0, resultArray.Length));
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        #endregion

    }
}