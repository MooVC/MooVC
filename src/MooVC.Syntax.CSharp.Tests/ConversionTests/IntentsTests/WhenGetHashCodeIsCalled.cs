namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Conversion.Intents first = Conversion.Intents.From;
        Conversion.Intents second = Conversion.Intents.To;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTheSameHash()
    {
        // Arrange
        Conversion.Intents first = Conversion.Intents.From;
        Conversion.Intents second = Conversion.Intents.From;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}