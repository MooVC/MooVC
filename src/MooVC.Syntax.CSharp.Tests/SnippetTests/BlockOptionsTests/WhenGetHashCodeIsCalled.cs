namespace MooVC.Syntax.CSharp.SnippetTests.BlockOptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
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

    [Fact]
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