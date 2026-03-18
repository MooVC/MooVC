namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create(scope: Scope.Public);

        // Act
        Class result = original.WithScope(Scope.Private);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Scope).IsEqualTo(Scope.Private);
        await Assert.That(original.Scope).IsEqualTo(Scope.Public);
    }
}