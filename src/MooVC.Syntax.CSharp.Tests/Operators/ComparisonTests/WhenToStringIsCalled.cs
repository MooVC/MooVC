namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using MooVC.Syntax.Elements;

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
        OperatorsTestsData.TestType type = OperatorsTestsData.Create(isUndefined: true);

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options, type);

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenSignatureIsRendered()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options, type);

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