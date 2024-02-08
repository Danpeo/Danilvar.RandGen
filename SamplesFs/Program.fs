// For more information see https://aka.ms/fsharp-console-apps

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
  { Domains = [| "" |]
    Prefix = ""
    RandomCharLength = 4 }

let username = RandGen.UsernameDefault
let password = RandGen.Password passwordOptions

let email = RandGen.Email emailOptions

printfn $"Username:  %s{username}"
printfn $"Password %s{password}"
printfn $"Email %s{email}"
