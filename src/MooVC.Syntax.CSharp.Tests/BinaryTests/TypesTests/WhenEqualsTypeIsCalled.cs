namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenEqualsTypeIsCalled
{
    [Test]
    public async Task GivenADifferentInstanceThenReturnsFalse()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(Binary.Types.Subtract);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(default(Binary.Types));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameInstanceThenReturnsTrue()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(type);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}