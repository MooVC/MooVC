namespace MooVC.Syntax.CSharp.Operators;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;

internal static class OperatorsTestsData
{
    public const string DefaultDeclarationName = "Value";

    public static readonly Snippet DefaultBody = Snippet.From("return default;");

    public static TestConstruct CreateConstruct(string? name = default, bool isUndefined = false)
    {
        return new TestConstruct(name ?? DefaultDeclarationName, isUndefined);
    }

    internal sealed class TestConstruct
        : Construct
    {
        public TestConstruct(string name, bool isUndefined)
        {
            Name = new Declaration { Name = name };
            IsUndefined = isUndefined;
        }

        public override bool IsUndefined { get; }

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            return Snippet.From(Name);
        }
    }
}