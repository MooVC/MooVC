namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenEqualityOperatorIntentIntentIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent? left = default;
        Conversion.Intent? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameValuesThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        Conversion.Intent right = Conversion.Intent.From;

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
        Conversion.Intent left = Conversion.Intent.From;
        Conversion.Intent right = Conversion.Intent.To;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}
