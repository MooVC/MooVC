namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenAValueThenReturnsTheValue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        string result = intent.ToString();

        // Assert
        result.ShouldBe(nameof(Conversion.Intent.From));
    }
}