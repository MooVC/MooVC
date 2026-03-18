namespace MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenEqualsBinaryIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Binary? subject = default;
        Binary target = BinaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        Binary target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        Binary target = BinaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        Binary target = BinaryTestsData.Create(@operator: Binary.Type.Multiply);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}