namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenTheSameValueThenReturnsTheSameHash()
    {
        // Arrange
        Conversion.Intent first = Conversion.Intent.From;
        Conversion.Intent second = Conversion.Intent.From;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Conversion.Intent first = Conversion.Intent.From;
        Conversion.Intent second = Conversion.Intent.To;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}