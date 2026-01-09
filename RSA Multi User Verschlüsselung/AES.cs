using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSA_Multi_User_Verschlüsselung
{
    internal class AES
    {
        private byte[] aesKey;
        private byte[] aesIV;
        public AES(byte[] key)
        {
            aesKey = key;
        }

        public byte[] Encrypt(byte[] data)
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                aes.GenerateKey();
            }
        }
    }
}
