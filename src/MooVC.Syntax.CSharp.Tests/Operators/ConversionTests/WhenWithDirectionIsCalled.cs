namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithDirectionIsCalled
{
    [Fact]
    public void GivenDirectionThenReturnsNewInstanceWithUpdatedDirection()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Conversion.Intent replacement = Conversion.Intent.From;

        // Act
        Conversion result = original.WithDirection(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Direction.ShouldBe(replacement);
        result.Mode.ShouldBe(original.Mode);
        result.Scope.ShouldBe(original.Scope);
        result.Subject.ShouldBe(original.Subject);
    }
}
