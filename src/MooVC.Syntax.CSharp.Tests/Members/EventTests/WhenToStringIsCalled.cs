namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenToStringIsCalled
{
    private const string Handler = "Handler";
    private const string Name = "Occurred";

    [Fact]
    public void GivenUndefinedEventThenEmptyReturned()
    {
        // Arrange
        Event subject = Event.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenNoBehavioursThenDeclarationReturned()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new Symbol { Name = Handler },
            Name = new Identifier(Name),
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe($"public event {Handler} {Name};");
    }

    [Fact]
    public void GivenBehavioursThenBodyIsRendered()
    {
        // Arrange
        var methods = new Event.Methods
        {
            Add = Snippet.From("value"),
            Remove = Snippet.From("Console.WriteLine(value)"),
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

        representation.ShouldBe(expected.ToString());
    }
}