namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Value = "in";

    [Test]
    public async Task GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = await Assert.That(() => _ = (Parameter.Mode)value).ThrowsNothing();
    }

    [Test]
    public async Task GivenNullWhenRoundTrippedThenResultIsNull()
    {
        // Arrange
        string? value = default;

        // Act
        Parameter.Mode subject = value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsNull();
    }

    [Test]
    public async Task GivenEmptyThenEqualsString()
    {
        // Arrange
        string value = Empty;

        // Act
        Parameter.Mode subject = value;

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
        Parameter.Mode subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = Value;

        // Act
        Parameter.Mode subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }
}