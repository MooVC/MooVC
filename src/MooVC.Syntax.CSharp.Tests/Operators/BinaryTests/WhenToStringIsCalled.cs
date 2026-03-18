namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Binary subject = Binary.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create(body: Snippet.Empty, @operator: Binary.Type.Unspecified);
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
        Binary subject = BinaryTestsData.Create();
        OperatorsTestsData.TestType type = OperatorsTestsData.Create();

        // Act
        string representation = subject.ToString(Snippet.Options.Default, type);

        // Assert
        string expected = """
            public static Value operator +(Value left, Value right)
            {
                return left + right;
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}