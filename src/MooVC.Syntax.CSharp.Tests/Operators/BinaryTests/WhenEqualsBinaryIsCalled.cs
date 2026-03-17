namespace MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenEqualsBinaryIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Binary? subject = default;
        Binary target = BinaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        Binary target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        Binary target = BinaryTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Binary subject = BinaryTestsData.Create();
        Binary target = BinaryTestsData.Create(@operator: Binary.Type.Multiply);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}