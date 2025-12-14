namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Comparison subject = Comparison.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create(body: Snippet.Empty, @operator: Comparison.Type.Unspecified);
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct(isUndefined: true);

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(construct, options);

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenSignatureIsRendered()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(construct, options);

        // Assert
        string expected = """
            public static bool operator ==(Value left, Value right)
            {
                return left == right;
            }
            """;

        representation.ShouldBe(expected);
    }
}