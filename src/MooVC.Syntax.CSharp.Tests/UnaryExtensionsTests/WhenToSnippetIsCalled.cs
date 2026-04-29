namespace MooVC.Syntax.CSharp.UnaryExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.UnaryTests;

public sealed class WhenToSnippetIsCalled
{
    private const string GivenValuesThenAnOrderedSnippetIsReturnedExpected = """
        public static Value operator ++(Value value)
        {
            return +value;
        }

        public static Value operator --(Value value)
        {
            return +value;
        }

        protected static Value operator !(Value value)
        {
            return +value;
        }
        """;

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Unary> unaries = isDefault
            ? default
            : [];

        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        var result = unaries.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Unary> unaries = [UnaryTestsData.Create()];
        OperatorsTestsData.TestType? type = default;

        // Act
        Func<Snippet> act = () => _ = unaries.ToSnippet(Snippet.Options.Default, type!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(type));
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Unary> unaries = [UnaryTestsData.Create()];
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = unaries.ToSnippet(options!, type);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();
        Unary publicIncrement = UnaryTestsData.Create(@operator: Unary.Types.Increment, scope: Scopes.Public);
        Unary publicDecrement = UnaryTestsData.Create(@operator: Unary.Types.Decrement, scope: Scopes.Public);
        Unary protectedNegate = UnaryTestsData.Create(@operator: Unary.Types.Not, scope: Scopes.Protected);

        ImmutableArray<Unary> unaries = [publicDecrement, protectedNegate, publicIncrement];

        // Act
        var snippet = unaries.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}