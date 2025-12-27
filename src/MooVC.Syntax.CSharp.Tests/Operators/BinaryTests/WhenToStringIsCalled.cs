namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Binary subject = Binary.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create(body: Snippet.Empty, @operator: Binary.Type.Unspecified);
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
        Binary subject = BinaryTestsData.Create();
        OperatorsTestsData.TestConstruct construct = OperatorsTestsData.CreateConstruct();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(construct, options);

        // Assert
        string expected = """
            public static Value operator +(Value left, Value right)
            {
                return left + right;
            }
            """;

        representation.ShouldBe(expected);
    }
}