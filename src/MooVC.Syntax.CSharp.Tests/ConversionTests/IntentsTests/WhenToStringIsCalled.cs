namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenAValueThenReturnsTheValue()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        string result = intent.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(nameof(Conversion.Intents.From));
    }
}