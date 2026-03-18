namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "TAlpha";
    private const string Different = "TBravo";

    [Test]
    public void GivenMatchingIdentifiersThenReturnSameHash()
    {
        // Arrange
        var first = new Identifier(Same);
        var second = new Identifier(Same);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentIdentifiersThenReturnDifferentHashes()
    {
        // Arrange
        var first = new Identifier(Same);
        var second = new Identifier(Different);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}