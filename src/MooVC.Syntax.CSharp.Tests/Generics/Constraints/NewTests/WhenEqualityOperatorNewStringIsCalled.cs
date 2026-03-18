namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenEqualityOperatorNewStringIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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