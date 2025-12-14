namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Conversion original = ConversionTestsData.Create();
        Scope replacement = Scope.Internal;

        // Act
        Conversion result = original.WithScope(replacement);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Direction.ShouldBe(original.Direction);
        result.Mode.ShouldBe(original.Mode);
        result.Scope.ShouldBe(replacement);
        result.Subject.ShouldBe(original.Subject);
    }
}
