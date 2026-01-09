using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1TestLernen {
    public class Summenverfahren {
        public string Encrypt(string word, string key) {
            byte[] result = new byte[word.Length];

            for (int i = 0; i < word.Length; i++) {
                result[i] = (byte)(word[i] + key[i % (key.Length)]);
            }

            return Encoding.ASCII.GetString(result);
        }

        public string Decrypt(string word, string key) {
            byte[] result = new byte[word.Length];

            for (int i = 0; i < word.Length; i++) {
                result[i] = (byte)(word[i] - key[i % (key.Length)]);
            }

            return Encoding.ASCII.GetString(result);
        }
    }

    public class CaecarCypher {
        public string Encrypt(string word, int shift) {
            byte[] result = new byte[word.Length];

            for (int i = 0; i < word.Length; i++) {
                int position = word[i] - 'A';
                int newPos = (position + shift) % 26;
                result[i] = (byte)(newPos + 'A');
            }

            return Encoding.ASCII.GetString(result);
        }

        public string Decrypt(string word, int shift) {
            return Encrypt(word, shift);
        }
    }

    public class XOR {
        public string Encrypt(string word, string key) {
            byte[] result = new byte[word.Length];

            for (int i = 0; i < word.Length; i++) {
                result[i] = (byte)(word[i] ^ key[i % key.Length]);
            }

            return Encoding.ASCII.GetString(result);
        }

        public string Decrypt(string word, string key) {
            return Encrypt(word, key);
        }
    }
}