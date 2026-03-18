namespace MooVC.Syntax.IdentifierTests;

using MooVC.Syntax.Formatting;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Identifier? identifier = default;

        // Act
        Func<string> result = () => identifier;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenMemberWithNullValueThenResultIsEmpty()
    {
        // Arrange
        var subject = new Identifier(default);

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Identifier(string.Empty);

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Identifier(Alpha);
        string expected = Alpha;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenUnicodeThenMatchesValueInPascalCase()
    {
        // Arrange
        var subject = new Identifier(Unicode);
        string expected = Unicode;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Identifier(value);
        string expected = value.ToPascalCase();

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}