namespace MooVC.Syntax.CSharp.Operators.UnaryExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Unary> unaries = isDefault
            ? default
            : ImmutableArray<Unary>.Empty;

        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        // Act
        Snippet result = unaries.ToSnippet(construct, Snippet.Options.Default);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullConstructThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Unary> unaries = ImmutableArray.Create(UnaryTestsData.Create());
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
        ImmutableArray<Unary> unaries = ImmutableArray.Create(UnaryTestsData.Create());
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
        Unary protectedNegate = UnaryTestsData.Create(@operator: Unary.Type.Negate, scope: Scope.Protected);

        ImmutableArray<Unary> unaries = ImmutableArray.Create(publicDecrement, protectedNegate, publicIncrement);

        // Act
        Snippet snippet = unaries.ToSnippet(construct, options);

        // Assert
        string[] expected =
        {
            publicIncrement.ToString(construct, options),
            publicDecrement.ToString(construct, options),
            protectedNegate.ToString(construct, options),
        };

        snippet.ToString().ShouldBe(string.Join(Environment.NewLine, expected));
    }
}
