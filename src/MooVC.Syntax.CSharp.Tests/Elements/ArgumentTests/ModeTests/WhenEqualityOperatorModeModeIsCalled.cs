namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenEqualityOperatorModeModeIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Argument.Mode? left = default;
        Argument.Mode? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Argument.Mode? left = default;
        Argument.Mode right = Argument.Mode.In;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.In;
        Argument.Mode? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Argument.Mode first = Argument.Mode.In;
        Argument.Mode second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Mode left = Argument.Mode.Ref;
        Argument.Mode right = Argument.Mode.Ref;

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
        Argument.Mode left = Argument.Mode.Out;
        Argument.Mode right = Argument.Mode.In;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}