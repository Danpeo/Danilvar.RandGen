module Danilvar.RandGen

open System
open System.Security.Cryptography
open Danilvaar.RandGen.Options

let private lowerChars = "abcdefghijklmnopqrstuvwxyz"
let private upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
let private numericChars = "0123456789"
let private specialChars = "!@#$%^&*()_-+=<>?"
let private allChars = lowerChars + upperChars + numericChars + specialChars
let private noSpecialChars = lowerChars + upperChars + numericChars

let private getRandomChar (charSet: string) =
  charSet.[RandomNumberGenerator.GetInt32(charSet.Length)]


let Password (options: PasswordOptions) : string =

  let getPasswordChar i =
    match i with
    | 0 when options.RequireLowercase -> lowerChars
    | 1 when options.RequireUppercase -> upperChars
    | 2 when options.RequireNonAlphanumeric -> specialChars
    | _ -> allChars

  let password =
    Array.init options.Length (fun i -> getRandomChar (getPasswordChar i))

  let shufflePassword (password: char array) =
    let random = Random()
    password |> Array.sortBy (fun _ -> random.Next())

  let shuffledPassword = new string (password |> shufflePassword)
  shuffledPassword

////
let Username (options: UsernameOptions) : string =
  let genPostfix =
    Array.init options.PostfixLength (fun _ -> getRandomChar noSpecialChars)

  options.Prefix + new string (genPostfix)

let Email (options: EmailOptions) : string =
  let postfix =
    options.Domains.[RandomNumberGenerator.GetInt32(options.Domains.Length)]

  let genMiddleChars =
    Array.init options.RandomCharLength (fun _ -> getRandomChar noSpecialChars)

  options.Prefix + new string (genMiddleChars) + postfix
