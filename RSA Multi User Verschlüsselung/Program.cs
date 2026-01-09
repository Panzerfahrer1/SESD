using RSA_Multi_User_Verschlüsselung;

List<Message> log = new();

User gunther = new User("gunther", "VHadswdad1!GJBK");
User peter = new User("Peter", "HeuteIstEinTollerTag!1_");

Message msg1 = new Message(gunther, peter);

msg1.Send("Hallo Welt");
peter.Receive(msg1);

Console.WriteLine();