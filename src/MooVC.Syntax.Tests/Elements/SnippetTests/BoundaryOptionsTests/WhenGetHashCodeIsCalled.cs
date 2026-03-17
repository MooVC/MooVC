namespace MooVC.Syntax.Elements.SnippetTests.BoundaryOptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Snippet.BoundaryOptions();
        var second = new Snippet.BoundaryOptions();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        var first = new Snippet.BoundaryOptions();

        Snippet.BoundaryOptions second = new Snippet.BoundaryOptions()
            .WithClosing("]");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}