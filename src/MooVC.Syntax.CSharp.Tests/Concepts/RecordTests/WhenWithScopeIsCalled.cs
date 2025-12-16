namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Fact]
    public void GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Record original = RecordTestsData.Create(scope: Scope.Internal);

        // Act
        Record result = original.WithScope(Scope.Protected);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Scope.ShouldBe(Scope.Protected);
        original.Scope.ShouldBe(Scope.Internal);
    }
}