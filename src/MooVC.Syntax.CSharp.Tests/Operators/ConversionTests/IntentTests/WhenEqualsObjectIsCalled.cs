namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(null as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(intent as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Conversion.Intent.From as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Conversion.Intent.To as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenAnUnrecognisedTypeThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }
}