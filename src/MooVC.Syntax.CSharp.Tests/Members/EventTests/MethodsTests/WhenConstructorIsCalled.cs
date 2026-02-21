namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenInstanceIsDefault()
    {
        // Act
        var subject = new Event.Methods();

        // Assert
        subject.Add.ShouldBe(Snippet.Empty);
        subject.Remove.ShouldBe(Snippet.Empty);
        subject.IsDefault.ShouldBeTrue();
        subject.ShouldBe(Event.Methods.Default);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var add = Snippet.From("value");
        var remove = Snippet.From("result");

        // Act
        var subject = new Event.Methods
        {
            Add = add,
            Remove = remove,
        };

        // Assert
        subject.Add.ShouldBe(add);
        subject.Remove.ShouldBe(remove);
        subject.IsDefault.ShouldBeFalse();
    }
}