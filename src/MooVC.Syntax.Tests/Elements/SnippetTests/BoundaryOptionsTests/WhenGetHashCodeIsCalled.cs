namespace MooVC.Syntax.Elements.SnippetTests.BoundaryOptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Snippet.BoundaryOptions();
        var second = new Snippet.BoundaryOptions();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        var first = new Snippet.BoundaryOptions();

        Snippet.BoundaryOptions second = new Snippet.BoundaryOptions()
            .WithClosing("]");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}