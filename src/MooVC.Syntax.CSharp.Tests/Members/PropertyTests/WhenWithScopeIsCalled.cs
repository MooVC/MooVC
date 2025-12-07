namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create(scope: Scope.Internal);

        // Act
        Property result = original.WithScope(Scope.Private);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Behaviours.ShouldBe(original.Behaviours);
        result.Default.ShouldBe(original.Default);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(Scope.Private);
        result.Type.ShouldBe(original.Type);

        original.Scope.ShouldBe(Scope.Internal);
    }
}
