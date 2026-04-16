namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenInequalityOperatorCasingStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";

        // Act
        bool result = subject != "Snake";

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        const string casing = "Pascal";
        Identifier.Casing subject = casing;

        // Act
        bool result = subject != casing;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}