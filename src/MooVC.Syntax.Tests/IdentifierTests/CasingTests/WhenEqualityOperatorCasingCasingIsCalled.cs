namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenEqualityOperatorCasingCasingIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier.Casing? left = default;
        Identifier.Casing? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Identifier.Casing left = "Pascal";
        Identifier.Casing right = "Camel";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Identifier.Casing left = "Pascal";
        Identifier.Casing right = "Pascal";

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}