namespace MooVC.Syntax.CSharp.Members.EventTests.MethodsTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenDefaultInstanceThenReturnsEmpty()
    {
        // Arrange
        Event.Methods subject = Event.Methods.Default;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenAutoImplementedMembersThenReturnsSignatures()
    {
        // Arrange
        var subject = new Event.Methods();

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = Snippet.From("add;")
            .Append(Snippet.Options.Default, Environment.NewLine)
            .Append("remove;")
            .ToString();

        representation.ShouldBe(expected);
    }

    [Fact]
    public void GivenExpressionBodiesThenReturnsExpressions()
    {
        // Arrange
        var subject = new Event.Methods
        {
            Add = Snippet.From("value"),
        };

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = Snippet.From($"add => {subject.Add}")
            .Append(Snippet.Options.Default, Environment.NewLine)
            .Append("remove;")
            .ToString();

        representation.ShouldBe(expected);
    }

    [Fact]
    public void GivenMultiLineBodyThenReturnsBlock()
    {
        // Arrange
        Snippet add = Snippet.From($"first{Environment.NewLine}second");
        var subject = new Event.Methods
        {
            Add = add,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        string expected = add
            .Block(Snippet.Options.Default, opening: Snippet.From("add"))
            .Append(Snippet.Options.Default, Environment.NewLine)
            .Append("remove;")
            .ToString();

        representation.ShouldBe(expected);
    }
}
