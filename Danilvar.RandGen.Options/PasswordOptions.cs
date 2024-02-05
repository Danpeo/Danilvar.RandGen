namespace Danilvaar.RandGen.Options;

public class PasswordOptions
{
    public int Length { get; set; } = 8;

    public bool RequireLowercase { get; set; } = true;

    public bool RequireUppercase { get; set; } = true;

    public bool RequireNonAlphanumeric { get; set; } = true;

    public PasswordOptions()
    {
    }

    public PasswordOptions(int length = 6, bool requireLowercase = true, bool requireUppercase = true,
        bool requireNonAlphanumeric = true)
    {
        if (length < 6)
            Length = 6;

        Length = length;
        RequireLowercase = requireLowercase;
        RequireUppercase = requireUppercase;
        RequireNonAlphanumeric = requireNonAlphanumeric;
    }
}