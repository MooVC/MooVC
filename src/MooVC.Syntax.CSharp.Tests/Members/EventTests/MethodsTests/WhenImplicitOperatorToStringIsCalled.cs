namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Event.Methods? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenMethodsThenStringMatchesToString()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("add => value"),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}