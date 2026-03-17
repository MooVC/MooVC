namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alpha = "Assets";

    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Path? path = default;

        // Act
        Func<string> result = () => path;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenMemberWithNullValueThenResultIsEmpty()
    {
        // Arrange
        var subject = new Path(default);

        // Act
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        var subject = new Path(string.Empty);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenAsciiThenMatchesValue()
    {
        // Arrange
        var subject = new Path(Alpha);
        string expected = Alpha;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenVeryLongThenMatchesValue()
    {
        // Arrange
        string value = new('x', 64_000);
        var subject = new Path(value);

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }
}