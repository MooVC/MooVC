namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorConversionConversionIsCalled
{
    [Test]
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

    [Test]
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