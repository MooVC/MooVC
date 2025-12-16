namespace MooVC.Syntax.CSharp.Operators.ConversionTests.IntentTests;

public sealed class WhenImplicitOperatorToIntIsCalled
{
    [Fact]
    public void GivenAnIntentThenReturnsTheValue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        int value = intent;

        // Assert
        value.ShouldBe(1);
    }
}