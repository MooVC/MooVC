namespace MooVC.Syntax.Elements.IdentifierTests;

public sealed class WhenToStringIsCalled
{
    private const string MultiWord = "MyValue";

    [Test]
    public async Task GivenDefaultOptionsThenUsesPascalCase()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(MultiWord);
    }

    [Test]
    public async Task GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Identifier("MyName");
        var right = new Identifier("MyOtherName");

        // Act
        string leftString = left.ToString();
        string rightString = right.ToString();

        // Assert
        _ = await Assert.That(leftString).IsNotEqualTo(rightString);
    }

    [Test]
    public async Task GivenRepeatedCallsThenResultIsStable()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        _ = await Assert.That(first).IsEqualTo(second);
    }
}