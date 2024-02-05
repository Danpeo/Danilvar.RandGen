// For more information see https://aka.ms/fsharp-console-apps

open Danilvaar.RandGen.Options
open Danilvar

let options = PasswordOptions()

let password = RandGen.Password(options)

printfn $"%s{password}"