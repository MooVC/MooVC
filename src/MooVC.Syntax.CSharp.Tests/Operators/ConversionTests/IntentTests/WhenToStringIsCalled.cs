namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenAValueThenReturnsTheValue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        string result = intent.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(nameof(Conversion.Intent.From));
    }
}