namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "value";
    private const string Content = "argument";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenArgumentThenStringMatchesToString()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
            Value = Snippet.From(Content),
        };

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}