namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenEqualityOperatorCasingStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";

        // Act
        bool result = subject == "Snake";

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        const string casing = "Pascal";
        Identifier.Casing subject = casing;

        // Act
        bool result = subject == casing;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}