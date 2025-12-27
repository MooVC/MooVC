namespace MooVC.Syntax.CSharp.Operators.UnaryExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.CSharp.Operators.UnaryTests;

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

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Unary> unaries = isDefault
            ? default
            : [];

        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        // Act
        var result = unaries.ToSnippet(construct, Snippet.Options.Default);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Unary> unaries = [UnaryTestsData.Create()];
        OperatorsTestsData.TestConstruct? construct = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = unaries.ToSnippet(construct!, Snippet.Options.Default));

        // Assert
        exception.ParamName.ShouldBe(nameof(construct));
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Unary> unaries = [UnaryTestsData.Create()];
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = unaries.ToSnippet(construct, options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        Unary publicIncrement = UnaryTestsData.Create(@operator: Unary.Type.Increment, scope: Scope.Public);
        Unary publicDecrement = UnaryTestsData.Create(@operator: Unary.Type.Decrement, scope: Scope.Public);
        Unary protectedNegate = UnaryTestsData.Create(@operator: Unary.Type.Not, scope: Scope.Protected);

        ImmutableArray<Unary> unaries = [publicDecrement, protectedNegate, publicIncrement];

        // Act
        var snippet = unaries.ToSnippet(construct, options);

        // Assert
        snippet.ToString().ShouldBe(GivenValuesThenAnOrderedSnippetIsReturnedExpected);
    }
}