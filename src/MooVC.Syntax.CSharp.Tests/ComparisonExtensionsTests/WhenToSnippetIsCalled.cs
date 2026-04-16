namespace MooVC.Syntax.CSharp.ComparisonExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.ComparisonTests;

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

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Comparison> comparisons = isDefault
            ? default
            : [];

        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        var result = comparisons.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Comparison> comparisons = [ComparisonTestsData.Create()];
        OperatorsTestsData.TestType? type = default;

        // Act
        Func<Snippet> act = () => _ = comparisons.ToSnippet(Snippet.Options.Default, type!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(type));
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Comparison> comparisons = [ComparisonTestsData.Create()];
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = comparisons.ToSnippet(options!, type);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Comparison publicEquality = ComparisonTestsData.Create(@operator: Comparison.Types.Equality, scope: Scopes.Public);
        Comparison publicLessThan = ComparisonTestsData.Create(@operator: Comparison.Types.LessThan, scope: Scopes.Public);
        Comparison protectedGreaterThan = ComparisonTestsData.Create(@operator: Comparison.Types.GreaterThan, scope: Scopes.Protected);

        ImmutableArray<Comparison> comparisons = [publicLessThan, protectedGreaterThan, publicEquality];

        // Act
        var snippet = comparisons.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}