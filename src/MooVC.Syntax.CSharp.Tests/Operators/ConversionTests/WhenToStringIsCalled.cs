namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Conversion subject = Conversion.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create();
        var construct = OperatorsTestsData.CreateConstruct(isUndefined: true);

        // Act
        string representation = subject.ToString(construct, Snippet.Options.Default);

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenConversionToDeclarationThenSignatureIsRendered()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(direction: Conversion.Intent.To);
        var construct = OperatorsTestsData.CreateConstruct();

        // Act
        string representation = subject.ToString(construct, Snippet.Options.Default);

        // Assert
        string expected = """
            public static implicit operator Other(Value subject)
            {
                return new Value();
            }
            """;

        representation.ShouldBe(expected);
    }

    [Fact]
    public void GivenConversionFromDeclarationThenSignatureIsRendered()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(direction: Conversion.Intent.From);
        var construct = OperatorsTestsData.CreateConstruct();

        // Act
        string representation = subject.ToString(construct, Snippet.Options.Default);

        // Assert
        string expected = """
            public static implicit operator Value(Other subject)
            {
                return new Value();
            }
            """;

        representation.ShouldBe(expected);
    }
}
