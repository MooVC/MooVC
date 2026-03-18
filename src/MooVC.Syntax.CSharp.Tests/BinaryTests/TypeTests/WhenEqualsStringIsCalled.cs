namespace MooVC.Syntax.CSharp.BinaryTests.TypeTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "+";
    private const string Other = "-";

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Binary.Type type = Binary.Type.Add;

        // Act
        bool result = type.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}