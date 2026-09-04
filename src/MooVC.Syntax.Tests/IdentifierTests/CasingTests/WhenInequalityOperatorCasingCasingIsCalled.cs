namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenInequalityOperatorCasingCasingIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Identifier.Casing? left = default;
        Identifier.Casing? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Identifier.Casing left = "Pascal";
        Identifier.Casing right = "Camel";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Identifier.Casing left = "Pascal";
        Identifier.Casing right = "Pascal";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}