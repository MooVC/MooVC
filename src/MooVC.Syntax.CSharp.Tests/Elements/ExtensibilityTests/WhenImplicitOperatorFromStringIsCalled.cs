namespace MooVC.Syntax.CSharp.Elements.ExtensibilityTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Value = "custom";

    [Test]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Extensibility)value);
    }

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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