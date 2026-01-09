using _1TestLernen;

Summenverfahren sum = new Summenverfahren();

Console.WriteLine(sum.Encrypt("TREFFEN UM SIEBEN", "ZEBRA"));
Console.WriteLine("---------------------");
Console.WriteLine(sum.Decrypt(sum.Encrypt("TREFFEN UM SIEBEN", "ZEBRA"), "ZEBRA"));
Console.WriteLine("---------------------");

XOR xor = new XOR();
Console.WriteLine(xor.Decrypt(xor.Encrypt("WORD", "WORD"), "WORD"));