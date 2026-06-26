namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenEqualityOperatorTypeStringIsCalled
{
    private const string Same = "explicit";
    private const string Different = "implicit";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Conversion.Types? left = default;
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
        Conversion.Types left = Conversion.Types.Explicit;
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
        Conversion.Types left = Conversion.Types.Explicit;
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
        Conversion.Types? left = default;
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
        Conversion.Types left = Conversion.Types.Explicit;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}