namespace Danilvaar.RandGen.Options;

public class UsernameOptions
{
    public string Prefix { get; set; } = "user";
    public int PostfixLength { get; set; } = 6;

    public UsernameOptions()
    {
     
    }

    public UsernameOptions(string prefix = "user", int postfixLength = 6)
    {
        Prefix = prefix;
        PostfixLength = postfixLength;
    }
}