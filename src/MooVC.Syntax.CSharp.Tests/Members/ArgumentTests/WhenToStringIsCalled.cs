namespace MooVC.Syntax.CSharp.Members.ArgumentTests;

using System;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    private const string Name = "Value";
    private const string Value = "42";

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Argument();
        Argument.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(
            () => _ = subject.ToString(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Argument subject = Argument.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenUnnamedValueThenReturnsValueOnly()
    {
        // Arrange
        var subject = new Argument
        {
            Name = Identifier.Unnamed,
            Value = Snippet.From(Value),
        };

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Value);
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
        string result = subject.ToString(options);

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
        string result = subject.ToString(options);

        // Assert
        result.ShouldBe("value: ref 42");
    }
}
