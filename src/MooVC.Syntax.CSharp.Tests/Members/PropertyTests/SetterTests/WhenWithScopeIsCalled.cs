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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Behaviour).IsEqualTo(original.Behaviour);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Scope).IsEqualTo(Scope.Private);

        _ = await Assert.That(original.Scope).IsEqualTo(Scope.Internal);
    }
}