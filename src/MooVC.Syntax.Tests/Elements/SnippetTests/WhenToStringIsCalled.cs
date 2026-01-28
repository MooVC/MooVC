namespace MooVC.Syntax.Elements.SnippetTests;

public sealed class WhenToStringIsCalled
{
    private static readonly string[] lines = ["if (condition)", "return true;"];

    [Fact]
    public void GivenDefaultOptionsThenReturnsJoinedLines()
    {
        // Arrange
        var subject = Snippet.From(lines);

        const string expected = """
            if (condition)
            return true;
            """;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}