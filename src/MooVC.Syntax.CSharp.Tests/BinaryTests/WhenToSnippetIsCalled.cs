namespace MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenExplicitOperandAndResultTypesThenSignatureUsesConfiguredQualification()
    {
        // Arrange
        var subject = Binary.Undefined
            .WithBody("return left.Combine(other);")
            .WithLeft(parameter => parameter.OfType(Symbol.Undefined.Named("Example.Amount")))
            .WithOperator(Binary.Types.Add)
            .WithResult(result => result.Named("Example.Total"))
            .WithRight(parameter => parameter.Named("other").OfType(Symbol.Undefined.Named("Example.Offset")));
        var options = Options.Default.WithTypes(types => types
            .WithQualifications(qualifications => qualifications.WithFormat(Qualification.Options.Formats.Global)));
        const string expected = """
            public static global::Example.Total operator +(global::Example.Amount left, global::Example.Offset other)
            {
                return left.Combine(other);
            }
            """;

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenAnExplicitOperandNameWithoutATypeThenContainingTypeIsUsed()
    {
        // Arrange
        var subject = BinaryTestsData.Create().WithRight(parameter => parameter.Named("other"));
        var type = OperatorsTestsData.Create();

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(result).StartsWith("public static Value operator +(Value left, Value other)");
    }
}