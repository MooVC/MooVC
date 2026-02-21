namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "value";
    private const string Content = "argument";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Argument? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenArgumentThenStringMatchesToString()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
            Value = Content,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}