namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenAnIntentThenReturnsTheValue()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        string value = intent;

        // Assert
        _ = await Assert.That(value).IsEqualTo("From");
    }
}