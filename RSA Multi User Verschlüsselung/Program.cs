using RSA_Multi_User_Verschlüsselung;

List<Message> log = new();

try
{
    User user = new User("gvbhjk", "VHadswdad1!GJBK");
} catch (InvalidPasswordException ex)
{
    Console.WriteLine(ex.Message);
}

