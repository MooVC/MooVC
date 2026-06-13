namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenEqualityOperatorIntentIntIsCalled
{
    private const string Same = "From";
    private const string Different = "To";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        string right = Different;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents? left = default;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}