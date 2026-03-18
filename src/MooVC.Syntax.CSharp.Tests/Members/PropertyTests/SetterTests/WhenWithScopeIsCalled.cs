namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Setter { Scope = Scope.Internal };

        // Act
        Property.Setter result = original.WithScope(Scope.Private);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviour).IsEqualTo(original.Behaviour);
        await Assert.That(result.Mode).IsEqualTo(original.Mode);
        await Assert.That(result.Scope).IsEqualTo(Scope.Private);

        await Assert.That(original.Scope).IsEqualTo(Scope.Internal);
    }
}