namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenInequalityOperatorKindKindIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds? left = default;
        Struct.Kinds? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Ref;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}