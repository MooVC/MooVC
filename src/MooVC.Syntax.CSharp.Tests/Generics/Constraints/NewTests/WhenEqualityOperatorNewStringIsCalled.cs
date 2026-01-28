namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenEqualityOperatorNewStringIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        New? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEitherSideNullThenReturnsFalse()
    {
        // Arrange
        New left = Same;
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
        New left = Same;
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
        New left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}