namespace MooVC.Syntax.CSharp.BinaryTests.TypeTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(default(Binary.Type));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(Binary.Type.Subtract);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}