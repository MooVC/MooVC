namespace MooVC.Syntax.CSharp.Operators;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

internal static class OperatorsTestsData
{
    public const string DefaultDeclarationName = "Value";

    public static readonly Snippet DefaultBody = "return default;";

    public static TestType Create(string? name = default, bool isUndefined = false)
    {
        return new TestType(name ?? DefaultDeclarationName, isUndefined);
    }

    internal sealed class TestType
        : Type
    {
        public TestType(string name, bool isUndefined)
        {
            Declaration = new Declaration { Name = name };
            IsUndefined = isUndefined;
        }

        public override bool IsUndefined { get; }

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            return Snippet.From(Declaration);
        }
    }
}