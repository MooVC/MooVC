namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;
using static MooVC.Syntax.Elements.Name;

public sealed class WhenConstructorIsCalled
{
    private const string Handler = "Handled";
    private const string Name = "Occurred";

    [Test]
    public async Task GivenDefaultsThenEventIsUndefined()
    {
        // Act
        var subject = new Event();

        // Assert
        await Assert.That(subject.Behaviours).IsEqualTo(Event.Methods.Default);
        await Assert.That(subject.Handler).IsEqualTo(Symbol.Undefined);
        await Assert.That(subject.IsUndefind).IsTrue();
        await Assert.That(subject.Name).IsEqualTo(Unnamed);
        await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
            Name = new Name(Name),
            Scope = Scope.Private,
        };

        // Assert
        await Assert.That(subject.Behaviours).IsEqualTo(behaviours);
        await Assert.That(subject.Handler).IsEqualTo(new Symbol { Name = Handler });
        await Assert.That(subject.IsUndefind).IsFalse();
        await Assert.That(subject.Name).IsEqualTo(new Name(Name));
        await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
    }
}