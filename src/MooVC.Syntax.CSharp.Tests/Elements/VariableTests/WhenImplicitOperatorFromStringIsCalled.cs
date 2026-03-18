namespace MooVC.Syntax.CSharp.Elements.VariableTests;

using MooVC.Syntax.Formatting;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Alpha = "Alpha";

    [Test]
    public async Task GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = await Assert.That(() => _ = (Variable)value).ThrowsNothing();
    }

    [Test]
    public async Task GivenNullWhenRoundTrippedThenResultIsEmpty()
    {
        // Arrange
        string? value = default;

        // Act
        Variable subject = value;
        string result = subject;

        // Assert
        await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenEmptyThenEqualsString()
    {
        // Arrange
        string value = Empty;

        // Act
        Variable subject = value;

        // Assert
        await Assert.That((subject == value)).IsTrue();
        await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = Alpha;

        // Act
        Variable subject = value;

        // Assert
        await Assert.That((subject == value)).IsTrue();
        await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenVeryLongThenEqualsString()
    {
        // Arrange
        string value = new('x', 64_000);
        string expected = value.ToPascalCase();

        // Act
        Variable subject = value;

        // Assert
        await Assert.That((subject == expected)).IsTrue();
        await Assert.That(subject.Equals(expected)).IsTrue();
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginalInCamelCase()
    {
        // Arrange
        string value = Alpha;
        string expected = value.ToCamelCase();

        // Act
        Variable subject = value;
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Alpha;

        // Act
        Variable first = value;
        Variable second = value;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}