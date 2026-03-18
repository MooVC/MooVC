namespace MooVC.Syntax.CSharp.ConversionTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Conversion.Type type = Conversion.Type.Explicit;

        // Act
        string value = type.ToString();

        // Assert
        _ = await Assert.That(value).IsEqualTo("explicit");
    }
}