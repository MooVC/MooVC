namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenEqualityOperatorKindKindIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds? left = default;
        Struct.Kinds? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.ReadOnly;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        bool result = left == right;

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
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        Struct.Kinds right = left;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}