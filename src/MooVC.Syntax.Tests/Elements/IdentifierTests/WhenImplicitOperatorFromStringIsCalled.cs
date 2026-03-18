namespace MooVC.Syntax.Elements.IdentifierTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";

    [Test]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Identifier)value);
    }

    [Test]
    public void GivenNullWhenRoundTrippedThenResultIsEmpty()
    {
        // Arrange
        string? value = default;

        // Act
        Identifier subject = value;
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
        Identifier subject = value;

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
        Identifier subject = value;

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
        Identifier subject = value;

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
        Identifier subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenValueWhenRoundTrippedThenMatchesOriginalInPascalCase()
    {
        // Arrange
        string value = Alpha;
        string expected = value;

        // Act
        Identifier subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Alpha;

        // Act
        Identifier first = value;
        Identifier second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}