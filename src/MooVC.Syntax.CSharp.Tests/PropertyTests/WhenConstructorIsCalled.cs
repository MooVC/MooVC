namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenConstructorIsCalled
{
    private const string DefaultValue = "value";
    private const string PropertyName = "Name";
    private const string PropertyType = "string";

    [Test]
    public async Task GivenDefaultsThenPropertyIsUndefined()
    {
        // Act
        var subject = new Property();

        // Assert
        _ = await Assert.That(subject.Behaviours).IsEqualTo(Property.Methods.Default);
        _ = await Assert.That(subject.Default).IsEqualTo(Snippet.Empty);
        _ = await Assert.That(subject.IsUndefined).IsTrue();
        _ = await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
        _ = await Assert.That(subject.Type).IsEqualTo(Symbol.Undefined);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var behaviours = new Property.Methods
        {
            Get = Snippet.From(DefaultValue),
            Set = new Property.Setter
            {
                Behaviour = Snippet.From("value = input"),
                Mode = Property.Mode.Init,
                Scope = Scope.Private,
            },
        };

        // Act
        var subject = new Property
        {
            Behaviours = behaviours,
            Default = Snippet.From(DefaultValue),
            Name = PropertyName,
            Scope = Scope.Internal,
            Type = new Symbol { Name = PropertyType },
        };

        // Assert
        _ = await Assert.That(subject.Behaviours).IsEqualTo(behaviours);
        _ = await Assert.That(subject.Default).IsEqualTo(Snippet.From(DefaultValue));
        _ = await Assert.That(subject.IsUndefined).IsFalse();
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(PropertyName));
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        _ = await Assert.That(subject.Type).IsEqualTo(new Symbol { Name = PropertyType });
    }
}