namespace MooVC.Syntax.CSharp.BinaryTests;

internal static class BinaryTestsData
{
    public const string DefaultBody = "return left + right;";

    public static Binary Create(Snippet? body = default, Binary.Types? @operator = default, Scopes? scope = default)
    {
        var subject = new Binary
        {
            Body = body ?? Snippet.From(DefaultBody),
            Operator = @operator ?? Binary.Types.Add,
        };

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }
}