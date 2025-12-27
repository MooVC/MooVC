namespace MooVC.Syntax.CSharp.Generics.ConstructExtensionsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Construct> constructs = isDefault
            ? default
            : [];

        // Act
        var snippet = constructs.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        ImmutableArray<Construct> constructs = [OperatorsTestsData.CreateConstruct("Alpha")];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = constructs.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenOrderedSnippetReturned()
    {
        // Arrange
        ImmutableArray<Construct> constructs =
        [
            OperatorsTestsData.CreateConstruct("Gamma"),
            OperatorsTestsData.CreateConstruct("Alpha"),
            OperatorsTestsData.CreateConstruct("Beta"),
        ];

        const string expected = """
            Alpha
            Beta
            Gamma
            """;

        // Act
        var snippet = constructs.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}