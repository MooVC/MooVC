namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(Unary.Types.Increment as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}