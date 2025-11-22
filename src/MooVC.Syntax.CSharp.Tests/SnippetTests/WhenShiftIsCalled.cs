namespace MooVC.Syntax.CSharp.SnippetTests;

using System;
using MooVC.Syntax.CSharp;
using Shouldly;
using Options = MooVC.Syntax.CSharp.Snippet.Options;

public sealed class WhenShiftIsCalled
{
    private const string FirstLine = "public class Example";
    private const string SecondLine = "{ }";

    private static readonly Options CreationOptions = new()
    {
        NewLine = "\n",
    };

    [Fact]
    public void GivenNoOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Snippet snippet = CreateSnippet();
        Options? options = default;

        // Act
        Action action = () => snippet.Shift(options!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.Message.ShouldStartWith("The options required to direct the shift must be provided.");
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenAnEmptySnippetThenReturnsEmptySnippet()
    {
        // Arrange
        Snippet snippet = Snippet.Empty;
        var options = new Options
        {
            NewLine = CreationOptions.NewLine,
            Whitespace = "--",
        };

        // Act
        Snippet result = snippet.Shift(options);

        // Assert
        result.ShouldBe(Snippet.Empty);
        result.IsEmpty.ShouldBeTrue();
    }

    [Fact]
    public void GivenLinesThenWhitespaceIsPrependedToEachLine()
    {
        // Arrange
        Snippet snippet = CreateSnippet();
        var options = new Options
        {
            NewLine = CreationOptions.NewLine,
            Whitespace = "    ",
        };

        // Act
        Snippet result = snippet.Shift(options);

        // Assert
        result.ToString(options).ShouldBe(
            string.Join(
                options.NewLine,
                string.Concat(options.Whitespace, FirstLine),
                string.Concat(options.Whitespace, SecondLine)));
    }

    private static Snippet CreateSnippet()
    {
        return Snippet.From(
            string.Join(CreationOptions.NewLine, FirstLine, SecondLine),
            CreationOptions);
    }
}