namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly Snippet same = Snippet.From("Alpha");
    private static readonly Snippet different = Snippet.From("Beta");

    [Test]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Argument { Value = same };
        var second = new Argument { Value = same };

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
        var first = new Argument { Value = same };
        var second = new Argument { Value = different };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}