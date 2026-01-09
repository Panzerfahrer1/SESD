using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
//using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Security.Cryptography;
//using System.Runtime.Intrinsics.X86;

namespace RSA_Multi_User_Verschlüsselung
{
    internal class Message
    {
        public User Sender { get; set; }
        public User Receiver { get; set; }

        public string? EncryptedMessage { get; private set; }

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
            //Send message logic here
        }
    }
}
