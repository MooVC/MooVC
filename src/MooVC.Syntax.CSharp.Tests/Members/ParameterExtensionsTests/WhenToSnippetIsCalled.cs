namespace MooVC.Syntax.CSharp.Members.ParameterExtensionsTests;

using System;
using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstName = "Bravo";
    private const string SecondName = "Alpha";
    private const string ThirdName = "Delta";
    private const string FourthName = "Charlie";

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Parameter> parameters = isDefault
            ? default
            : [];

        // Act
        Snippet snippet = parameters.ToSnippet(Parameter.Options.Camel);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Parameter> parameters = [ParameterTestsData.Create()];
        Parameter.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = parameters.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenTheyAreOrderedByDefaultParamsAndName()
    {
        // Arrange
        Parameter noDefault = ParameterTestsData.Create(name: FirstName);
        Parameter withDefault = ParameterTestsData.Create(name: SecondName, @default: Snippet.From("42"));
        Parameter @params = ParameterTestsData.Create(name: ThirdName, modifier: Parameter.Mode.Params);
        Parameter later = ParameterTestsData.Create(name: FourthName);

        ImmutableArray<Parameter> parameters = [withDefault, @params, later, noDefault];

        const string expected = "Version bravo, Version charlie, params Version delta, Version alpha = 42";

        // Act
        Snippet snippet = parameters.ToSnippet(Parameter.Options.Camel);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}
