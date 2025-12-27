namespace MooVC.Syntax.CSharp.Members.ArgumentTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    private const string Value = "42";

    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Argument subject = Argument.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenUnnamedValueThenReturnsValueOnly()
    {
        // Arrange
        var subject = new Argument
        {
            Name = Identifier.Unnamed,
            Value = Snippet.From(Value),
        };

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Value);
    }
}