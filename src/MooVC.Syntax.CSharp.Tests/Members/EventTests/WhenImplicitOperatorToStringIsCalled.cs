namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Handler = "Handler";
    private const string Name = "Occurred";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Event? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenEventThenStringMatchesToString()
    {
        // Arrange
        var subject = new Event
        {
            Handler = new Symbol { Name = Handler },
            Name = Name,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}