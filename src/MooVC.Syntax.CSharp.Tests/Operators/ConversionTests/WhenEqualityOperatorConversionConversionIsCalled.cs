namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;

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
        Conversion second = ConversionTestsData.Create(subject: new Symbol { Name = "SomethingElse" });

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeFalse();
    }
}