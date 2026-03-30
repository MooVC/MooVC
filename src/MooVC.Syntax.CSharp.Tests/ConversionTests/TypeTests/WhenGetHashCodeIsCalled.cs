namespace MooVC.Syntax.CSharp.ConversionTests.TypeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Conversion.Type first = Conversion.Type.Explicit;
        Conversion.Type second = Conversion.Type.Implicit;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEquivalentValuesThenReturnsTheSameHash()
    {
        // Arrange
        Conversion.Type first = Conversion.Type.Explicit;
        Conversion.Type second = Conversion.Type.Explicit;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}