using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace be.codeblade.services
{
    public static class CBEncryptionService
    {
        public static string encrypt(string valueToEncrypt)
        {
            using (Aes aes = new AesManaged())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;          // in bits
                aes.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption
                aes.IV = new byte[128 / 8];   // AES needs a 16-byte IV
                // Should set Key and IV here.  Good approach: derive them from 
                // a password via Cryptography.Rfc2898DeriveBytes 
                byte[] cipherText = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(UTF8Encoding.UTF8.GetBytes(valueToEncrypt), 0, valueToEncrypt.Length);
                    }

                    cipherText = ms.ToArray();
                }

                return Convert.ToBase64String(cipherText);
            }
        }

        public static string decrypt(string valueToDecrypt)
        {
            using (Aes aes = new AesManaged())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = 128;          // in bits
                aes.Key = new byte[128 / 8];  // 16 bytes for 128 bit encryption
                aes.IV = new byte[128 / 8];   // AES needs a 16-byte IV

                // Should set Key and IV here.  Good approach: derive them from 
                // a password via Cryptography.Rfc2898DeriveBytes 
                byte[] cipherText = Convert.FromBase64String(valueToDecrypt);
                byte[] plainText = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                    }

                    plainText = ms.ToArray();
                }

                return UTF8Encoding.UTF8.GetString(plainText);
            }
        }
    }
}
