namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string None = "";
    private const string Method = "method";

    [Test]
    public async Task GivenNoneThenEqualsString()
    {
        // Arrange
        string value = None;

        // Act
        Attribute.Specifiers subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }

    [Test]
    public async Task GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = await Assert.That(() => _ = (Attribute.Specifiers)value).ThrowsNothing();
    }

    [Test]
    public async Task GivenNullWhenRoundTrippedThenResultIsNull()
    {
        // Arrange
        string? value = default;

        // Act
        Attribute.Specifiers subject = value;
        string? result = subject;

        // Assert
        _ = await Assert.That(result).IsNull();
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Method;

        // Act
        Attribute.Specifiers first = value;
        Attribute.Specifiers second = value;

        // Assert
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That(first == second).IsTrue();
        _ = await Assert.That(first).IsEqualTo(second);
    }

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = Method;

        // Act
        Attribute.Specifiers subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = Method;

        // Act
        Attribute.Specifiers subject = value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}