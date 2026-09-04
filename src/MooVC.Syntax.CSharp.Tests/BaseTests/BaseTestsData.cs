namespace MooVC.Syntax.CSharp.BaseTests;

public static class BaseTestsData
{
    public static Base Create(
        Qualification? name = default,
        Token? argument = default)
    {
        var result = new Base
        {
            Name = name ?? (Qualification)"Comparable",
        };

        if (argument is not null)
        {
            result = result.WithArguments(argument);
        }

        return result;
    }
}