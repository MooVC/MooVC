namespace MooVC.Syntax.CSharp.UnaryTests;

internal static class UnaryTestsData
{
    public const string DefaultBody = "return +value;";

    public static Unary Create(Snippet? body = default, Unary.Types? @operator = default, Scopes? scope = default)
    {
        var subject = new Unary
        {
            Body = body ?? Snippet.From(DefaultBody),
            Operator = @operator ?? Unary.Types.Plus,
        };

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }
}