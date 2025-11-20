namespace MooVC.Syntax.CSharp.Generics.Constraints.NatureTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Nature subject = Same;
        string? other = default;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = ((Nature?)other)?.Equals(subject) ?? false;

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
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

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
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}