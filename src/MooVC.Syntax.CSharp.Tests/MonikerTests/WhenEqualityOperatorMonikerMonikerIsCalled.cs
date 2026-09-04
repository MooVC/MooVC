namespace MooVC.Syntax.CSharp.MonikerTests;

public sealed class WhenEqualityOperatorMonikerMonikerIsCalled
{
    private const string Same = "Value";
    private const string Different = "Other";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Moniker? left = default;
        Moniker? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Moniker left = Same;
        Moniker right = Different;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Moniker left = Same;
        Moniker right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}