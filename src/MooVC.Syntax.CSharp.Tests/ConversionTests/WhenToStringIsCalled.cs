namespace MooVC.Syntax.CSharp.ConversionTests;

using MooVC.Syntax.CSharp;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Conversion subject = Conversion.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(body: Snippet.Empty, subject: Symbol.Undefined);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create(isUndefined: true);

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenConversionToDeclarationThenSignatureIsRendered()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(direction: Conversion.Intent.To);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

        // Assert
        string expected = """
            public static implicit operator Other(Value subject)
            {
                return new Value();
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenConversionFromDeclarationThenSignatureIsRendered()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(direction: Conversion.Intent.From);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

        // Assert
        string expected = """
            public static implicit operator Value(Other subject)
            {
                return new Value();
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}