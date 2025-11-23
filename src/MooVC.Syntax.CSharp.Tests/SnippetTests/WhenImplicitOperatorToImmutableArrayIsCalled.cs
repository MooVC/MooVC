namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> values = ["Alpha", "Beta"];

    [Fact]
    public void GivenEmptySnippetThenCreatesDefaultArray()
    {
        // Arrange
        Snippet subject = Snippet.Empty;

        // Act
        ImmutableArray<string> result = subject;

        // Assert
        result.ShouldBe([]);
    }

    [Fact]
    public void GivenSnippetThenReturnsMatchingArray()
    {
        // Arrange
        Snippet subject = values;

        // Act
        ImmutableArray<string> result = subject;

        // Assert
        result.ShouldBe(values);
    }
}