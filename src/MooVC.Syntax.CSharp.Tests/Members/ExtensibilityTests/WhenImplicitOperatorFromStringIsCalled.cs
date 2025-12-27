namespace MooVC.Syntax.CSharp.Members.ExtensibilityTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Value = "custom";

    [Fact]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Extensibility)value);
    }

    [Fact]
    public void GivenNullWhenRoundTrippedThenResultIsNull()
    {
        // Arrange
        string? value = default;

        // Act
        Extensibility subject = value;
        string result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenEqualsString()
    {
        // Arrange
        string value = Empty;

        // Act
        Extensibility subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenWhitespaceThenEqualsString()
    {
        // Arrange
        string value = Space;

        // Act
        Extensibility subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Extensibility subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = Value;

        // Act
        Extensibility subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Value;

        // Act
        Extensibility first = value;
        Extensibility second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}