namespace MooVC.Syntax.Elements.IdentifierTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualOptionsThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Identifier.Options();
        var second = new Identifier.Options();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentOptionsThenHashCodesAreDifferent()
    {
        // Arrange
        var first = new Identifier.Options { Casing = Identifier.Casing.Camel };
        var second = new Identifier.Options { Casing = Identifier.Casing.Kebab };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}