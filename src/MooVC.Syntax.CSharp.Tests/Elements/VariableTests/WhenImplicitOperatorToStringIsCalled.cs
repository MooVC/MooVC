namespace MooVC.Syntax.CSharp.Elements.VariableTests;

using MooVC.Syntax.Elements;
using MooVC.Syntax.Formatting;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Variable? variable = default;

        // Act
        Func<string> result = () => variable;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenMemberWithNullValueThenResultIsEmpty()
    {
        // Arrange
        var subject = new Variable(default(Identifier));

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Variable(string.Empty);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Variable(Alpha);
        string expected = Alpha.ToCamelCase();

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenUnicodeThenMatchesValueInCamelCase()
    {
        // Arrange
        var subject = new Variable(Unicode);
        string expected = Unicode.ToCamelCase();

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Variable(value);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(value);
    }
}