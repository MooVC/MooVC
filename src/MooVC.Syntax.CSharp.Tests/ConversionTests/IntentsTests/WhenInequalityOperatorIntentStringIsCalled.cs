namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenInequalityOperatorIntentStringIsCalled
{
    private const string Same = "From";
    private const string Different = "To";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents? left = default;
        string? right = default;

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
        string right = Different;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents? left = default;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents left = Conversion.Intents.From;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}