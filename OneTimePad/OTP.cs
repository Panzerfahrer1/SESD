using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePad {
    public class OTP {
        private int wordLength;
        private string key;

        public string Encrypt(string word) {
            int paddingLength = 8;
            key = OTP.GenerateKey(word);
            while (paddingLength < word.Length) {
                paddingLength += 8;
            }

            //byte[] newKey = new byte[Math.Max(word.Length, key.Length)];
            byte[] wordByte = Encoding.UTF8.GetBytes(word);
            //byte[] keyByte = Encoding.UTF8.GetBytes(key);

            // Makes the key as long as the word
            //int c = 0;
            //for (int i = 0; i < word.Length; i++) {
            //    if(c >= key.Length) {
            //        c = 0;
            //    }
            //    newKey[i] = (byte)key[c++];
            //}

            // Here the key is as long as the word
            byte[] result = new byte[paddingLength];
            for(int i = 0; i < paddingLength; i++) {
                if(i > word.Length - 1) {
                    result[i] = (byte)'\x00';
                    continue;
                }
                result[i] = (byte)((byte)word[i] ^ key[i]);
            }

            wordLength = word.Length;

            return Encoding.UTF8.GetString(result); 
        }

        public string Decypt(string word) {
            byte[] wordByte = Encoding.UTF8.GetBytes(word);

            byte[] newKEy = new byte[wordByte.Length];

            // Makes the key as long as the word
            int c = 0;
            for (int i = 0; i < word.Length; i++) {
                if (c >= key.Length) {
                    c = 0;
                }
                newKEy[i] = (byte)key[c++];
            }

            // Here the key is as long as the word
            byte[] result = new byte[wordLength];
            for (int i = 0; i < wordLength; i++) {
                result[i] = (byte)((byte)word[i] ^ newKEy[i]);
            }

            return Encoding.UTF8.GetString(result);
        }

        public static string GenerateKey(string word) {
            Random random = new Random();
            int wordLength = word.Length;

            char[] generatedKey = new char[wordLength];

            for (int i = 0; i < wordLength; i++) {
                generatedKey[i] = (char)random.Next(126);
            }

            return new string(generatedKey);
        }
    }
}
