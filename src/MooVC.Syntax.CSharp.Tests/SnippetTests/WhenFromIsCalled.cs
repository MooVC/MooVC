namespace MooVC.Syntax.CSharp.SnippetTests;

using System;
using System.Globalization;
using MooVC.Syntax.CSharp;
using Shouldly;
using Options = MooVC.Syntax.CSharp.Snippet.Options;

public sealed class WhenFromIsCalled
{
    private const string FirstLine = "public class Example";
    private const string SecondLine = "{ }";

    [Fact]
    public void GivenNoOptionsThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        const string value = FirstLine;
        Options? options = default;

        // Act
        Action action = () => Snippet.From(value, options!);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.Message.ShouldStartWith(
            string.Format(
                CultureInfo.InvariantCulture,
                "The `{0}` for parsing the `{1}` must be provided.",
                nameof(Snippet.Options),
                nameof(value)));
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenNoValueThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Options options = Options.Default;
        string? value = default;

        // Act
        Action action = () => Snippet.From(value!, options);

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(action);
        exception.Message.ShouldStartWith(
            string.Format(
                CultureInfo.InvariantCulture,
                "The `{0}` must be provided.",
                nameof(value)));
        exception.ParamName.ShouldBe(nameof(value));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenEmptyOrWhitespaceThenReturnsEmptySnippet(string value)
    {
        // Arrange & Act
        Snippet result = Snippet.From(value);

        // Assert
        result.ShouldBe(Snippet.Empty);
        result.IsEmpty.ShouldBeTrue();
    }

    [Fact]
    public void GivenValueThenCreatesSnippetWithTheProvidedLines()
    {
        // Arrange
        var options = new Options
        {
            NewLine = "\n",
        };

        string value = string.Join(options.NewLine, FirstLine, SecondLine);

        // Act
        Snippet result = Snippet.From(value, options);

        // Assert
        result.IsEmpty.ShouldBeFalse();
        result.ToString(options).ShouldBe(value);
    }
}