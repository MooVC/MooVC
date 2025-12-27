namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenConstructorIsCalled
{
    private const string Handler = "Handled";
    private const string Name = "Occurred";

    [Fact]
    public void GivenDefaultsThenEventIsUndefined()
    {
        // Act
        var subject = new Event();

        // Assert
        subject.Behaviours.ShouldBe(Event.Methods.Default);
        subject.Handler.ShouldBe(Symbol.Undefined);
        subject.IsUndefind.ShouldBeTrue();
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Scope.ShouldBe(Scope.Public);
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var behaviours = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        var subject = new Event
        {
            Behaviours = behaviours,
            Handler = new Symbol { Name = Handler },
            Name = new Identifier(Name),
            Scope = Scope.Private,
        };

        // Assert
        subject.Behaviours.ShouldBe(behaviours);
        subject.Handler.ShouldBe(new Symbol { Name = Handler });
        subject.IsUndefind.ShouldBeFalse();
        subject.Name.ShouldBe(new Identifier(Name));
        subject.Scope.ShouldBe(Scope.Private);
    }
}