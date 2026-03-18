namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> values = ["Alpha", "Beta"];

    [Test]
    public async Task GivenEmptySnippetThenCreatesDefaultArray()
    {
        // Arrange
        Snippet subject = Snippet.Empty;

        // Act
        ImmutableArray<string> result = subject;

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenSnippetThenReturnsMatchingArray()
    {
        // Arrange
        Snippet subject = values;

        // Act
        ImmutableArray<string> result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(values);
    }
}