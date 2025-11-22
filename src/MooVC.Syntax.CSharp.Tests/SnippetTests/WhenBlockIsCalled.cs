namespace MooVC.Syntax.CSharp.SnippetTests;

using System;
using MooVC.Syntax.CSharp;
using Shouldly;
using BlockStyle = MooVC.Syntax.CSharp.Snippet.BlockStyle;
using Options = MooVC.Syntax.CSharp.Snippet.Options;

public sealed class WhenBlockIsCalled
{
    private const string Condition = "if (value)";
    private const string Statement = "return value;";

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
        Action action = () => snippet.Block(options!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.Message.ShouldStartWith("The options required to format the block.");
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenAllmanStyleThenFormattingOccursUsingTheAllmanConvention()
    {
        // Arrange
        var options = new Options
        {
            BlockStyle = BlockStyle.Allman,
            NewLine = CreationOptions.NewLine,
        };

        Snippet snippet = CreateSnippet();

        // Act
        Snippet result = snippet.Block(options);

        // Assert
        result.ToString(options).ShouldBe(
            string.Join(
                options.NewLine,
                Condition,
                "{",
                Statement,
                "}"));
    }

    [Fact]
    public void GivenKAndRStyleThenFormattingOccursUsingTheKAndRConvention()
    {
        // Arrange
        var options = new Options
        {
            BlockStyle = BlockStyle.KAndR,
            NewLine = CreationOptions.NewLine,
        };

        Snippet snippet = CreateSnippet();

        // Act
        Snippet result = snippet.Block(options);

        // Assert
        result.ToString(options).ShouldBe(
            string.Join(
                options.NewLine,
                string.Concat(Condition, " {"),
                Statement,
                "}"));
    }

    private static Snippet CreateSnippet()
    {
        return Snippet.From(
            string.Join(CreationOptions.NewLine, Condition, Statement),
            CreationOptions);
    }
}