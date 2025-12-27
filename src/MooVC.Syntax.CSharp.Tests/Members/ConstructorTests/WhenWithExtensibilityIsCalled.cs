namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

public sealed class WhenWithExtensibilityIsCalled
{
    [Fact]
    public void GivenExtensibilityThenReturnsNewInstanceWithUpdatedExtensibility()
    {
        // Arrange
        Constructor original = ConstructorTestsData.Create();

        // Act
        Constructor result = original.WithExtensibility(Extensibility.Static);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Body.ShouldBe(original.Body);
        result.Extensibility.ShouldBe(Extensibility.Static);
        result.Parameters.ShouldBe(original.Parameters);
        result.Scope.ShouldBe(original.Scope);

        original.Extensibility.ShouldBe(Extensibility.Implicit);
    }
}