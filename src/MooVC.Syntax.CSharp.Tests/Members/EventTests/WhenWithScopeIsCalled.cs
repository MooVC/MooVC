namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Event original = EventTestsData.Create(scope: Scope.Internal);

        // Act
        Event result = original.WithScope(Scope.Private);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Scope.ShouldBe(Scope.Private);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Handler.ShouldBe(original.Handler);
        result.Name.ShouldBe(original.Name);
    }
}
