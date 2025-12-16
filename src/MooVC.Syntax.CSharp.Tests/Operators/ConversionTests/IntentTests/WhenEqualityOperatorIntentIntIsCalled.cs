namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenEqualityOperatorIntentIntIsCalled
{
    private const int Same = 1;
    private const int Different = 0;

    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent? left = default;
        int? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent? left = default;
        int right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        int? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        int right = Same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent left = Conversion.Intent.From;
        int right = Different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}
