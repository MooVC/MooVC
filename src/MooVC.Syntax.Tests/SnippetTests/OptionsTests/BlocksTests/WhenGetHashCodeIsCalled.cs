namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        var first = new Snippet.Options.Blocks();

        Snippet.Options.Blocks second = new Snippet.Options.Blocks()
            .WithLayout(Snippet.Options.Blocks.Layouts.KAndR);

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
        var first = new Snippet.Options.Blocks();
        var second = new Snippet.Options.Blocks();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}