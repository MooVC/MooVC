namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo("explicit");
    }
}