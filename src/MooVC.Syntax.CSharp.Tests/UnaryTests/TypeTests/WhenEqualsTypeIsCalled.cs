namespace MooVC.Syntax.CSharp.UnaryTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(null as Unary.Type);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Unary.Type type = Unary.Type.Not;

        // Act
        bool result = type.Equals(Unary.Type.Increment);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}