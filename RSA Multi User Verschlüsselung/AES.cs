using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSA_Multi_User_Verschlüsselung
{
    public static class AES
    {
        public static byte[] Encrypt(byte[] data)
        {
            byte[] result;

            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                aes.GenerateKey();

                using (var encryptor = aes.CreateEncryptor())
                using (var memorySteram = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memorySteram, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(data, 0, data.Length);
                        
                        cryptoStream.FlushFinalBlock();
                    }

                    result = memorySteram.ToArray();
                }
            }

            return result;
        }

        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            byte[] result;

            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                aes.Key = key;

                using (var encryptor = aes.CreateEncryptor())
                using (var memorySteram = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memorySteram, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(data, 0, data.Length);

                        cryptoStream.FlushFinalBlock();
                    }

                    result = memorySteram.ToArray();
                }
            }

            return result;
        }
    }
}
