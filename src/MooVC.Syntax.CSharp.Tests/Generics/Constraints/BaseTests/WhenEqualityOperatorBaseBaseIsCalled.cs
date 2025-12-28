namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorBaseBaseIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenBothBasesAreNullThenReturnsTrue()
    {
        // Arrange
        Base? left = default;
        Base? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEitherBaseIsNullThenReturnsFalse()
    {
        // Arrange
        Base? left = new Symbol { Name = new Identifier(Same) };
        Base? right = default;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualBasesThenReturnsTrue()
    {
        // Arrange
        Base left = new Symbol { Name = new Identifier(Same) };
        Base right = new Symbol { Name = new Identifier(Same) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentBasesThenReturnsFalse()
    {
        // Arrange
        Base left = new Symbol { Name = new Identifier(Same) };
        Base right = new Symbol { Name = new Identifier(Different) };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}