namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenMethodsIsDefault()
    {
        // Act
        var subject = new Property.Methods();

        // Assert
        subject.Get.ShouldBe(Snippet.Empty);
        subject.IsDefault.ShouldBeTrue();
        subject.Set.ShouldBe(Property.Setter.Default);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
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
        subject.Get.ShouldBe(get);
        subject.IsDefault.ShouldBeFalse();
        subject.Set.ShouldBe(set);
    }
}
