using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FileEncryptionWithAESAndDES {
    internal class AesEncryptor : FileEncryptor {
        private byte[] key;
        private byte[] iv;

        public override void Encrypt(string inputFile, string outputFile) {
            using (Aes aes = Aes.Create()) {
                aes.GenerateKey();
                aes.GenerateIV();

                key = aes.Key;
                iv = aes.IV;

                using FileStream input = File.OpenRead(inputFile);
                using FileStream output = File.OpenWrite(outputFile);
                using CryptoStream cs = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);

                input.CopyTo(cs);
            }
        }

        public override void Decrypt(string inputFile, string outputFile) {
            using (Aes aes = Aes.Create()) {
                using FileStream input = File.OpenRead(inputFile);
                using FileStream output = File.OpenWrite(outputFile);
                using CryptoStream cs = new(output, aes.CreateDecryptor(key, iv), CryptoStreamMode.Write);

                input.CopyTo(cs);
            }
        }

    }
}
