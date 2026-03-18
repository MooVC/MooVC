namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string None = "";
    private const string Method = "method";

    [Test]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Attribute.Specifier)value);
    }

    [Test]
    public void GivenNullWhenRoundTrippedThenResultIsNull()
    {
        // Arrange
        string? value = default;

        // Act
        Attribute.Specifier subject = value;
        string? result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Test]
    public void GivenNoneThenEqualsString()
    {
        // Arrange
        string value = None;

        // Act
        Attribute.Specifier subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Method;

        // Act
        Attribute.Specifier subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Test]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = Method;

        // Act
        Attribute.Specifier subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(value);
    }

    [Test]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Method;

        // Act
        Attribute.Specifier first = value;
        Attribute.Specifier second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}