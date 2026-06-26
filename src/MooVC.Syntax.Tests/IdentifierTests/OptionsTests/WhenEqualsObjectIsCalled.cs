namespace MooVC.Syntax.IdentifierTests.OptionsTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier.Options();

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier.Options();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentOptionsThenReturnsTrue()
    {
        // Arrange
        var subject = new Identifier.Options { Casing = Identifier.Casing.Kebab };
        var other = new Identifier.Options { Casing = Identifier.Casing.Kebab };

        // Act
        bool result = subject.Equals((object)other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}