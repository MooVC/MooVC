namespace MooVC.Syntax.CSharp.ComparisonTests;

internal static class ComparisonTestsData
{
    public const string DefaultBody = "return left == right;";

    public static Comparison Create(Snippet? body = default, Comparison.Type? @operator = default, Scope? scope = default)
    {
        var subject = new Comparison
        {
            Body = body ?? Snippet.From(DefaultBody),
            Operator = @operator ?? Comparison.Type.Equality,
        };

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }
}