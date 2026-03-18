namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenInequalityOperatorBaseBaseIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
    public async Task GivenBothBasesAreNullThenReturnsFalse()
    {
        // Arrange
        Base? left = default;
        Base? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEitherBaseIsNullThenReturnsTrue()
    {
        // Arrange
        Base? left = new Symbol { Name = Same };
        Base? right = default;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualBasesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Same };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentBasesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Different };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}