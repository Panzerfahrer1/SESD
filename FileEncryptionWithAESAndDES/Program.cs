using FileEncryptionWithAESAndDES;
using System.Security.Cryptography;

DesEncryptor desEncryptor = new DesEncryptor();
AesEncryptor aesEncryptor = new AesEncryptor();

aesEncryptor.Encrypt("test.txt", "encrypted.txt");
aesEncryptor.Decrypt("encrypted.txt", "plain.txt");