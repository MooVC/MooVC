namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";

        // Act
        bool result = subject.Equals(3);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentCasingThenReturnsTrue()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";
        object other = (Identifier.Casing)"Pascal";

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}