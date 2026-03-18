namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(null as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(intent as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Conversion.Intent.From as object);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Conversion.Intent.To as object);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
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