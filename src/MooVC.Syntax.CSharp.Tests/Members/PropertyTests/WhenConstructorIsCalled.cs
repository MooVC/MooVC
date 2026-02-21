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
            Get = DefaultValue,
            Set = new Property.Setter
            {
                Behaviour = "value = input",
                Mode = Property.Mode.Init,
                Scope = Scope.Private,
            },
        };

        // Act
        var subject = new Property
        {
            Behaviours = behaviours,
            Default = DefaultValue,
            Name = PropertyName,
            Scope = Scope.Internal,
            Type = new Symbol { Name = PropertyType },
        };

        // Assert
        subject.Behaviours.ShouldBe(behaviours);
        subject.Default.ShouldBe(DefaultValue);
        subject.IsUndefined.ShouldBeFalse();
        subject.Name.ShouldBe(PropertyName);
        subject.Scope.ShouldBe(Scope.Internal);
        subject.Type.ShouldBe(new Symbol { Name = PropertyType });
    }
}