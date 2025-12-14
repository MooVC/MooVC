namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenEqualityOperatorConversionConversionIsCalled
{
    [Fact]
    public void GivenEquivalentConversionsThenReturnsTrue()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create();

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentConversionsThenReturnsFalse()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create(subject: Symbol.From("Other"));

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeFalse();
    }
}
