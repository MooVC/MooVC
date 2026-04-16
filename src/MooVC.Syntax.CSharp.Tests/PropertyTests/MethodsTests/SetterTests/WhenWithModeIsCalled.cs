namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenWithModeIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Methods.Setter { Mode = Property.Methods.Setter.Modes.Set };

        // Act
        Property.Methods.Setter result = original.WithMode(Property.Methods.Setter.Modes.Init);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Behaviour).IsEqualTo(original.Behaviour);
        _ = await Assert.That(result.Mode).IsEqualTo(Property.Methods.Setter.Modes.Init);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);

        _ = await Assert.That(original.Mode).IsEqualTo(Property.Methods.Setter.Modes.Set);
    }
}