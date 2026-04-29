namespace MooVC.Syntax.CSharp;

internal static class OperatorsTestsData
{
    public const string DefaultDeclarationName = "Value";

    public static readonly Snippet DefaultBody = Snippet.From("return default;");

    public static TestType Create(string? name = default, bool isUndefined = false)
    {
        return new TestType(name ?? DefaultDeclarationName, isUndefined);
    }

    internal sealed class TestType
        : Type
    {
        public TestType(string name, bool isUndefined)
        {
            Declaration = new() { Name = name };
            IsUndefined = isUndefined;
        }

        public override bool IsUndefined { get; }

        protected override Snippet PerformToSnippet(Options options)
        {
            return Snippet.From(options.Snippets, Declaration);
        }
    }
}