namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenInequalityOperatorConversionConversionIsCalled
{
    [Fact]
    public void GivenEquivalentConversionsThenReturnsFalse()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create();

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentConversionsThenReturnsTrue()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create(subject: Symbol.From("Other"));

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeTrue();
    }
}
