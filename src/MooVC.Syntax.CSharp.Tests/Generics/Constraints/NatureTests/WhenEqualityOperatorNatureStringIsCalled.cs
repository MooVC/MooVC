namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenEqualityOperatorNatureStringIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Fact]
    public void GivenBothSidesNullThenReturnsTrue()
    {
        // Arrange
        Nature? left = default;
        string? right = default;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenEitherSideNullThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        string? right = default;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Nature left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}
