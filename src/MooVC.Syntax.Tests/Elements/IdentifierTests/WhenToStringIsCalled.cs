namespace MooVC.Syntax.Elements.IdentifierTests;

public sealed class WhenToStringIsCalled
{
    private const string MultiWord = "MyValue";

    [Fact]
    public void GivenDefaultOptionsThenUsesCamelCase()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("myValue");
    }

    [Fact]
    public void GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Identifier("MyName");
        var right = new Identifier("MyOtherName");

        // Act
        string leftString = left.ToString();
        string rightString = right.ToString();

        // Assert
        leftString.ShouldNotBe(rightString);
    }

    [Fact]
    public void GivenRepeatedCallsThenResultIsStable()
    {
        // Arrange
        var subject = new Identifier(MultiWord);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        first.ShouldBe(second);
    }
}