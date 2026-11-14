namespace MooVC.Syntax.CSharp.UnaryTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenExplicitOperandAndResultTypesThenSignatureUsesConfiguredQualification()
    {
        // Arrange
        var subject = Unary.Undefined
            .WithBody("return operand.Negate();")
            .WithOperand(parameter => parameter.Named("operand").OfType(Symbol.Undefined.Named("Example.Amount")))
            .WithOperator(Unary.Types.Minus)
            .WithResult(result => result.Named("Example.Total"));
        var options = Options.Default.WithTypes(types => types
            .WithQualifications(qualifications => qualifications.WithFormat(Qualification.Options.Formats.Global)));
        const string expected = """
            public static global::Example.Total operator -(global::Example.Amount operand)
            {
                return operand.Negate();
            }
            """;

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}