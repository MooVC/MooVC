namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        Property original = PropertyTestsData.Create(scope: Scope.Internal);

        // Act
        Property result = original.WithScope(Scope.Private);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Scope).IsEqualTo(Scope.Private);
        await Assert.That(result.Type).IsEqualTo(original.Type);

        await Assert.That(original.Scope).IsEqualTo(Scope.Internal);
    }
}