namespace MooVC.Syntax.CSharp.ConversionTests.TypesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenTheUnderlyingValueIsReturned()
    {
        // Arrange
        Conversion.Types type = Conversion.Types.Explicit;

        // Act
        string value = type.ToString();

        // Assert
        _ = await Assert.That(value).IsEqualTo("explicit");
    }
}