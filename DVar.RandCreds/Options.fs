namespace DVar.RandCreds.Options

type PasswordOptions =
  { Length: int
    Lowercase: bool
    Uppercase: bool
    NonAlpha: bool }

type UsernameOptions = { Prefix: string; PostfixLength: int }

type EmailOptions =
  { Prefix: string
    Domains: string array
    RandomCharLength: int }

type Country =
  | Russia
  | USA
  | UK
  | France
  | Germany
  | China
  | Japan
  | India
  | Brazil
  | Canada
  | Australia
  | Mexico
  | Spain
  | Italy
  | Argentina
  | SouthKorea
  | Turkey
  | Indonesia
  | Nigeria
  | Pakistan
  

