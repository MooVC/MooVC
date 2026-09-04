namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenEqualsCasingIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";
        Identifier.Casing other = "Camel";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";
        Identifier.Casing other = "Pascal";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}