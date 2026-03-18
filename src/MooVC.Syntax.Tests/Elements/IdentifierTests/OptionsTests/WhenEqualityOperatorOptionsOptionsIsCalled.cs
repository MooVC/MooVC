namespace MooVC.Syntax.Elements.IdentifierTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier.Options? left = default;
        Identifier.Options? right = default;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Identifier.Options? left = default;
        var right = new Identifier.Options();

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Identifier.Options();
        var right = new Identifier.Options();

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier.Options { Casing = Identifier.Casing.Camel };
        var right = new Identifier.Options { Casing = Identifier.Casing.Kebab };

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }
}