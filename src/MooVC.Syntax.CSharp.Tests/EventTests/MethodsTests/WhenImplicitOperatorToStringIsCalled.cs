namespace MooVC.Syntax.CSharp.EventTests.MethodsTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenMethodsThenStringMatchesToString()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("add => value"),
        };

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Event.Methods? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}