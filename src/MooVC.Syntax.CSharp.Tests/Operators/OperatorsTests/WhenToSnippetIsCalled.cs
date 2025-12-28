namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Operators.BinaryTests;
using MooVC.Syntax.CSharp.Operators.ComparisonTests;
using MooVC.Syntax.CSharp.Operators.ConversionTests;
using MooVC.Syntax.CSharp.Operators.UnaryTests;

public sealed class WhenToSnippetIsCalled
{
    private const string GivenValuesThenSnippetReturnedExpected = """
        public static Value operator +(Value left, Value right)
        {
            return left + right;
        }

        public static bool operator ==(Value left, Value right)
        {
            return left == right;
        }

        public static implicit operator Other(Value subject)
        {
            return new Value();
        }

        public static Value operator +(Value value)
        {
            return +value;
        }
        """;

    [Fact]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Operators subject = Operators.Undefined;
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        var snippet = subject.ToSnippet(Snippet.Options.Default, type);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenValuesThenSnippetReturned()
    {
        // Arrange
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        ImmutableArray<Comparison> comparisons = [ComparisonTestsData.Create()];
        ImmutableArray<Conversion> conversions = [ConversionTestsData.Create()];
        ImmutableArray<Unary> unaries = [UnaryTestsData.Create()];

        Operators subject = OperatorsSubjectData.Create(
            binaries: binaries,
            comparisons: comparisons,
            conversions: conversions,
            unaries: unaries);

        // Act
        var snippet = subject.ToSnippet(options, type);

        // Assert
        snippet.ToString().ShouldBe(GivenValuesThenSnippetReturnedExpected);
    }
}