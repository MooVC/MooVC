namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";

    [Test]
    public async Task GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = await Assert.That(() => _ = (Identifier)value).ThrowsNothing();
    }

    [Test]
    public async Task GivenNullWhenRoundTrippedThenResultIsEmpty()
    {
        // Arrange
        string? value = default;

        // Act
        Identifier subject = value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenEmptyThenEqualsString()
    {
        // Arrange
        string value = Empty;

        // Act
        Identifier subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenWhitespaceThenEqualsString()
    {
        // Arrange
        string value = Space;

        // Act
        Identifier subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = Alpha;

        // Act
        Identifier subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenVeryLongThenEqualsString()
    {
        // Arrange
        string value = new('x', 64_000);

        // Act
        Identifier subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = Alpha;

        // Act
        Identifier subject = value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Alpha;

        // Act
        Identifier first = value;
        Identifier second = value;

        // Assert
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That((first == second)).IsTrue();
        _ = await Assert.That(first.Equals(second)).IsTrue();
    }
}