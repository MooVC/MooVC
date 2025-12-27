namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Members;

internal static class ConversionTestsData
{
    public const string DefaultBody = "return new Value();";
    public const string DefaultSubject = "Other";

    public static Conversion Create(
        Snippet? body = default,
        Conversion.Intent? direction = default,
        Conversion.Type? mode = default,
        Scope? scope = default,
        Symbol? subject = default)
    {
        var conversion = new Conversion
        {
            Body = body ?? Snippet.From(DefaultBody),
            Direction = direction ?? Conversion.Intent.To,
            Mode = mode ?? Conversion.Type.Implicit,
            Subject = subject ?? new Symbol { Name = DefaultSubject },
        };

        if (scope is not null)
        {
            conversion.Scope = scope;
        }

        return conversion;
    }
}