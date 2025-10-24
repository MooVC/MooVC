namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";

    [Fact]
    public void GivenNullWhenConvertedThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Member)value);
    }

    [Fact]
    public void GivenNullWhenRoundTrippedThenResultIsNull()
    {
        // Arrange
        string? value = default;

        // Act
        Member subject = value;
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyWhenConvertedThenEqualsString()
    {
        // Arrange
        string value = Empty;

        // Act
        Member subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenWhitespaceWhenConvertedThenEqualsString()
    {
        // Arrange
        string value = Space;

        // Act
        Member subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenConvertedThenEqualsString()
    {
        // Arrange
        string value = Alpha;

        // Act
        Member subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenVeryLongWhenConvertedThenEqualsString()
    {
        // Arrange
        string value = new string('x', 64_000);

        // Act
        Member subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = Alpha;

        // Act
        Member subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenSameValueWhenConvertedTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Alpha;

        // Act
        Member first = value;
        Member second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}