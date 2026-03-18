namespace MooVC.Syntax.Elements.SnippetTests;

public sealed class WhenToStringIsCalled
{
    private static readonly string[] _lines = ["if (condition)", "return true;"];

    [Test]
    public async Task GivenDefaultOptionsThenReturnsJoinedLines()
    {
        // Arrange
        var subject = Snippet.From(_lines);

        const string expected = """
            if (condition)
            return true;
            """;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}