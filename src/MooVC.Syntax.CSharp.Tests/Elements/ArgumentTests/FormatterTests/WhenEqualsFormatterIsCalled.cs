namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenEqualsFormatterIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument.Formatter left = Argument.Formatter.Declaration;
        Argument.Formatter right = Argument.Formatter.Declaration;

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
        Argument.Formatter left = Argument.Formatter.Call;
        Argument.Formatter right = Argument.Formatter.Declaration;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}