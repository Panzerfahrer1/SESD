using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
//using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
//using System.Runtime.Intrinsics.X86;

namespace RSA_Multi_User_Verschlüsselung
{
    public class Message
    {
        public static List<Message> MessageLog = new List<Message>();
        public User Sender { get; set; }
        public User Receiver { get; set; }

        public string? EncryptedMessage { get; private set; }
        public byte[] EncryptedAESKey { get; private set; }
        public byte[] EncryptedAESIV {  get; private set; }

        public Message(User sender, User receiver)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (receiver == null)
                throw new ArgumentNullException(nameof(receiver));

            Sender = sender;
            Receiver = receiver;
        }

        public void Send(string message)
        {
            byte[] byteMessage = Encoding.UTF8.GetBytes(message);
            (byte[] encryptedMessage, byte[] key, byte[] iv) = AES.Encrypt(byteMessage);

            EncryptedMessage = Encoding.UTF8.GetString(encryptedMessage);

            EncryptedAESIV = EncryptIvRsa(iv);
            EncryptedAESKey = EncryptKeyRsa(key);

            MessageLog.Add(this);
            Console.WriteLine();
        }

        private byte[] EncryptKeyRsa(byte[] key)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(Receiver.PublicKey, out _);

                return rsa.Encrypt(
                    key,
                    RSAEncryptionPadding.OaepSHA256
                );
            }
        }

        private byte[] EncryptIvRsa(byte[] iv)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(Receiver.PublicKey, out _);

                return rsa.Encrypt(
                    iv,
                    RSAEncryptionPadding.OaepSHA256
                );
            }
        }
    }
}
