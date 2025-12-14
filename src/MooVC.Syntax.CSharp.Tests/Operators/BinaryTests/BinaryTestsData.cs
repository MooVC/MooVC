namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

using MooVC.Syntax.CSharp.Members;

internal static class BinaryTestsData
{
    public const string DefaultBody = "return left + right;";

    public static Binary Create(Snippet? body = default, Binary.Type? @operator = default, Scope? scope = default)
    {
        var subject = new Binary
        {
            Body = body ?? Snippet.From(DefaultBody),
            Operator = @operator ?? Binary.Type.Add,
        };

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }
}