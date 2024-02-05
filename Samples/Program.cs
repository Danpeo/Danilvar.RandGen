using Danilvaar.RandGen.Options;
using Danilvar;



string password = RandGen.Password(new PasswordOptions(12));
string userName = RandGen.Username(null);
string email = RandGen.Email(null);

Console.WriteLine($"Random password: {password}");
Console.WriteLine($"User Name: {userName}");
Console.WriteLine(email);

