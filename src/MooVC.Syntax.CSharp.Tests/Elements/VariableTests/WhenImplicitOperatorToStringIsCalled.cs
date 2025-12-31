namespace MooVC.Syntax.CSharp.Elements.VariableTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Variable? variable = default;

        // Act
        Func<string> result = () => variable;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenMemberWithNullValueThenResultIsEmpty()
    {
        // Arrange
        var subject = new Variable(default);

        // Act
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Variable(string.Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Variable(Alpha);
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
        var subject = new Variable(Unicode);
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
        var subject = new Variable(value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }
}