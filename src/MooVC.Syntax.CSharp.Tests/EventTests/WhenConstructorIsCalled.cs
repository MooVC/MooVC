namespace MooVC.Syntax.CSharp.EventTests;

using static MooVC.Syntax.Name;

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
        _ = await Assert.That(subject.Behaviours).IsEqualTo(Event.Methods.Default);
        _ = await Assert.That(subject.Handler).IsEqualTo(Symbol.Undefined);
        _ = await Assert.That(subject.IsUndefind).IsTrue();
        _ = await Assert.That(subject.Name).IsEqualTo(Unnamed);
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Public);
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
        _ = await Assert.That(subject.Behaviours).IsEqualTo(behaviours);
        _ = await Assert.That(subject.Handler).IsEqualTo(new Symbol { Name = Handler });
        _ = await Assert.That(subject.IsUndefind).IsFalse();
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(Name));
        _ = await Assert.That(subject.Scope).IsEqualTo(Scope.Private);
    }
}