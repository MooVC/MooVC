namespace MooVC.Syntax.CSharp.TypeTests;

internal sealed class TestType
    : Type
{
    public bool IsUndefinedValue { get; set; }

    public override bool IsUndefined => IsUndefinedValue;

    protected override Snippet PerformToSnippet(Options options)
    {
        return Snippet.From(options.Snippets, "test");
    }
}