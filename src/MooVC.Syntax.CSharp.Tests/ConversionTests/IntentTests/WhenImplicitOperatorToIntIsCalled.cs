namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenImplicitOperatorToIntIsCalled
{
    [Test]
    public async Task GivenAnIntentThenReturnsTheValue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        int value = intent;

        // Assert
        _ = await Assert.That(value).IsEqualTo(1);
    }
}