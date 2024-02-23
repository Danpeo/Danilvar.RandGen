// For more information see https://aka.ms/fsharp-console-apps

open System
open DVar.RandCreds
open DVar.RandCreds.Options

let passwordOptions: PasswordOptions =
  { Length = 10
    Lowercase = true
    Uppercase = true
    NonAlpha = true }

let usernameOptions: UsernameOptions =
  { Prefix = "naruto"
    PostfixLength = 10 }

let emailOptions: EmailOptions =
  { Domains = [| "naruto" |]
    Prefix = ""
    RandomCharLength = 4 }

let username = RandGen.UsernameDefault
let password = RandGen.Password passwordOptions

let email = RandGen.EmailDefault emailOptions

let email2 = RandGen.EmailDefaultNoOptions

let phoneNumber = RandGen.PhoneNumber Russia
let phoneNumber2 = RandGen.PhoneNumber Japan

let c = RandColor.RgbCr 255 255 255

printfn $"Username:  %s{username}"
printfn $"Password %s{password}"
printfn $"Email %s{email}"
printfn $"Email2 %s{email2}"
printfn $"Phone %s{phoneNumber}"
printfn $"Phone2 %s{phoneNumber2}"
Console.WriteLine(c)