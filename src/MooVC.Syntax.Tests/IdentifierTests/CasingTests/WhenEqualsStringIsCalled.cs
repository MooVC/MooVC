namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenEqualsStringIsCalled
{
    [Test]
    public async Task GivenDifferentStringThenReturnsFalse()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";

        // Act
        bool result = subject.Equals("Camel");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualStringThenReturnsTrue()
    {
        // Arrange
        Identifier.Casing subject = "Pascal";

        // Act
        bool result = subject.Equals("Pascal");

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}