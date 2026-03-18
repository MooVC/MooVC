namespace MooVC.Syntax.CSharp.PropertyTests.SetterTests;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenSetterIsDefault()
    {
        // Act
        var subject = new Property.Setter();

        // Assert
        _ = await Assert.That(subject.Behaviour).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsDefault).IsTrue();
        _ = await Assert.That(subject.Mode).IsEqualTo(Property.Mode.Init);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Unspecified);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var behaviour = Snippet.From("value = input");

        // Act
        var subject = new Property.Setter
        {
            Behaviour = behaviour,
            Mode = Property.Mode.Init,
            Scope = Scope.Internal,
        };

        // Assert
        _ = await Assert.That(subject.Behaviour).IsEqualTo(behaviour);
        _ = await Assert.That(subject.IsDefault).IsFalse();
        _ = await Assert.That(subject.Mode).IsEqualTo(Property.Mode.Init);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
    }
}