namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string DefaultValue = "value";
    private const string PropertyName = "Name";
    private const string PropertyType = "string";

    [Fact]
    public void GivenDefaultsThenPropertyIsUndefined()
    {
        // Act
        var subject = new Property();

        // Assert
        subject.Behaviours.ShouldBe(Property.Methods.Default);
        subject.Default.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
        subject.Name.ShouldBe(Name.Unnamed);
        subject.Scope.ShouldBe(Scope.Public);
        subject.Type.ShouldBe(Symbol.Undefined);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
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
        subject.Behaviours.ShouldBe(behaviours);
        subject.Default.ShouldBe(Snippet.From(DefaultValue));
        subject.IsUndefined.ShouldBeFalse();
        subject.Name.ShouldBe(new Name(PropertyName));
        subject.Scope.ShouldBe(Scope.Internal);
        subject.Type.ShouldBe(new Symbol { Name = PropertyType });
    }
}