namespace MooVC.Syntax.Elements.IdentifierTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
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

    [Fact]
    public void GivenDifferentOptionsThenHashCodesAreDifferent()
    {
        // Arrange
        var first = new Identifier.Options();
        var second = new Identifier.Options { UseUnderscores = true };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}