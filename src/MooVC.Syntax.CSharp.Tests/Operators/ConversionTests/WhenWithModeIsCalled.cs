namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithModeIsCalled
{
    [Fact]
    public void GivenModeThenReturnsNewInstanceWithUpdatedMode()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Conversion.Type replacement = Conversion.Type.Explicit;

        // Act
        Conversion result = original.WithMode(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Direction.ShouldBe(original.Direction);
        result.Mode.ShouldBe(replacement);
        result.Scope.ShouldBe(original.Scope);
        result.Subject.ShouldBe(original.Subject);
    }
}