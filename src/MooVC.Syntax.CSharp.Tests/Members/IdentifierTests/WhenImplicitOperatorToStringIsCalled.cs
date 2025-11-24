namespace MooVC.Syntax.CSharp.Members.IdentifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Empty = "";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Identifier? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMemberWithNullValueThenResultIsEmpty()
    {
        // Arrange
        var subject = new Identifier(default);

        // Act
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Identifier(Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Empty);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Identifier(Alpha);
        string expected = Alpha.ToCamelCase();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenUnicodeThenMatchesValueInCamelCase()
    {
        // Arrange
        var subject = new Identifier(Unicode);
        string expected = Unicode.ToCamelCase();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Identifier(value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }
}