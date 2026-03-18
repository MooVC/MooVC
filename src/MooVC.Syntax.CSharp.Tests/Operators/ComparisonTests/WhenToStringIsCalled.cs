namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Comparison subject = Comparison.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create(body: Snippet.Empty, @operator: Comparison.Type.Unspecified);
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
        Comparison subject = ComparisonTestsData.Create();
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

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