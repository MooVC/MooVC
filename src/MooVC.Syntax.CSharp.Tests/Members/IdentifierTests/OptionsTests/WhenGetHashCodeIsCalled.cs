namespace MooVC.Syntax.CSharp.Members.IdentifierTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualOptionsThenHashCodesAreEqual()
    {
        // Arrange
        Identifier.Options first = new Identifier.Options();
        Identifier.Options second = new Identifier.Options();

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
        Identifier.Options first = new Identifier.Options();
        Identifier.Options second = new Identifier.Options { UseUnderscores = true };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}
