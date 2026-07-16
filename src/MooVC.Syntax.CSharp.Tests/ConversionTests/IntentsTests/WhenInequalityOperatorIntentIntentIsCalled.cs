namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenInequalityOperatorIntentIntentIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents? left = default;
        Conversion.Intents? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        Conversion.Intents right = Conversion.Intents.To;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenSameValuesThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        Conversion.Intents right = Conversion.Intents.From;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }
}