namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenEqualsIntentIsCalled
{
    [Test]
    public void GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(default(Conversion.Intent));

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenTheSameReferenceThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(intent);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Conversion.Intent.From);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
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