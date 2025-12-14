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
        Unary subject = UnaryTestsData.Create();
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
        Unary subject = UnaryTestsData.Create();
        var construct = OperatorsTestsData.CreateConstruct();

        // Act
        string representation = subject.ToString(construct, Snippet.Options.Default);

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
