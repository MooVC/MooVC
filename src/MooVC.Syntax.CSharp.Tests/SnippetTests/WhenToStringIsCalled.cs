namespace MooVC.Syntax.CSharp.SnippetTests;

using System;
using MooVC.Syntax.CSharp;
using Shouldly;
using Options = MooVC.Syntax.CSharp.Snippet.Options;

public sealed class WhenToStringIsCalled
{
    private const string FirstLine = "public class Example";
    private const string SecondLine = "{ }";

    [Fact]
    public void GivenNoOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var snippet = Snippet.From(FirstLine);
        Options? options = default;

        // Act
        Action action = () => snippet.ToString(options!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenOptionsThenJoinsLinesUsingTheProvidedNewLine()
    {
        // Arrange
        var options = new Options
        {
            NewLine = "|",
        };

        string value = string.Join(options.NewLine, FirstLine, SecondLine);
        var snippet = Snippet.From(value, options);

        // Act
        string result = snippet.ToString(options);

        // Assert
        result.ShouldBe(value);
    }
}