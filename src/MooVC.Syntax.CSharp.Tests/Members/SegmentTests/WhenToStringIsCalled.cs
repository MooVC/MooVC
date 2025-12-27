namespace MooVC.Syntax.CSharp.Members.SegmentTests;

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
        var subject = new Segment(default);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Empty);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Empty);
    }

    [Fact]
    public void GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Space);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Space);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Alpha);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Alpha);
    }

    [Fact]
    public void GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Unicode);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(Unicode);
    }

    [Fact]
    public void GivenValueWithUnderscoreThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(WithUnderscore);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(WithUnderscore);
    }

    [Fact]
    public void GivenReservedPrefixThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(WithPrefix);

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
        var subject = new Segment(value);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Segment("Alpha");
        var right = new Segment("Beta");

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
        var subject = new Segment(Alpha);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        first.ShouldBe(second);
    }
}