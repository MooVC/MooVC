namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenInequalityOperatorBaseBaseIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenBothBasesAreNullThenReturnsFalse()
    {
        // Arrange
        Base? left = default;
        Base? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEitherBaseIsNullThenReturnsTrue()
    {
        // Arrange
        Base? left = new Symbol { Name = new Variable(Same) };
        Base? right = default;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualBasesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = new Variable(Same) };
        Base right = new Symbol { Name = new Variable(Same) };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentBasesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = new Variable(Same) };
        Base right = new Symbol { Name = new Variable(Different) };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}