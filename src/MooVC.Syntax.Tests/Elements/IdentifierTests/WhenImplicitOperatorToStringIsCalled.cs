namespace MooVC.Syntax.Elements.IdentifierTests;

using MooVC.Syntax.Formatting;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Identifier? identifier = default;

        // Act
        Func<string> result = () => identifier;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
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
        var subject = new Identifier(string.Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Identifier(Alpha);
        string expected = Alpha;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenUnicodeThenMatchesValueInPascalCase()
    {
        // Arrange
        var subject = new Identifier(Unicode);
        string expected = Unicode;

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
        string expected = value.ToPascalCase();

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }
}