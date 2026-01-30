namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Name = "custom";

    [Fact]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Scope)value);
    }

    [Fact]
    public void GivenNullWhenRoundTrippedThenResultIsNull()
    {
        // Arrange
        string? value = default;

        // Act
        Scope subject = value;
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
        Scope subject = value;

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
        Scope subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Name;

        // Act
        Scope subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = Name;

        // Act
        Scope subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Name;

        // Act
        Scope first = value;
        Scope second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}