namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(Conversion.Intents.To as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(null as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenAnUnrecognisedTypeThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(intent as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(Conversion.Intents.From as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}