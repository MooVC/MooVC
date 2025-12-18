namespace MooVC.Syntax.CSharp.SnippetTests;

using System;

public sealed class WhenToStringIsCalled
{
    private static readonly string[] lines = ["if (condition)", "return true;"];

    [Fact]
    public void GivenDefaultOptionsThenReturnsJoinedLines()
    {
        // Arrange
        var subject = Snippet.From(lines);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(
            """
            if (condition)
            return true;
            """.ReplaceLineEndings(Environment.NewLine).Trim());
    }

    [Fact]
    public void GivenCustomNewLineThenUsesCustomSeparator()
    {
        // Arrange
        const string expected = "if (condition)|return true;";

        Snippet.Options options = new Snippet.Options()
            .WithNewLine("|");

        Snippet subject = Snippet.From(options, lines);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}