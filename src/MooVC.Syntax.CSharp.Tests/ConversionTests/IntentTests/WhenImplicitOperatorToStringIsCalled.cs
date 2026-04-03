namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenAnIntentThenReturnsTheValue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        string value = intent;

        // Assert
        _ = await Assert.That(value).IsEqualTo("From");
    }
}