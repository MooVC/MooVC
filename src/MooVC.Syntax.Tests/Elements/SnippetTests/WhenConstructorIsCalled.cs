namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> values = [];

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Snippet(values));
    }

    [Test]
    public void GivenValuesThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> values = ["alpha", "beta"];

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Snippet(values));
    }
}