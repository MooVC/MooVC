namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenEqualsIntIsCalled
{
    private const int Value = 1;
    private const int Other = 0;

    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(null as int?);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Value);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Other);

        // Assert
        result.ShouldBeFalse();
    }
}
