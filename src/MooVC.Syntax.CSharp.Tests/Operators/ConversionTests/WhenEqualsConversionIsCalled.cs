namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenEqualsConversionIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Conversion? subject = default;
        Conversion target = ConversionTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        Conversion target = ConversionTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        Conversion target = ConversionTestsData.Create(mode: Conversion.Type.Explicit);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}