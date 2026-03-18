namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Name? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenSegmentWithNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Name(default);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Empty);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Empty);
    }

    [Test]
    public async Task GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Space);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Space);
    }

    [Test]
    public async Task GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Alpha);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Alpha);
    }

    [Test]
    public async Task GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Unicode);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(Unicode);
    }

    [Test]
    public async Task GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Name(value);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(value);
    }
}