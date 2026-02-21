namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenToStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";
    private const string WithUnderscore = "Alpha_Beta";
    private const string WithPrefix = "@Alpha";

    [Fact]
    public void GivenNullValueThenResultIsNull()
    {
        // Arrange
        var subject = default;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = Empty;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Empty);
    }

    [Fact]
    public void GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = Space;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Space);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = Alpha;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Alpha);
    }

    [Fact]
    public void GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = Unicode;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Unicode);
    }

    [Fact]
    public void GivenValueWithUnderscoreThenMatchesValue()
    {
        // Arrange
        var subject = WithUnderscore;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(WithUnderscore);
    }

    [Fact]
    public void GivenReservedPrefixThenMatchesValue()
    {
        // Arrange
        var subject = WithPrefix;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(WithPrefix);
    }

    [Fact]
    public void GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = value;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = "Alpha";
        var right = "Beta";

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
        var subject = Alpha;

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        first.ShouldBe(second);
    }
}