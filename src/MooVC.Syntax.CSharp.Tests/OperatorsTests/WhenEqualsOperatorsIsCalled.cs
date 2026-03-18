namespace MooVC.Syntax.CSharp.OperatorsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenEqualsOperatorsIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Operators? subject = default;
        Operators target = OperatorsSubjectData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create();
        Operators target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        ImmutableArray<Binary> binaries = [BinaryTestsData.Create()];
        Operators subject = OperatorsSubjectData.Create(binaries: binaries);
        Operators target = OperatorsSubjectData.Create(binaries: binaries);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Operators subject = OperatorsSubjectData.Create();
        Operators target = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}