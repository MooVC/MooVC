namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alpha = "Assets";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Path? path = default;

        // Act
        Func<string> result = () => path;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenMemberWithNullValueThenResultIsEmpty()
    {
        // Arrange
        var subject = new Path(default);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Path(string.Empty);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Path(Alpha);
        string expected = Alpha;

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
        var subject = new Path(value);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(value);
    }
}