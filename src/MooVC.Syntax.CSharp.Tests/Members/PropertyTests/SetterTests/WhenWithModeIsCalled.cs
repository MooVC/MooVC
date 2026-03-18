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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Behaviour).IsEqualTo(original.Behaviour);
        await Assert.That(result.Mode).IsEqualTo(Property.Mode.Init);
        await Assert.That(result.Scope).IsEqualTo(original.Scope);

        await Assert.That(original.Mode).IsEqualTo(Property.Mode.Set);
    }
}