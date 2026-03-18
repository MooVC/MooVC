namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorBaseBaseIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
    public async Task GivenBothBasesAreNullThenReturnsTrue()
    {
        // Arrange
        Base? left = default;
        Base? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEitherBaseIsNullThenReturnsFalse()
    {
        // Arrange
        Base? left = new Symbol { Name = Same };
        Base? right = default;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualBasesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Same };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentBasesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = Same };
        Base right = new Symbol { Name = Different };

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}