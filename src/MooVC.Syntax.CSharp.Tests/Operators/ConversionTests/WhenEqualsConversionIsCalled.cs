namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenEqualsConversionIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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