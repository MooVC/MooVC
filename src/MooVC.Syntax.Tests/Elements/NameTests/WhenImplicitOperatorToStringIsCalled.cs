namespace MooVC.Syntax.Elements.NameTests;

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
        Name? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenSegmentWithNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Name(default);

        // Act
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Empty);
    }

    [Fact]
    public void GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Space);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Space);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Alpha);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Alpha);
    }

    [Fact]
    public void GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Unicode);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Unicode);
    }

    [Fact]
    public void GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Name(value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }
}