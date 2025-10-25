namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

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
        Member? subject = default;

        // Act
        Func<string> act = () => (string)subject;

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(subject));
    }

    [Fact]
    public void GivenMemberWithNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Member(default);

        // Act
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Empty);
    }

    [Fact]
    public void GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Space);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Space);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Alpha);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Alpha);
    }

    [Fact]
    public void GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = new Member(Unicode);

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
        var subject = new Member(value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }
}