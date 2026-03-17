namespace MooVC.Syntax.CSharp.Operators.UnaryTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Unary subject = Unary.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
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

    [Test]
    public void GivenValuesThenSignatureIsRendered()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create();
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

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