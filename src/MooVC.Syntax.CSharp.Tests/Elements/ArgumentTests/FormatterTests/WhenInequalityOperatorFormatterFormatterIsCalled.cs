namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenInequalityOperatorFormatterFormatterIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter? left = default;
        Argument.Formatter? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter? left = default;
        Argument.Formatter right = Argument.Formatter.Call;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        Argument.Formatter? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter first = Argument.Formatter.Declaration;
        Argument.Formatter second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        Argument.Formatter right = Argument.Formatter.Call;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Call;
        Argument.Formatter right = Argument.Formatter.Declaration;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}