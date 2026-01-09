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
    internal class Message
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
            byte[] encryptedMessage = AES.Encrypt(byteMessage);

            EncryptedMessage = Encoding.UTF8.GetString(encryptedMessage);

            EncryptKey();
            EncryptIV();

            MessageLog.Add(this);
        }

        private void EncryptKey()
        {
            byte[] aesKey;

            using (var aes = Aes.Create())
            {
                aes.GenerateKey();

                aesKey = aes.Key;
            }

            EncryptedAESKey = AES.Encrypt(aesKey, Receiver.PublicKey);
        }

        private void EncryptIV()
        {
            byte[] aesIV;

            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                aesIV = aes.IV;
            }

            EncryptedAESIV = AES.Encrypt(aesIV, Receiver.PublicKey);
        }
    }
}
