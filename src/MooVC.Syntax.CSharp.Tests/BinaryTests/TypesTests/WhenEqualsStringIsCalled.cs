namespace MooVC.Syntax.CSharp.BinaryTests.TypesTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "+";
    private const string Other = "-";

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(null as string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Binary.Types type = Binary.Types.Add;

        // Act
        bool result = type.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}