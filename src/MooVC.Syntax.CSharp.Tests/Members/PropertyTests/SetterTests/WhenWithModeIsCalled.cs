namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

public sealed class WhenWithModeIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Property.Setter { Mode = Property.Mode.Set };

        // Act
        Property.Setter result = original.WithMode(Property.Mode.Init);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Behaviour).IsEqualTo(original.Behaviour);
        _ = await Assert.That(result.Mode).IsEqualTo(Property.Mode.Init);
        _ = await Assert.That(result.Scope).IsEqualTo(original.Scope);

        _ = await Assert.That(original.Mode).IsEqualTo(Property.Mode.Set);
    }
}