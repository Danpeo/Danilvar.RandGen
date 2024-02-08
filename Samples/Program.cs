using DVar.RandCreds;
using DVar.RandCreds.Options;

var userNameOptions = new UsernameOptions
(
    prefix: "nauto",
    postfixLength: 6
);

string username = RandGen.Username(userNameOptions);


Console.WriteLine($"Username: {username}");