namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenEqualsIntentIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(null as Conversion.Intent);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(intent);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Conversion.Intent.From);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Conversion.Intent.To);

        // Assert
        result.ShouldBeFalse();
    }
}
