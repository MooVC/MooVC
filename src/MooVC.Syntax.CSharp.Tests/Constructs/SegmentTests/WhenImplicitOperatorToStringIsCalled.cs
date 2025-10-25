namespace MooVC.Syntax.CSharp.Constructs.SegmentTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Segment? subject = default;

        // Act
        Func<string> act = () => (string)subject;

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(subject));
    }

    [Fact]
    public void GivenSegmentWithNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Segment(default);

        // Act
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Empty);
    }

    [Fact]
    public void GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Space);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Space);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Alpha);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Alpha);
    }

    [Fact]
    public void GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = new Segment(Unicode);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Unicode);
    }

    [Fact]
    public void GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new string('x', 64_000);
        var subject = new Segment(value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }
}
