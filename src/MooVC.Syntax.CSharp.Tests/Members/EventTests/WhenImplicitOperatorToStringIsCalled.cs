namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Handler = "Handler";
    private const string Name = "Occurred";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Event? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
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