namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests;

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
        _ = await Assert.That(subject.Set).IsEqualTo(Property.Methods.Setter.Default);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var get = Snippet.From("value");
        var set = new Property.Methods.Setter { Behaviour = Snippet.From("value = input"), Mode = Property.Methods.Setter.Modes.Set };

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