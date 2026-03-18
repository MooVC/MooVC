namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "TAlpha";
    private const string Different = "TBravo";

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier(Same);
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var subject = new Identifier(Same);
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Identifier(Same);
        object right = new Identifier(Same);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier(Same);
        object right = new Identifier(Different);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNonIdentifierThenReturnsFalse()
    {
        // Arrange
        var subject = new Identifier(Same);
        object other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}