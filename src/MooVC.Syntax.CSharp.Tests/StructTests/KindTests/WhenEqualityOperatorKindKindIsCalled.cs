namespace MooVC.Syntax.CSharp.StructTests.KindTests;

public sealed class WhenEqualityOperatorKindKindIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Struct.Kind? left = default;
        Struct.Kind? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.ReadOnly;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind right = left;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}