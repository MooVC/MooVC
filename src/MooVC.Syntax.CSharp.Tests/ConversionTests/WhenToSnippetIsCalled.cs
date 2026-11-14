namespace MooVC.Syntax.CSharp.ConversionTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenExplicitInputAndResultThenSignatureUsesConfiguredQualification()
    {
        // Arrange
        var subject = Conversion.Undefined
            .WithBody("return value.ToTotal();")
            .WithInput(parameter => parameter.Named("value").OfType(Symbol.Undefined.Named("Example.Amount")))
            .WithMode(Conversion.Types.Explicit)
            .WithResult(result => result.Named("Example.Total"));
        var options = Options.Default.WithTypes(types => types
            .WithQualifications(qualifications => qualifications.WithFormat(Qualification.Options.Formats.Global)));
        const string expected = """
            public static explicit operator global::Example.Total(global::Example.Amount value)
            {
                return value.ToTotal();
            }
            """;

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenAnExplicitInputNameWithoutATypeThenDirectionDeterminesInputType()
    {
        // Arrange
        var subject = ConversionTestsData.Create(direction: Conversion.Intents.From).WithInput(parameter => parameter.Named("value"));
        var type = OperatorsTestsData.Create();

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(result).StartsWith("public static implicit operator Value(Other value)");
    }
}