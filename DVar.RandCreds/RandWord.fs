module DVar.RandCreds.RandWord

open System

let private vowels = "aiueo"
let private consonants = "bcdfghjklmnpqrstvwxyz"

let Vow () = RandGen.char (vowels)
let Con () = RandGen.char (consonants)

let Syllable () =
  let random = Random()

  match random.Next(4) with
  | 0 -> $"{Vow ()}"
  | 1 -> $"{Con ()}{Vow ()}"
  | 2 -> $"{Con ()}{Vow ()}{Con ()}"
  | 3 -> $"{Vow ()}{Con ()}"
  | _ -> "_"

let Word (syllableCount: int) =
  let syllables = List.init syllableCount (fun _ -> Syllable ())
  String.concat "" syllables

let Words (n: int, maxSyllableCount: int) =
  let random = Random()

  let words =
    List.init n (fun _ ->
      let syllableCount = 1 + random.Next(maxSyllableCount - 1)
      Word syllableCount)

  words
 