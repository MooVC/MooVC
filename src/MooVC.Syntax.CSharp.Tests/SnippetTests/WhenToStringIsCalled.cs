namespace MooVC.Syntax.CSharp.SnippetTests;

using System;
using System.Collections.Immutable;

public sealed class WhenToStringIsCalled
{
    private static readonly ImmutableArray<string> lines = ["if (condition)", "return true;"];

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Snippet(lines);
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToString(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenDefaultOptionsThenReturnsJoinedLines()
    {
        // Arrange
        var subject = new Snippet(lines);

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

        var subject = new Snippet(lines);

        Snippet.Options options = new Snippet.Options()
            .WithNewLine("|");

        // Act
        string result = subject.ToString(options);

        // Assert
        result.ShouldBe(expected);
    }
}