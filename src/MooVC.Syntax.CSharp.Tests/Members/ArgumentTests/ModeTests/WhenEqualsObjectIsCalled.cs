namespace MooVC.Syntax.CSharp.Members.ArgumentTests.ModeTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.In;
        object? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Argument.Mode first = Argument.Mode.In;
        object second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.Out;
        object right = Argument.Mode.Out;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Mode)right).Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.Out;
        object right = Argument.Mode.Ref;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument.Mode)right).Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.Out;
        object right = "out";

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}
