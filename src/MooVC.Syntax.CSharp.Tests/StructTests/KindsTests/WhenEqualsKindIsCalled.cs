namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenEqualsKindIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        Struct.Kinds right = Struct.Kinds.Ref;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}