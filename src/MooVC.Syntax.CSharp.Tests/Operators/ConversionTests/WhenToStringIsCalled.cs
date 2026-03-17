namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Conversion subject = Conversion.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(body: Snippet.Empty, subject: Symbol.Undefined);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create(isUndefined: true);

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenConversionToDeclarationThenSignatureIsRendered()
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

        representation.ShouldBe(expected);
    }

    [Test]
    public void GivenConversionFromDeclarationThenSignatureIsRendered()
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

        representation.ShouldBe(expected);
    }
}