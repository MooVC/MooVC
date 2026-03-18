namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

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
        await Assert.That(subject.Behaviours).IsEqualTo(Property.Methods.Default);
        await Assert.That(subject.Default).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.IsUndefined).IsTrue();
        await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
        await Assert.That(subject.Type).IsEqualTo(Symbol.Undefined);
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
        await Assert.That(subject.Behaviours).IsEqualTo(behaviours);
        await Assert.That(subject.Default).IsEqualTo(Snippet.From(DefaultValue));
        await Assert.That(subject.IsUndefined).IsFalse();
        await Assert.That(subject.Name).IsEqualTo(new Name(PropertyName));
        await Assert.That(subject.Scope).IsEqualTo(Scope.Internal);
        await Assert.That(subject.Type).IsEqualTo(new Symbol { Name = PropertyType });
    }
}