namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenEqualsObjectForKindIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds subject = Struct.Kinds.Record;
        object other = Struct.Kinds.Ref;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds subject = Struct.Kinds.Record;

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds subject = Struct.Kinds.Record;
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}