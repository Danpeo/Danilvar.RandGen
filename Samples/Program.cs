using System.Drawing;
using DVar.RandCreds;
using DVar.RandCreds.Options;
using Samples;

var userNameOptions = new UsernameOptions
(
    prefix: "nauto",
    postfixLength: 6
);


string username = RandGen.Username(userNameOptions);
string phoneNumber = RandGen.PhoneNumber(Country.Russia);
Color color = RandColor.RgbCr.Curry(255, 255, 255);
Color color2 = RandColor.ArgbCr.Curry(255, 255, 255, 255);
Color color3 = RandColor.Argb(255, 255, 255, 255);

Console.WriteLine($"Username: {username}");
Console.WriteLine($"Phone Number: {phoneNumber}");
Console.WriteLine($"Color2: {color2}");