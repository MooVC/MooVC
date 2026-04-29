namespace MooVC.Syntax.IdentifierTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentOptionsThenHashCodesAreDifferent()
    {
        // Arrange
        var first = new Identifier.Options { Casing = Identifier.Casing.Camel };
        var second = new Identifier.Options { Casing = Identifier.Casing.Kebab };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEqualOptionsThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Identifier.Options();
        var second = new Identifier.Options();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}