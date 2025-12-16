namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenInequalityOperatorIntentIntentIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent? left = default;
        Conversion.Intent? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameValuesThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        Conversion.Intent right = Conversion.Intent.From;

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
        Conversion.Intent left = Conversion.Intent.From;
        Conversion.Intent right = Conversion.Intent.To;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
