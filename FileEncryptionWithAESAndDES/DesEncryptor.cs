using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptionWithAESAndDES {
    internal class DesEncryptor : FileEncryptor {
        private byte[] key;
        private byte[] iv;

        public override void Encrypt(string inputFile, string outputFile) {
            using (DES des = DES.Create()) {
                des.GenerateKey();
                des.GenerateIV();

                key = des.Key;
                iv = des.IV;

                using FileStream input = File.OpenRead(inputFile);
                using FileStream output = File.OpenWrite(outputFile);
                using CryptoStream cs = new(output, des.CreateEncryptor(), CryptoStreamMode.Write);

                input.CopyTo(cs);
            }
        }

        public override void Decrypt(string inputFile, string outputFile) {
            using (DES des = DES.Create()) {
                using FileStream input = File.OpenRead(inputFile);
                using FileStream output = File.OpenWrite(outputFile);
                using CryptoStream cs = new(output, des.CreateDecryptor(key, iv), CryptoStreamMode.Write);

                input.CopyTo(cs);
            }
        }
    }
}