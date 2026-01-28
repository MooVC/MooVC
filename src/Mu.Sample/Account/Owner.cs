namespace Mu.Sample.Account;

public sealed record Owner(string Name)
{
    public static readonly Owner Unspecified = new(string.Empty);
}