namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Unary subject = Unary.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create(body: Snippet.Empty, @operator: Unary.Type.Unspecified);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create(isUndefined: true);

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenSignatureIsRendered()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options, type);

        // Assert
        string expected = """
            public static Value operator +(Value value)
            {
                return +value;
            }
            """;

        representation.ShouldBe(expected);
    }
}