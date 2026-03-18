namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenIsUnnamedIsCalled
{
    [Test]
    public async Task GivenUnnamedIdentifierThenReturnsTrue()
    {
        // Arrange
        Identifier subject = Identifier.Unnamed;

        // Act
        bool result = subject.IsUnnamed;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNamedIdentifierThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier("TValue");

        // Act
        bool result = subject.IsUnnamed;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}