namespace MooVC.Syntax.CSharp.Elements.VariableTests;

public sealed class WhenToStringIsCalled
{
    private const string MultiWord = "MyValue";

    [Test]
    public void GivenDefaultOptionsThenUsesCamelCase()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("myValue");
    }

    [Test]
    public void GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Variable("MyName");
        var right = new Variable("MyOtherName");

        // Act
        string leftString = left.ToString();
        string rightString = right.ToString();

        // Assert
        leftString.ShouldNotBe(rightString);
    }

    [Test]
    public void GivenRepeatedCallsThenResultIsStable()
    {
        // Arrange
        var subject = new Variable(MultiWord);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        first.ShouldBe(second);
    }
}