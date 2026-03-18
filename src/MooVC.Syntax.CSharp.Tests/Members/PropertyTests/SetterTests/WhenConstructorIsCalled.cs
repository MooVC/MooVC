namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenSetterIsDefault()
    {
        // Act
        var subject = new Property.Setter();

        // Assert
        await Assert.That(subject.Behaviour).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsDefault).IsTrue();
        await Assert.That(subject.Mode).IsEqualTo(Property.Mode.Init);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Unspecified);
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
        await Assert.That(subject.Behaviour).IsEqualTo(behaviour);
        await Assert.That(subject.IsDefault).IsFalse();
        await Assert.That(subject.Mode).IsEqualTo(Property.Mode.Init);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
    }
}