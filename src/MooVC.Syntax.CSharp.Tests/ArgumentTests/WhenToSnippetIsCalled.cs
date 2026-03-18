namespace MooVC.Syntax.CSharp.ArgumentTests;

using System;

public sealed class WhenToSnippetIsCalled
{
    private const string Name = "Value";
    private const string Value = "42";

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Argument { Name = "Value" };
        Argument.Options? options = default;

        // Act
        Func<Snippet> act = () => subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenNamedValueThenAppliesFormatterAndNaming()
    {
        // Arrange
        var subject = new Argument
        {
            Name = new Identifier(Name),
            Value = Snippet.From(Value),
        };

        var options = new Argument.Options
        {
            Naming = Variable.Options.Camel,
            Formatter = Argument.Formatter.Call,
        };

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("value: 42");
    }

    [Test]
    public async Task GivenModifierThenModifierIsPrefixed()
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
            Naming = Variable.Options.Camel,
            Formatter = Argument.Formatter.Call,
        };

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo("value: ref 42");
    }
}