namespace MooVC.Syntax.CSharp.Elements.VariableTests;

public sealed class WhenToStringIsCalled
{
    private const string MultiWord = "MyValue";

    [Test]
    public async Task GivenDefaultOptionsThenUsesCamelCase()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo("myValue");
    }

    [Test]
    public async Task GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Variable("MyName");
        var right = new Variable("MyOtherName");

        // Act
        string leftString = left.ToString();
        string rightString = right.ToString();

        // Assert
        await Assert.That(leftString).IsNotEqualTo(rightString);
    }

    [Test]
    public async Task GivenRepeatedCallsThenResultIsStable()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        await Assert.That(first).IsEqualTo(second);
    }
}