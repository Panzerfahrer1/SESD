using RSA_Multi_User_Verschlüsselung;

try
{
    User user = new User("gvbhjk", "VHadswdad1!GJBK");
} catch (InvalidPasswordException ex)
{
    Console.WriteLine(ex.Message);
}