namespace MooVC.Syntax.CSharp.EventTests;

public sealed class WhenToStringIsCalled
{
    private const string Handler = "Handler";
    private const string Name = "Occurred";

    [Test]
    public async Task GivenUndefinedEventThenEmptyReturned()
    {
        // Arrange
        Event subject = Event.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenNoBehavioursThenDeclarationReturned()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new Symbol { Name = Handler },
            Name = new Name(Name),
        };

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo($"public event {Handler} {Name};");
    }

    [Test]
    public async Task GivenBehavioursThenBodyIsRendered()
    {
        // Arrange
        var methods = new Event.Methods
        {
            Add = Snippet.From("value;"),
            Remove = Snippet.From("Console.WriteLine(value);"),
        };

        Event subject = EventTestsData.Create(behaviours: methods);

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = """
            public event Handler Occurred
            {
                add => value;
                remove => Console.WriteLine(value);
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected.ToString());
    }
}