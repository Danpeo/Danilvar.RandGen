module DVar.RandCreds.RandWord

open System

let private vowels = "aiueo"
let private consonants = "bcdfghjklmnpqrstvwxyz"

let vow () = RandGen.char (vowels)
let con () = RandGen.char (consonants)

let syllable () =
  let random = Random()

  match random.Next(4) with
  | 0 -> $"{vow ()}"
  | 1 -> $"{con ()}{vow ()}"
  | 2 -> $"{con ()}{vow ()}{con ()}"
  | 3 -> $"{vow ()}{con ()}"
  | _ -> "_"

let word (syllableCount: int) =
  let syllables = List.init syllableCount (fun _ -> syllable ())
  String.concat "" syllables

let words (n: int, maxSyllableCount: int) =
  let random = Random()

  let words =
    List.init n (fun _ ->
      let syllableCount = 1 + random.Next(maxSyllableCount - 1)
      word syllableCount)

  words
 