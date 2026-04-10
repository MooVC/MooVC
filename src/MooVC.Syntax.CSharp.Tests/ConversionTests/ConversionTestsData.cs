namespace MooVC.Syntax.CSharp.ConversionTests;

internal static class ConversionTestsData
{
    public const string DefaultBody = "return new Value();";
    public const string DefaultSubject = "Other";

    public static Conversion Create(
        Snippet? body = default,
        Conversion.Intents? direction = default,
        Conversion.Types? mode = default,
        Scopes? scope = default,
        Symbol? subject = default)
    {
        var conversion = new Conversion
        {
            Body = body ?? Snippet.From(DefaultBody),
            Direction = direction ?? Conversion.Intents.To,
            Mode = mode ?? Conversion.Types.Implicit,
            Target = subject ?? new Symbol { Name = DefaultSubject },
        };

        if (scope is not null)
        {
            conversion.Scope = scope;
        }

        return conversion;
    }
}