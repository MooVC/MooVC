namespace MooVC.Syntax.CSharp.ComparisonTests;

using MooVC.Syntax.CSharp;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Comparison subject = Comparison.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create(body: Snippet.Empty, @operator: Comparison.Types.Unspecified);
        OperatorsTestsData.TestType type = OperatorsTestsData.Create(isUndefined: true);

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenSignatureIsRendered()
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

        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}