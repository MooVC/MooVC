namespace MooVC.Syntax.CSharp.ConversionTests;

public sealed class WhenInequalityOperatorConversionConversionIsCalled
{
    [Test]
    public async Task GivenEquivalentConversionsThenReturnsFalse()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create();

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentConversionsThenReturnsTrue()
    {
        // Arrange
        Conversion first = ConversionTestsData.Create();
        Conversion second = ConversionTestsData.Create(subject: new Symbol { Name = "SomethingElse" });

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}