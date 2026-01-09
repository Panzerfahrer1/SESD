using OneTimePad;
using System.ComponentModel.DataAnnotations;

//Console.WriteLine(OTP.Encrypt("hallo das ist ein text", "abc"));

//Console.WriteLine(OTP.Encrypt(OTP.Encrypt("Test", "key"), "key"));
OTP top = new OTP();

string word = top.Encrypt("Test");
Console.WriteLine(top.Decypt(word));