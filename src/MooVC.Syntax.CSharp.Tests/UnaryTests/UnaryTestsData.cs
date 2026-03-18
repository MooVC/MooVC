namespace MooVC.Syntax.CSharp.UnaryTests;

internal static class UnaryTestsData
{
    public const string DefaultBody = "return +value;";

    public static Unary Create(Snippet? body = default, Unary.Type? @operator = default, Scope? scope = default)
    {
        var subject = new Unary
        {
            Body = body ?? Snippet.From(DefaultBody),
            Operator = @operator ?? Unary.Type.Plus,
        };

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }
}