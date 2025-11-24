namespace MooVC.Syntax.CSharp.Members.ArgumentTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "value";
    private const string Content = "argument";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Argument? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenArgumentThenStringMatchesToString()
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
        result.ShouldBe(subject.ToString());
    }
}