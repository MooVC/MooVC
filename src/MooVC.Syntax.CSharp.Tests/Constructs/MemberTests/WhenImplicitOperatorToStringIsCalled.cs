namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Fact]
    public void GivenNullSubjectWhenConvertedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Member? subject = default;

        // Act
        Func<string> act = () => (string)subject;

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(subject));
    }

    [Fact]
    public void GivenMemberWithNullValueWhenConvertedThenResultIsNull()
    {
        // Arrange
        var subject = new Member(default);

        // Act
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyWhenConvertedThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Empty);
    }

    [Fact]
    public void GivenWhitespaceWhenConvertedThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Space);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Space);
    }

    [Fact]
    public void GivenAsciiWhenConvertedThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Alpha);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Alpha);
    }

    [Fact]
    public void GivenUnicodeWhenConvertedThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Unicode);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Unicode);
    }

    [Fact]
    public void GivenVeryLongWhenConvertedThenMatchesValue()
    {
        // Arrange
        string value = new string('x', 64_000);
        var subject = new Member(value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }
}