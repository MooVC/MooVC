namespace MooVC.Syntax.CSharp.Concepts.TypeExtensionsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Generics;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenToSnippetIsCalled
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Type> types = isDefault
            ? default
            : [];

        // Act
        var snippet = types.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        ImmutableArray<Type> types = [OperatorsTestsData.Create("Alpha")];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = types.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenOrderedSnippetReturned()
    {
        // Arrange
        ImmutableArray<Type> types =
        [
            OperatorsTestsData.Create("Gamma"),
            OperatorsTestsData.Create("Alpha"),
            OperatorsTestsData.Create("Beta"),
        ];

        const string expected = """
            Alpha

            Beta

            Gamma
            """;

        // Act
        var snippet = types.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}