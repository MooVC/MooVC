namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.BoundariesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        var first = new Snippet.Options.Blocks.Boundaries();

        Snippet.Options.Blocks.Boundaries second = new Snippet.Options.Blocks.Boundaries()
            .WithClosing("]");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Snippet.Options.Blocks.Boundaries();
        var second = new Snippet.Options.Blocks.Boundaries();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}