namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenEqualityOperatorTypeStringIsCalled
{
    private const string Same = "==";
    private const string Different = "!=";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Comparison.Types? left = default;
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
        Comparison.Types left = Comparison.Types.Equality;
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
        Comparison.Types left = Comparison.Types.Equality;
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
        Comparison.Types? left = default;
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
        Comparison.Types left = Comparison.Types.Equality;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}