namespace MooVC.Syntax.Elements.PathTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Assets";

    [Test]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Path)value);
    }

    [Test]
    public void GivenNullWhenRoundTrippedThenResultIsEmpty()
    {
        // Arrange
        string? value = default;

        // Act
        Path subject = value;
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
    public void GivenEmptyThenEqualsString()
    {
        // Arrange
        string value = Empty;

        // Act
        Path subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenWhitespaceThenEqualsString()
    {
        // Arrange
        string value = Space;

        // Act
        Path subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Alpha;

        // Act
        Path subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenVeryLongThenEqualsString()
    {
        // Arrange
        string value = new('x', 64_000);

        // Act
        Path subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = Alpha;

        // Act
        Path subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Alpha;

        // Act
        Path first = value;
        Path second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}