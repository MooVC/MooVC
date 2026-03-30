namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenEqualityOperatorIntentIntentIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent? left = default;
        Conversion.Intent? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        Conversion.Intent right = Conversion.Intent.To;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenSameValuesThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        Conversion.Intent right = Conversion.Intent.From;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}