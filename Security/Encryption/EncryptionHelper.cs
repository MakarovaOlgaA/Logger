namespace Security.Encryption
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public static class EncryptionHelper
    {
        public static string Encryprt(string message, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(message);
            byte[] resultArray;

            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
            {
                Key = UTF8Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            })
            {
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            }

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public static string Decryprt(string message, string key)
        {
            byte[] inputArray = Convert.FromBase64String(message);
            byte[] resultArray;

            using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
            {
                Key = UTF8Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            })
            {
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            }

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
