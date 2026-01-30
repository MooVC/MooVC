namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> values = [];

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Snippet(values));
    }

    [Fact]
    public void GivenValuesThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> values = ["alpha", "beta"];

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Snippet(values));
    }
}