namespace MooVC.Syntax.CSharp.Members.PropertyTests.SetterTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenSetterIsDefault()
    {
        // Act
        var subject = new Property.Setter();

        // Assert
        subject.Behaviour.ShouldBe(Snippet.Empty);
        subject.IsDefault.ShouldBeTrue();
        subject.Mode.ShouldBe(Property.Mode.Init);
        subject.Scope.ShouldBe(Scope.Unspecified);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var behaviour = "value = input";

        // Act
        var subject = new Property.Setter
        {
            Behaviour = behaviour,
            Mode = Property.Mode.Init,
            Scope = Scope.Internal,
        };

        // Assert
        subject.Behaviour.ShouldBe(behaviour);
        subject.IsDefault.ShouldBeFalse();
        subject.Mode.ShouldBe(Property.Mode.Init);
        subject.Scope.ShouldBe(Scope.Internal);
    }
}