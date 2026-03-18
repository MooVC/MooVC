namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenToStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";
    private const string WithUnderscore = "Alpha_Beta";
    private const string WithPrefix = "@Alpha";

    [Test]
    public void GivenNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Name(default);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBeNull();
    }

    [Test]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Empty);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Empty);
    }

    [Test]
    public void GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Space);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Space);
    }

    [Test]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Alpha);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Alpha);
    }

    [Test]
    public void GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Unicode);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Unicode);
    }

    [Test]
    public void GivenValueWithUnderscoreThenMatchesValue()
    {
        // Arrange
        var subject = new Name(WithUnderscore);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(WithUnderscore);
    }

    [Test]
    public void GivenReservedPrefixThenMatchesValue()
    {
        // Arrange
        var subject = new Name(WithPrefix);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(WithPrefix);
    }

    [Test]
    public void GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Name(value);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Name("Alpha");
        var right = new Name("Beta");

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
        var subject = new Name(Alpha);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        first.ShouldBe(second);
    }
}