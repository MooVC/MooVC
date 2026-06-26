namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(Binary.Types.Subtract as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(null as object);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(type as object);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}