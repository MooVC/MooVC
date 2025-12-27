namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

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
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct(isUndefined: true);

        // Act
        string representation = subject.ToString(construct, Snippet.Options.Default);

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenSignatureIsRendered()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(construct, options);

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