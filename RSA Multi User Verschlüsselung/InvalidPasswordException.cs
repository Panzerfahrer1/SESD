using System;
using System.Collections.Generic;
using System.Text;

namespace RSA_Multi_User_Verschlüsselung
{
    internal class InvalidPasswordException(string msg) : Exception(msg)
    {
    }
}
