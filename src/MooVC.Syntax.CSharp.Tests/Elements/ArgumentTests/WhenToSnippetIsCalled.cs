namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using System;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string Name = "Value";
    private const string Value = "42";

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Argument { Name = "Value" };
        Argument.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(
            () => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenNamedValueThenAppliesFormatterAndNaming()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
            Value = Snippet.From(Value),
        };

        var options = new Argument.Options
        {
            Naming = Identifier.Options.Camel,
            Formatter = Argument.Formatter.Call,
        };

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("value: 42");
    }

    [Fact]
    public void GivenModifierThenModifierIsPrefixed()
    {
        // Arrange
        var subject = new Argument
        {
            Modifier = Argument.Mode.Ref,
            Name = new Identifier(Name),
            Value = Snippet.From(Value),
        };

        var options = new Argument.Options
        {
            Naming = Identifier.Options.Camel,
            Formatter = Argument.Formatter.Call,
        };

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldBe("value: ref 42");
    }
}