namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Same = "TAlpha";
    private const string Different = "TBravo";

    [Test]
    public async Task GivenMatchingIdentifiersThenReturnSameHash()
    {
        // Arrange
        var first = new Identifier(Same);
        var second = new Identifier(Same);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentIdentifiersThenReturnDifferentHashes()
    {
        // Arrange
        var first = new Identifier(Same);
        var second = new Identifier(Different);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}