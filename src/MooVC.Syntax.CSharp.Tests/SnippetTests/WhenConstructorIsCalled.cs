namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> values = ImmutableArray<string>.Empty;

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
