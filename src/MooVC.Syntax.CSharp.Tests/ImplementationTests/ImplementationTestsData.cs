namespace MooVC.Syntax.CSharp.ImplementationTests;

public static class ImplementationTestsData
{
    public static Implementation Create(
        Qualification? name = default,
        Token? argument = default)
    {
        Implementation result = new Implementation
        {
            Name = name ?? (Qualification)"IComparable",
        };

        if (argument is not null)
        {
            result = result.WithArguments(argument);
        }

        return result;
    }
}