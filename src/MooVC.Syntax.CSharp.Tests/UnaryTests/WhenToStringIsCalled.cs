namespace MooVC.Syntax.CSharp.UnaryTests;

using MooVC.Syntax.CSharp;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Unary subject = Unary.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Unary subject = UnaryTestsData.Create(body: Snippet.Empty, @operator: Unary.Types.Unspecified);
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

        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}