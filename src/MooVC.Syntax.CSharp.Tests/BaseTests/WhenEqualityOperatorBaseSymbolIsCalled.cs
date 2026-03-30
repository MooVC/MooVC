namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenEqualityOperatorBaseSymbolIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
    public async Task GivenBothSidesAreNullThenReturnsTrue()
    {
        // Arrange
        Base? left = default;
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        var right = new Symbol { Name = Different };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEitherSideIsNullThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Symbol? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        var right = new Symbol { Name = Same };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}