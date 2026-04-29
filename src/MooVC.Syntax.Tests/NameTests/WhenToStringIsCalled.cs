namespace MooVC.Syntax.NameTests;

public sealed class WhenToStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";
    private const string WithUnderscore = "Alpha_Beta";
    private const string WithPrefix = "@Alpha";

    [Test]
    public async Task GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Alpha);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Alpha);
    }

    [Test]
    public async Task GivenDifferentValuesThenDifferentResultsAreReturned()
    {
        // Arrange
        var left = new Name("Alpha");
        var right = new Name("Beta");

        // Act
        string leftString = left.ToString();
        string rightString = right.ToString();

        // Assert
        _ = await Assert.That(leftString).IsNotEqualTo(rightString);
    }

    [Test]
    public async Task GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Empty);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Empty);
    }

    [Test]
    public async Task GivenNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Name(default);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsNull();
    }

    [Test]
    public async Task GivenRepeatedCallsThenResultIsStable()
    {
        // Arrange
        var subject = new Name(Alpha);

        // Act
        string first = subject.ToString();
        string second = subject.ToString();

        // Assert
        _ = await Assert.That(first).IsEqualTo(second);
    }

    [Test]
    public async Task GivenReservedPrefixThenMatchesValue()
    {
        // Arrange
        var subject = new Name(WithPrefix);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(WithPrefix);
    }

    [Test]
    public async Task GivenUnicodeThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Unicode);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Unicode);
    }

    [Test]
    public async Task GivenValueWithUnderscoreThenMatchesValue()
    {
        // Arrange
        var subject = new Name(WithUnderscore);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(WithUnderscore);
    }

    [Test]
    public async Task GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Name(value);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenWhitespaceThenMatchesValue()
    {
        // Arrange
        var subject = new Name(Space);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Space);
    }
}