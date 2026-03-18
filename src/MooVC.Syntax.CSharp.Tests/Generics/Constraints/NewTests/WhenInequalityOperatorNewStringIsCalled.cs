namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenInequalityOperatorNewStringIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        New? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEitherSideNullThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        string? right = default;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}