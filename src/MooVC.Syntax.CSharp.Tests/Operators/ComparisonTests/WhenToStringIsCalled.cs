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
        Comparison subject = ComparisonTestsData.Create();
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
        Comparison subject = ComparisonTestsData.Create();
        var construct = OperatorsTestsData.CreateConstruct();

        // Act
        string representation = subject.ToString(construct, Snippet.Options.Default);

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
