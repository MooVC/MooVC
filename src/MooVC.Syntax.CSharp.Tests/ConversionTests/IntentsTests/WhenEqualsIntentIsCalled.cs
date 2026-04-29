namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenEqualsIntentIsCalled
{
    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(Conversion.Intents.To);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(default(Conversion.Intents));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(intent);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(Conversion.Intents.From);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}