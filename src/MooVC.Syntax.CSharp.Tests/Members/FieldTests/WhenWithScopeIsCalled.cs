namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsNewInstanceWithUpdatedScope()
    {
        // Arrange
        Field original = FieldTestsData.Create();

        // Act
        Field result = original.WithScope(Scope.Internal);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Default.ShouldBe(original.Default);
        result.IsReadOnly.ShouldBe(original.IsReadOnly);
        result.IsStatic.ShouldBe(original.IsStatic);
        result.Name.ShouldBe(original.Name);
        result.Scope.ShouldBe(Scope.Internal);
        result.Type.ShouldBe(original.Type);

        original.Scope.ShouldBe(Scope.Public);
    }
}
