module DVar.RandCreds.RandGen

open System
open System.Security.Cryptography
open DVar.RandCreds.Options

let private lowerChars = "abcdefghijklmnopqrstuvwxyz"
let private upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
let private numericChars = "0123456789"
let private specialChars = "!@#$%^&*()_-+=<>?"
let private allChars = lowerChars + upperChars + numericChars + specialChars
let private noSpecialChars = lowerChars + upperChars + numericChars

let private getRandomChar (charSet: string) =
  charSet[RandomNumberGenerator.GetInt32(charSet.Length)]

let private getLength (length: int, minLength: int, maxLength: int) : int =
  if length <= minLength then length
  else if length >= maxLength then maxLength
  else length

let Password (options: PasswordOptions) : string =
  let getPasswordChar i =
    match i with
    | 0 when options.Lowercase -> lowerChars
    | 1 when options.Uppercase -> upperChars
    | 2 when options.NonAlpha -> specialChars
    | _ -> allChars

  let length = getLength (options.Length, 5, 100)

  let password = Array.init length (fun i -> getRandomChar (getPasswordChar i))

  let shufflePassword (password: char array) =
    let random = Random()
    password |> Array.sortBy (fun _ -> random.Next())

  let shuffledPassword = new string (password |> shufflePassword)
  shuffledPassword

let PasswordDefault =
  Password
    { Length = 6
      Lowercase = true
      Uppercase = true
      NonAlpha = true }

let Username (options: UsernameOptions) : string =
  let postfixLength = getLength (options.PostfixLength, 5, 100)

  let genPostfix = Array.init postfixLength (fun _ -> getRandomChar noSpecialChars)

  options.Prefix + new string (genPostfix)

let UsernameDefault = Username { Prefix = "user"; PostfixLength = 6 }

let Email (options: EmailOptions) : string =
  let charLength = getLength (options.RandomCharLength, 5, 100)

  let postfix =
    options.Domains[RandomNumberGenerator.GetInt32(options.Domains.Length)]

  let genMiddleChars = Array.init charLength (fun _ -> getRandomChar noSpecialChars)

  options.Prefix + new string (genMiddleChars) + postfix

let EmailDefault =
  Email
    { Domains = [| "@mail.com" |]
      Prefix = "user"
      RandomCharLength = 6 }
