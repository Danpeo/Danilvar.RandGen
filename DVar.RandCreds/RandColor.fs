module DVar.RandCreds.RandColor

open System
open System.Drawing

let private random = Random()

let Argb maxA maxR maxG maxB =
  let r = random.Next(maxR)
  let g = random.Next(maxG)
  let b = random.Next(maxB)
  let a = maxA
  Color.FromArgb(a, r, g, b)
  
let ArgbCr = Argb
let RgbCr = Argb 255
let ArgbGet = Argb 255 255 255 255