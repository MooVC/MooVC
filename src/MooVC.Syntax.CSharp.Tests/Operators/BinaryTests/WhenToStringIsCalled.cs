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
        Binary subject = BinaryTestsData.Create();
        var construct = OperatorsTestsData.CreateConstruct(isUndefined: true);

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
        var construct = OperatorsTestsData.CreateConstruct();

        // Act
        string representation = subject.ToString(construct, Snippet.Options.Default);

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
