using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RSA_Multi_User_Verschlüsselung
{
    public class User
    {
        //patterns for Regex password validation
        private static Regex hasMinLength = new("^.{8,}$"); // atleast 8 characters
        private static Regex hasNumber = new("[0-9]+");     // atleast one number
        private static Regex hasUpperChar = new("[A-Z]+"); // atleast one uppercase letter
        private static Regex hasLowerChar = new("[a-z]+");  // atleast one lowercase letter
        private static Regex hasSpecialLetter = new(@"\W"); // atleast one special letter

        public string? Username { get; set; }
        //This is the user Password, its not relevant for the encryting itself
        public string? PrivateKeyPassword { get; private set; }
        public byte[] PublicKey { get; private set; }

        private byte[] privateKey;
        private RSA rsa;

        public User(string username, string privateKeyPassword)
        {
            IsValidPassword(privateKeyPassword);

            CreateRSA();

            Username = username;
            PrivateKeyPassword = privateKeyPassword;
        }

        /// <summary>
        /// Initializes a new RSA key pair with the specified key length.
        /// </summary>
        /// <remarks>This method replaces any existing RSA key pair with a newly generated one. Larger key
        /// sizes provide greater security but may impact performance.</remarks>
        /// <param name="length">The length, in bits, of the RSA key to generate. Must be at least 384. The default is 2048.</param>
        private void CreateRSA(int length = 2048)
        {
            rsa = RSA.Create(length);

            privateKey = rsa.ExportRSAPrivateKey();
            PublicKey = rsa.ExportRSAPublicKey();
        }

        /// <summary>
        /// Determines whether the specified password meets the required complexity criteria.
        /// </summary>
        /// <remarks>The password must be at least 8 characters long and contain at least one uppercase
        /// letter, one lowercase letter, one digit, and one special character (excluding the underscore
        /// character).</remarks>
        /// <param name="password">The password string to validate. Cannot be null. The password must meet all complexity requirements to be
        /// considered valid.</param>
        /// <exception cref="InvalidPasswordException">Thrown if the password does not meet one or more of the required complexity criteria.</exception>
        private void IsValidPassword(string password)
        {
            if (!hasMinLength.IsMatch(password))
            {
                throw new InvalidPasswordException("Password should atleast be 8 characters long");
            }

            if (!hasNumber.IsMatch(password))
            {
                throw new InvalidPasswordException("Password should include a number");
            }

            if (!hasUpperChar.IsMatch(password))
            {
                throw new InvalidPasswordException("Password must contain upper character");
            }

            if (!hasLowerChar.IsMatch(password))
            {
                throw new InvalidPasswordException("Password must contain lower character");
            }

            if (!hasSpecialLetter.IsMatch(password))
            {
                throw new InvalidPasswordException("Password must contain a special character (not including '_')");
            }
        }

        public void Receive(Message message)
        {
            byte[] aesKey;
            byte[] iv;

            aesKey = rsa.Decrypt(message.EncryptedAESKey, RSAEncryptionPadding.OaepSHA256);
            iv = rsa.Decrypt(message.EncryptedAESIV, RSAEncryptionPadding.OaepSHA256);

            string decryptedMessage = Encoding.UTF8.GetString(AES.Decrypt(Encoding.UTF8.GetBytes(message.EncryptedMessage), aesKey, iv));

            Console.WriteLine(decryptedMessage);
        }
    }
}