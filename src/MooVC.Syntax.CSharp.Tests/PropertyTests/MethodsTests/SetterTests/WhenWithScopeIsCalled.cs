namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenWithScopeIsCalled
{
    [Test]
    public async Task GivenScopeThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Methods.Setter { Scope = Scope.Internal };

        // Act
        Property.Methods.Setter result = original.WithScope(Scope.Private);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviour).IsEqualTo(original.Behaviour);
        _ = await Assert.That(result.Mode).IsEqualTo(original.Mode);
        _ = await Assert.That(result.Scope).IsEqualTo(Scope.Private);

        _ = await Assert.That(original.Scope).IsEqualTo(Scope.Internal);
    }
}