namespace MooVC.Syntax.CSharp.Elements.ParameterExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Elements.ParameterTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstName = "Bravo";
    private const string SecondName = "Alpha";
    private const string ThirdName = "Delta";
    private const string FourthName = "Charlie";

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Parameter> parameters = isDefault
            ? default
            : [];

        // Act
        var snippet = parameters.ToSnippet(Parameter.Options.Camel);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Parameter> parameters = [ParameterTestsData.Create()];
        Parameter.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = parameters.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenTheyAreOrderedByDefaultParamsAndName()
    {
        // Arrange
        Parameter noDefault = ParameterTestsData.Create(name: FirstName);
        Parameter withDefault = ParameterTestsData.Create(name: SecondName, @default: Snippet.From("42"));
        Parameter @params = ParameterTestsData.Create(name: ThirdName, modifier: Parameter.Mode.Params, type: typeof(Version[]));
        Parameter later = ParameterTestsData.Create(name: FourthName);

        ImmutableArray<Parameter> parameters = [withDefault, @params, later, noDefault];

        const string expected = "Version bravo, Version charlie, Version alpha = 42, params Version[] delta";

        // Act
        var snippet = parameters.ToSnippet(Parameter.Options.Camel);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}