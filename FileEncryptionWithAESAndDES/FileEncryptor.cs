using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptionWithAESAndDES {
    public abstract class FileEncryptor {
        public abstract void Encrypt(string input, string output);
        public abstract void Decrypt(string input, string output);
    }
}
