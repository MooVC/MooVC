namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string Value = "42";

    [Test]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Argument subject = Argument.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
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