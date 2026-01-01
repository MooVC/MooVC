namespace MooVC.Syntax.CSharp.Operators.ComparisonExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators.ComparisonTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string GivenValuesThenAnOrderedSnippetIsReturnedExpected = """
        public static bool operator <(Value left, Value right)
        {
            return left == right;
        }

        public static bool operator ==(Value left, Value right)
        {
            return left == right;
        }

        protected static bool operator >(Value left, Value right)
        {
            return left == right;
        }
        """;

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Comparison> comparisons = isDefault
            ? default
            : [];

        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        var result = comparisons.ToSnippet(Snippet.Options.Default, type);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Comparison> comparisons = [ComparisonTestsData.Create()];
        OperatorsTestsData.TestType? type = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = comparisons.ToSnippet(Snippet.Options.Default, type!));

        // Assert
        exception.ParamName.ShouldBe(nameof(type));
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Comparison> comparisons = [ComparisonTestsData.Create()];
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = comparisons.ToSnippet(options!, type));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        Comparison publicEquality = ComparisonTestsData.Create(@operator: Comparison.Type.Equality, scope: Scope.Public);
        Comparison publicLessThan = ComparisonTestsData.Create(@operator: Comparison.Type.LessThan, scope: Scope.Public);
        Comparison protectedGreaterThan = ComparisonTestsData.Create(@operator: Comparison.Type.GreaterThan, scope: Scope.Protected);

        ImmutableArray<Comparison> comparisons = [publicLessThan, protectedGreaterThan, publicEquality];

        // Act
        var snippet = comparisons.ToSnippet(options, type);

        // Assert
        snippet.ToString().ShouldBe(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}