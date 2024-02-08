namespace DVar.RandCreds.Options

type PasswordOptions =
  { Length: int
    Lowercase: bool
    Uppercase: bool
    NonAlpha: bool }
  
type UsernameOptions =
  {
    Prefix: string
    PostfixLength: int
  }
  
type EmailOptions =
  {
    Prefix: string
    Domains: string array
    RandomCharLength: int
  }
