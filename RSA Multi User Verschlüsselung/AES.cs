using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSA_Multi_User_Verschlüsselung
{
    public static class AES
    {
        public static (byte[] message, byte[] key, byte[] iv) Encrypt(byte[] data)
        {
            byte[] result;
            byte[] ivBytes;
            byte[] keyBytes;

            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                aes.GenerateKey();

                keyBytes = aes.Key;
                ivBytes = aes.IV;

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
            
            return (result, keyBytes, ivBytes);
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


        //TODO Fix this
        public static byte[] Decrypt(byte[] encryptedData, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream(encryptedData))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var resultStream = new MemoryStream())
                {
                    cs.CopyTo(resultStream);
                    return resultStream.ToArray();
                }
            }
        }
    }
}