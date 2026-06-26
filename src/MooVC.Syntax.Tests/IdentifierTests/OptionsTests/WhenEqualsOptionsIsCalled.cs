namespace MooVC.Syntax.IdentifierTests.OptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Test]
    public async Task GivenEquivalentOptionsThenReturnsTrue()
    {
        // Arrange
        var subject = new Identifier.Options { Casing = Identifier.Casing.Pascal };
        var other = new Identifier.Options { Casing = Identifier.Casing.Pascal };

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonEquivalentOptionsThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier.Options { Casing = Identifier.Casing.Camel };
        var other = new Identifier.Options { Casing = Identifier.Casing.Kebab };

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}