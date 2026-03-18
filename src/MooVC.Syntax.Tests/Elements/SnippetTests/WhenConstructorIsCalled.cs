namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> values = [];

        // Act & Assert
        _ = await Assert.That(() => _ = new Snippet(values)).ThrowsNothing();
    }

    [Test]
    public async Task GivenValuesThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> values = ["alpha", "beta"];

        // Act & Assert
        _ = await Assert.That(() => _ = new Snippet(values)).ThrowsNothing();
    }
}