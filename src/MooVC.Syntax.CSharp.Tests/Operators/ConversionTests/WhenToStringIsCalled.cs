namespace MooVC.Syntax.CSharp.Operators.ConversionTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        Conversion subject = ConversionTestsData.Create(body: Snippet.Empty, subject: Symbol.Undefined);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create(isUndefined: true);

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options, type);

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenConversionToDeclarationThenSignatureIsRendered()
    {
        // Arrange
        Conversion subject = ConversionTestsData.Create(direction: Conversion.Intent.To);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options, type);

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
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options, type);

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