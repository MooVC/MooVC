namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests.SetterTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenSetterIsDefault()
    {
        // Act
        var subject = new Property.Methods.Setter();

        // Assert
        _ = await Assert.That(subject.Behaviour).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsDefault).IsTrue();
        _ = await Assert.That(subject.Mode).IsEqualTo(Property.Methods.Setter.Modes.Init);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Unspecified);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var behaviour = Snippet.From("value = input");

        // Act
        var subject = new Property.Methods.Setter
        {
            Behaviour = behaviour,
            Mode = Property.Methods.Setter.Modes.Init,
            Scope = Scopes.Internal,
        };

        // Assert
        _ = await Assert.That(subject.Behaviour).IsEqualTo(behaviour);
        _ = await Assert.That(subject.IsDefault).IsFalse();
        _ = await Assert.That(subject.Mode).IsEqualTo(Property.Methods.Setter.Modes.Init);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scopes.Internal);
    }
}