namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenMethodsIsDefault()
    {
        // Act
        var subject = new Property.Methods();

        // Assert
        _ = await Assert.That(subject.Get).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsDefault).IsTrue();
        _ = await Assert.That(subject.Set).IsEqualTo(Property.Setter.Default);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var get = Snippet.From("value");
        var set = new Property.Setter { Behaviour = Snippet.From("value = input"), Mode = Property.Mode.Set };

        // Act
        var subject = new Property.Methods
        {
            Get = get,
            Set = set,
        };

        // Assert
        _ = await Assert.That(subject.Get).IsEqualTo(get);
        _ = await Assert.That(subject.IsDefault).IsFalse();
        _ = await Assert.That(subject.Set).IsEqualTo(set);
    }
}