namespace MooVC.Syntax.CSharp.Concepts.TypeTests;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.Elements;

internal sealed class TestType
    : Type
{
    public bool IsUndefinedValue { get; set; }

    public override bool IsUndefined => IsUndefinedValue;

    protected override Snippet PerformToSnippet(Snippet.Options options)
    {
        return Snippet.From(options, "test");
    }
}