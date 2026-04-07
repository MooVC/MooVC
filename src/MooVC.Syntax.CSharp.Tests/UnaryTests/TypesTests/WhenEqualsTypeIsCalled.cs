namespace MooVC.Syntax.CSharp.UnaryTests.TypesTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(Unary.Types.Increment);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(null as Unary.Types);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Unary.Types type = Unary.Types.Not;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}