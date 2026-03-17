namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Snippet.BlockOptions();
        var second = new Snippet.BlockOptions();

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
        var first = new Snippet.BlockOptions();

        Snippet.BlockOptions second = new Snippet.BlockOptions()
            .WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}