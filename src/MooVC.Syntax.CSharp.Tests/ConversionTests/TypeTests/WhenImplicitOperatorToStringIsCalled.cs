namespace MooVC.Syntax.CSharp.ConversionTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheValueIsReturned()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo("explicit");
    }
}