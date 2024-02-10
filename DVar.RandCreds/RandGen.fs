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

let private getLength (length: int) (minLength: int) (maxLength: int) : int =
  if length <= minLength then length
  elif length >= maxLength then maxLength
  else length

let Password (options: PasswordOptions) : string =
  let getPasswordChar i =
    match i with
    | 0 when options.Lowercase -> lowerChars
    | 1 when options.Uppercase -> upperChars
    | 2 when options.NonAlpha -> specialChars
    | _ -> allChars

  let length = getLength options.Length 5 100

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
  let postfixLength = getLength options.PostfixLength 5 100

  let genPostfix = Array.init postfixLength (fun _ -> getRandomChar noSpecialChars)

  options.Prefix + new string (genPostfix)

let UsernameDefault = Username { Prefix = "user"; PostfixLength = 6 }

let Email (options: EmailOptions) (minRandomCharLength: int, maxRandomCharLength: int) : string =
  let charLength =
    getLength options.RandomCharLength minRandomCharLength maxRandomCharLength

  let postfix =
    options.Domains[RandomNumberGenerator.GetInt32(options.Domains.Length)]

  let genMiddleChars = Array.init charLength (fun _ -> getRandomChar noSpecialChars)

  options.Prefix + new string (genMiddleChars) + "@" + postfix

let EmailDefault (options: EmailOptions) = Email options (5, 100)

let EmailDefaultNoOptions =
  EmailDefault
    { Domains = [| "mail.com" |]
      Prefix = "user"
      RandomCharLength = 6 }

let PhoneNumber (country: Country) =
  let prefix =
    match country with
    | Russia -> "7"
    | USA -> "1"
    | UK -> "44"
    | France -> "33"
    | Germany -> "49"
    | China -> "86"
    | Japan -> "81"
    | India -> "91"
    | Brazil -> "55"
    | Canada -> "1"
    | Australia -> "61"
    | Mexico -> "52"
    | Spain -> "34"
    | Italy -> "39"
    | Argentina -> "54"
    | SouthKorea -> "82"
    | Turkey -> "90"
    | Indonesia -> "62"
    | Nigeria -> "234"
    | Pakistan -> "92"

  let numberLength =
    match country with
    | Russia -> 10
    | USA -> 10
    | UK -> 10
    | France -> 9
    | Germany -> 11
    | China -> 11
    | Japan -> 10
    | India -> 10
    | Brazil -> 11
    | Canada -> 10
    | Australia -> 10
    | Mexico -> 10
    | Spain -> 9
    | Italy -> 10
    | Argentina -> 11
    | SouthKorea -> 10
    | Turkey -> 11
    | Indonesia -> 12
    | Nigeria -> 11
    | Pakistan -> 11

  let randomNumbers = Array.init numberLength (fun _ -> getRandomChar numericChars)

  prefix + new string (randomNumbers)

