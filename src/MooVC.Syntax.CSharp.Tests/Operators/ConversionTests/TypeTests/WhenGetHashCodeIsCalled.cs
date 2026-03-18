namespace MooVC.Syntax.CSharp.Operators.ConversionTests.TypeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEquivalentValuesThenReturnsTheSameHash()
    {
        // Arrange
        Conversion.Type first = Conversion.Type.Explicit;
        Conversion.Type second = Conversion.Type.Explicit;

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
        Conversion.Type first = Conversion.Type.Explicit;
        Conversion.Type second = Conversion.Type.Implicit;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}