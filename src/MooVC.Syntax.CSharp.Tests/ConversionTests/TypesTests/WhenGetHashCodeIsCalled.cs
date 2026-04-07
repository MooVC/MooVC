namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Conversion.Types first = Conversion.Types.Explicit;
        Conversion.Types second = Conversion.Types.Implicit;

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
        Conversion.Types first = Conversion.Types.Explicit;
        Conversion.Types second = Conversion.Types.Explicit;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}