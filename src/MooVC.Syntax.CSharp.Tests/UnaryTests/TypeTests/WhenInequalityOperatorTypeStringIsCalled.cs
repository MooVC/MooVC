namespace MooVC.Syntax.CSharp.UnaryTests.TypeTests;

public sealed class WhenInequalityOperatorTypeStringIsCalled
{
    private const string Same = "!";
    private const string Different = "++";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Unary.Type? left = default;
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
        Unary.Type left = Unary.Type.Not;
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
        Unary.Type left = Unary.Type.Not;
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
        Unary.Type? left = default;
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
        Unary.Type left = Unary.Type.Not;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}